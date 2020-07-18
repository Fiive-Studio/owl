using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Core.Output;
using Fiive.Owl.Core;
using Fiive.Owl.Core.Input;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Formats.Output.XPML;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Formats.Output.Auxiliar;
using System.Threading;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Clase de salida generica
    /// </summary>
    public abstract class GenericOutput : IFormatOutput
    {
        #region Vars

        /// <summary>
        /// Orquestador del proceso
        /// </summary>
        protected OwlHandler _handler;
        /// <summary>
        /// Estructura actual que se esta procesando
        /// </summary>
        protected XmlNode _nodeCurrentStructure;
        /// <summary>
        /// Contador de segmentos
        /// </summary>
        protected int _segmentCount = 0;
        /// <summary>
        /// Estructura que se esta procesando
        /// </summary>
        protected StructureOutput _currentEstructuraOutput;
        /// <summary>
        /// Valor de salida que se esta procesando
        /// </summary>
        protected GenericOutputValue _currentOutputValue;
        /// <summary>
        /// Current Elements list
        /// </summary>
        List<ElementOutput> _currentElements = null;
        /// <summary>
        /// Current Required Elements
        /// </summary>
        Required _currentRequiredElements = null;
        /// <summary>
		/// Seccion de salida
		/// </summary>
        protected string _OutputSection = "owl";
        /// <summary>
        /// Almacena la lista de variables globales creadas para posteriormente poderlas eliminar
        /// </summary>
        protected List<string> _lstGlobalVarsCreated = new List<string>();
        /// <summary>
        /// Almacena la lista de los valores requeridos de una seccion
        /// </summary>
        protected Dictionary<string, string> _lstRequired = null;

        #endregion

        #region Constructor

        public GenericOutput() { XPMLOutputValidator = new XPMLOutputValidator(); }

        #endregion

        #region Properties

        protected XPMLOutputValidator XPMLOutputValidator { get; set; }

        #endregion

        #region ISalida

        /// <summary>
        /// Escribe la salida
        /// </summary>
        /// <param name="handler">Objeto orquestador del proceso</param>
        /// <returns>IEnumerable con los objetos de salida</returns>
        IEnumerable<IOutputValue> IFormatOutput.Write(OwlHandler handler)
        {
            _handler = handler;

            // Si no se asigno estructura de entrada se genera excepcion
            if (!_handler.Settings.Instance && _handler.Input == null) { throw new OwlException(ETexts.GT(ErrorType.IFormatInputIsNull)); }
            return ProcessOutputStructures();
        }

        #endregion

        #region Virtual Core

        /// <summary>
        /// Procesa las estructuras de salida
        /// </summary>
        /// <returns>IEnumerable con los archivos de salida escritos</returns>
        protected virtual IEnumerable<IOutputValue> ProcessOutputStructures()
        {
            // Iteracion por las diferentes estructuras que se configuran
            foreach (XmlNode node in _handler.ConfigMap.GetOutputStructures())
            {
                #region Vars

                _nodeCurrentStructure = node;
                int iteraCount = 1;
                _handler.CurrentValue = _handler.Input;
                _currentEstructuraOutput = GetStructure(node);

                #region Validate Separators

                if (_currentEstructuraOutput.InputDecimalSeparator == char.MinValue) { _currentEstructuraOutput.InputDecimalSeparator = _handler.Settings.InputNumberDecimalSeparator; }
                if (_currentEstructuraOutput.OutputDecimalSeparator == char.MinValue) { _currentEstructuraOutput.OutputDecimalSeparator = _handler.Settings.OutputNumberDecimalSeparator; }

                #endregion

                // Se genera para indicar que inicio una nueva estructura para que las clases que hereden puedan realizar acciones
                StartNewStructure();

                #endregion

                #region Evento nueva estructura

                // Para generar el evento se calcula la cantidad de veces que se va a generar la estrctura, debido a que se puede generar una
                // excepcion si el usuario no configura el Itera en el xml, se controla y se coloca -1, tambien cuando es una instancia se coloca -1
                int countItera = -1;
                try { countItera = !_handler.Settings.Instance ? _handler.Input.Count(_currentEstructuraOutput.Itera) : -1; } catch { }
                LaunchStructureInitiated(_currentEstructuraOutput, countItera); // Genera el evento

                #endregion

                #region Generacion del contenido

                if (_handler.Settings.Instance)
                {
                    _handler["CONSECUTIVE_STRUCTURE"] = iteraCount.ToString();
                    ProcessOutputSections();
                    _currentOutputValue.Insert(0, OpenContent());
                    _currentOutputValue.Append(CloseContent());
                    yield return _currentOutputValue;
                }
                else
                {
                    // Iteracion configurada en la estructura
                    foreach (InputValue inputValue in _handler.Input.GetValues(_currentEstructuraOutput.Itera))
                    {
                        _handler["CONSECUTIVE_STRUCTURE"] = iteraCount.ToString();
                        _handler.CurrentValue = inputValue; // Establece el valor actual

                        ProcessOutputSections();
                        _currentOutputValue.Insert(0, OpenContent());
                        _currentOutputValue.Append(CloseContent());
                        yield return _currentOutputValue; // Se realiza yield return para que el que llame a Owl pueda leer las variables creadas antes de que sean borradas
                        DeleteGlobalVarsCreated();  // Elimina las variables creadas dentro del archivo de configuracion

                        iteraCount++;
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// Procesa las iteraciones de las estructuras de salida
        /// </summary>
        /// <param name="iteraCount">Consecutivo de la iteracion</param>
        /// <returns>Salida</returns>
        protected virtual void ProcessOutputSections()
        {
            StartCounters();         // Start Counters
            _currentOutputValue = new GenericOutputValue();

            foreach (string value in ProcessSection(_handler.ConfigMap.GetOutputSections(_nodeCurrentStructure), null))
            {
                _currentOutputValue.Append(value);
                _currentOutputValue.Append(ExtraInformation());
            }
        }

        /// <summary>
        /// Genera el contenido de las secciones del archivo de salida
        /// </summary>
        /// <param name="nodes">Nodos a procesar</param>
        /// <param name="iteraCount">Consecutivo de iteracion</param>
        /// <param name="elementsValidationParent">Objeto donde se guardan las validaciones de elementos</param>
        protected virtual List<string> ProcessSection(IEnumerable<XmlNode> nodes, SectionOutput parentSection)
        {
            List<string> segmentsReturn = new List<string>();

            foreach (XmlNode nSection in nodes)
            {
                if (parentSection != null) { _handler["CONSECUTIVE_ITERA_PARENT"] = parentSection.Consecutive.ToString(); }
                SectionOutput section = null;

                try
                {
                    #region Vars

                    section = GetSection(nSection);

                    #endregion

                    #region Update global vars for get line and number line

                    if (!_handler.Settings.Instance)
                    {
                        if (!_currentEstructuraOutput.Line.IsNullOrWhiteSpace()) { section.XpahtLine = string.Concat(section.Node, "/", _currentEstructuraOutput.Line).TrimStart('/'); }
                        if (!_currentEstructuraOutput.NumberLine.IsNullOrWhiteSpace()) { section.XpathNumberLine = string.Concat(section.Node, "/", _currentEstructuraOutput.NumberLine).TrimStart('/'); }
                    }

                    #endregion

                    #region Get section count

                    bool launchSectionGroupEvent = false;
                    if (!_handler.Settings.Instance)
                    {
                        if (!section.Itera.IsNullOrWhiteSpace()) { section.Repetitions = _handler.CurrentValue.Count(section.Itera); launchSectionGroupEvent = true; }
                        else if (section.Repetitions > 1) { launchSectionGroupEvent = true; }
                    }

                    #endregion

                    #region Event SectionGroupInitiated

                    // This event is only for Section that have repetitions configurated
                    if (launchSectionGroupEvent) { if (LaunchSectionGroupInitiated(section)) { if (section.CancelWriteSection) { continue; } } }

                    #endregion

                    #region Itera / Repetition

                    // this validation is because when it's an instance always it does 2 repetitions
                    if (_handler.Settings.Instance && !section.Itera.IsNullOrWhiteSpace()) { section.Repetitions = 2; section.Itera = string.Empty; }

                    #region Itera

                    if (!section.Itera.IsNullOrWhiteSpace())
                    {
                        int internalItera = 1;

                        InputValue sectionCurrentValue = _handler.CurrentValue; // This process is to keep the current InputValue because it will be changed in the foreach statment
                        foreach (InputValue valueItera in _handler.CurrentValue.GetValues(section.Itera))
                        {
                            _handler.CurrentValue = valueItera;
                            section.Consecutive = internalItera;

                            #region Line and number line

                            if (!_handler.Settings.Instance)
                            {
                                if (!section.XpahtLine.IsNullOrWhiteSpace()) { section.Line = _handler.CurrentValue.GetValue(section.XpahtLine); }
                                if (!section.XpathNumberLine.IsNullOrWhiteSpace()) { section.NumberLine = _handler.CurrentValue.GetValue(section.XpathNumberLine); }
                            }

                            #endregion

                            List<string> internalSections = ProcessInternalSection(section, nSection);
                            if (internalSections != null && internalSections.Count > 0)
                            {
                                segmentsReturn.AddRange(internalSections);
                                internalItera++;
                            }
                        }
                        _handler.CurrentValue = sectionCurrentValue; // Reset the CurrentValue
                    }

                    #endregion

                    #region Repetition

                    else
                    {
                        int internalItera = 1;
                        #region Line and number line

                        if (!_handler.Settings.Instance)
                        {
                            if (!section.XpahtLine.IsNullOrWhiteSpace()) { section.Line = _handler.CurrentValue.GetValue(section.XpahtLine); }
                            if (!section.XpathNumberLine.IsNullOrWhiteSpace()) { section.NumberLine = _handler.CurrentValue.GetValue(section.XpathNumberLine); }
                        }

                        #endregion

                        for (int i = 1; i <= section.Repetitions; i++)
                        {
                            section.Consecutive = internalItera;
                            List<string> internalSections = ProcessInternalSection(section, nSection);
                            if (internalSections != null && internalSections.Count > 0)
                            {
                                segmentsReturn.AddRange(internalSections);
                                internalItera++;
                            }
                        }
                    }

                    #endregion

                    #endregion
                }
                catch (Exception e)
                {
                    if (e is OwlElementException || e is OwlSectionException) { throw e; }
                    throw new OwlSectionException(ETexts.GT(ErrorType.ErrorOutputSection), nSection.OuterXml, (section == null ? nSection.Name : section.Name), _OutputSection, e);
                }
            }

            return segmentsReturn;
        }

        /// <summary>
        /// Procesa los elementos y las secciones internas de una seccion
        /// </summary>
        /// <param name="parentSection">Seccion padre</param>
        /// <param name="parentNode">Nodo padre</param>
        /// <param name="count">Cantidad de veces que se va a generar la seccion padre</param>
        /// <param name="internalItera">Consecutivo</param>
        /// <param name="lineValue">Contenido linea</param>
        /// <param name="numberLineValue">Numero de linea</param>
        /// <returns></returns>
        protected virtual List<string> ProcessInternalSection(SectionOutput parentSection, XmlNode parentNode)
        {
            List<string> localSegments = new List<string>();

            #region Validate Previous If

            IfSection ifConfiguration = new IfSection(_handler.ConfigMap.GetIfNode(parentNode));
            if (!_handler.Settings.Instance) { if (!ifConfiguration.Validate(_handler, true)) { return null; } }

            #endregion

            #region Initialize values

            int intCountCurrentSection = _segmentCount;

            #endregion

            #region Requireds

            _currentRequiredElements = GetRequired(_handler.ConfigMap.GetRequiredsNode(parentNode), _handler.ConfigMap.GetRequiredsAttribute(parentNode));
            Required requiredGroups = GetRequired(_handler.ConfigMap.GetRequiredsGroupNode(parentNode), _handler.ConfigMap.GetRequiredsGroupAttribute(parentNode));

            #endregion

            #region Elements

            if (_handler.ConfigMap.ValidateIfExistElements(parentNode) || (_handler.Output is XmlOutput || _handler.Output is JsonOutput))
            {
                string returnValue = ProcessElements(parentSection, parentNode);
                if (parentSection.CancelWriteSection) { return null; }

                if (!_currentRequiredElements.Validate())
                {
                    if (intCountCurrentSection != _segmentCount) { _segmentCount = intCountCurrentSection; }
                    StatusCancelSectionProcessed(true);
                    return null;
                }
                else if (returnValue != null) { localSegments.Add(returnValue); }
            }

            #endregion

            #region Sections

            List<string> internalSections = ProcessSection(_handler.ConfigMap.GetOutputSections(parentNode), parentSection);
            if (internalSections.Count > 0) { localSegments.AddRange(internalSections); }

            #endregion

            #region Final Validation

            // Solo se valida si no es una instancia
            if (!_handler.Settings.Instance)
            {
                #region Verificacion Si

                // Condicion para saber si se genera la seccion o no
                if (!ifConfiguration.Validate(_handler, false))
                {
                    if (intCountCurrentSection != _segmentCount) { _segmentCount = intCountCurrentSection; }
                    StatusCancelSectionGroupProcessed(true);
                    return null;
                }

                #endregion

                #region Verificacion Requeridos

                if (requiredGroups.Count >= 1)
                {
                    foreach (string requiredField in requiredGroups.GetRequireds())
                    {
                        string result = localSegments.Find(d => d.StartsWith(requiredField));
                        if (result != null) { requiredGroups.AddValue(requiredField, result); }
                    }
                }

                if (!requiredGroups.Validate())
                {
                    if (intCountCurrentSection != _segmentCount) { _segmentCount = intCountCurrentSection; }
                    StatusCancelSectionGroupProcessed(true);
                    return null;
                }

                #endregion
            }

            #endregion

            #region Add Section Final Information

            {
                string returnValue = CloseSection(parentSection, parentNode);
                if (!returnValue.IsNullOrWhiteSpace()) { localSegments.Add(returnValue); }
            }

            #endregion

            return localSegments;
        }

        /// <summary>
        /// Process the section's elements
        /// </summary>
        /// <param name="section">Seccion</param>
        /// <param name="node">Node</param>
        /// <returns>Contenido de la seccion, si falla alguna validacion null</returns>
        protected string ProcessElements(SectionOutput section, XmlNode node)
        {
            #region Previous validation

            if (LaunchSectionInitiated(section) && section.CancelWriteSection) { return null; }

            #endregion

            #region Initialize values

            int intCountCurrentSection = _segmentCount;
            _currentElements = new List<ElementOutput>();
            _handler["CONSECUTIVE_ITERA"] = section.Consecutive.ToString();
            AddReservedVars();

            #endregion

            string sectionContent = GenerateSection(section, node);

            #region Final Event

            if (section.ShowContent) { section.Content = sectionContent; }
            if (LaunchSectionProcessed(section) & section.CancelWriteSection)
            {
                if (intCountCurrentSection != _segmentCount) { _segmentCount = intCountCurrentSection; }
                StatusCancelSectionProcessed(true);
                return null;
            }

            #endregion

            return sectionContent;
        }

        /// <summary>
        /// Obtiene el valor del elemento a partir de lo que este configurado en el XML
        /// </summary>
        /// <param name="element">Nodo del elemento que se esta procesando</param>
        /// <param name="nElement">Nodo Elemento</param>
        /// <param name="section">Seccion</param>
        public virtual void GetElementValue(ElementOutput element, XmlNode nElement, SectionOutput section)
        {
            if (element == null) { return; }
            element.Value = string.Empty;

            #region Get Value

            try
            {
                IKeyword keyword = _handler.KeywordsManager.GetKeyword(nElement, _handler);
                element.Keyword = keyword;

                // Valor cuando no es una instancia, si keyword es nulo el valor es string.Empty
                if (keyword != null && !_handler.Settings.Instance) { element.Value = keyword.GetValue(_handler); }

                #region Instance

                else if (keyword == null && _handler.Settings.Instance)
                {
                    element.Value = element.DataType == ElementDataType.Numeric ? _handler.KeywordsManager.DefaultNumericInstanceValue : element.Name;
                }
                else if (_handler.Settings.Instance && (keyword.KeywordType == KeywordsType.Variable || keyword.KeywordType == KeywordsType.Key))
                {
                    string value = keyword.GetValue(_handler);
                    // Esta validacion se hace ya que cuando es una Variable o una palabra Reservada puede que no exista
                    if (value == _handler.KeywordsManager.DefaultAlphanumericInstanceValue)
                    {
                        if (element.DataType == ElementDataType.Numeric) { element.Value = _handler.KeywordsManager.DefaultNumericInstanceValue; }
                        else { element.Value = element.Name; }
                    }
                    else { element.Value = value; }
                }
                else if (_handler.Settings.Instance) { element.Value = keyword.GetValue(_handler); }

                #endregion
            }
            catch (Exception e)
            {
                throw new OwlElementException(ETexts.GT(ErrorType.ErrorOutputElement), nElement.OuterXml, nElement.Name, _OutputSection, e);
            }

            #endregion

            #region Validacion Linea y Numero Linea

            if (!_handler.Settings.Instance)
            {
                if (!element.Node.IsNullOrWhiteSpace())
                {
                    if (!section.XpahtLine.IsNullOrWhiteSpace())
                    {
                        string[] parts = section.XpahtLine.Split('/');
                        string xpathLine = element.Node + "/" + (parts.Length == 2 ? parts[1] : parts[0]);
                        element.Line = _handler.CurrentValue.GetValue(xpathLine);
                    }

                    if (!section.XpathNumberLine.IsNullOrWhiteSpace())
                    {
                        string[] partes = section.XpathNumberLine.Split('/');
                        string xpathNumberLine = element.Node + "/" + (partes.Length == 2 ? partes[1] : partes[0]);
                        element.NumberLine = _handler.CurrentValue.GetValue(xpathNumberLine);
                    }
                }
                else
                {
                    element.Line = section.Line;
                    element.NumberLine = section.NumberLine;
                }
            }

            #endregion

            #region Validate Data

            if (element.InputDecimalSeparator == char.MinValue) { element.InputDecimalSeparator = _currentEstructuraOutput.InputDecimalSeparator; }
            if (element.OutputDecimalSeparator == char.MinValue) { element.OutputDecimalSeparator = _currentEstructuraOutput.OutputDecimalSeparator; }

            #endregion

            #region Event

            if (LaunchElementProcessed(element, section)) { if (element.ElementWithError) { element.Value = string.Empty; return; } }

            #endregion

            #region Atributos salida

            ProcessElementValidators(element, nElement);

            #endregion

            #region Validate Section Event

            if (!element.EventSection.HasValue) { element.EventSection = _currentEstructuraOutput.EventElementSection; }
            if (element.EventSection.Value) { _currentElements.Add(element); }

            #endregion

            #region Global Vars

            if (!element.NewVariable.IsNullOrWhiteSpace())
            {
                _handler[element.NewVariable] = element.Value;
                if (!_lstGlobalVarsCreated.Contains(element.NewVariable)) { _lstGlobalVarsCreated.Add(element.NewVariable); }
            }

            #endregion

            #region Contador

            // Solo se crean los contadores si no es una instancia
            if (!_handler.Settings.Instance)
            {
                if (!element.Counter.IsNullOrWhiteSpace())
                {
                    #region Valida Sintaxis

                    string[] parameters = element.Counter.Split('/');

                    // Sintaxis contador: Nombre/Incremento
                    if (parameters.Length != 2)
                    {
                        throw new OwlElementException(string.Format(ETexts.GT(ErrorType.ContadorCountParametersNotValid), element.Counter, parameters.Length), nElement.OuterXml, element.Name, _OutputSection);
                    }

                    #endregion

                    #region Validate Variable

                    if (parameters.GetSafeValue(0).IsNullOrWhiteSpace())
                    {
                        throw new OwlElementException(string.Format(ETexts.GT(ErrorType.ContadorEmptyParameter), "1", element.Counter), nElement.OuterXml, element.Name, _OutputSection);
                    }

                    #endregion

                    #region Update Value

                    #region Incremento

                    string valor;
                    if (parameters.GetSafeValue(1) == "CurrentValue") { valor = element.Value; }
                    else { valor = parameters.GetSafeValue(1); }

                    if (!valor.IsDecimal())
                    {
                        throw new OwlElementException(string.Format(ETexts.GT(ErrorType.ContadorParameterIsForNumbers), "2", element.Counter, valor), nElement.OuterXml, element.Name, _OutputSection);
                    }

                    decimal valorIncremento = Convert.ToDecimal(valor);

                    #endregion

                    decimal nuevoValor;
                    if (_handler.ExistVariable(parameters.GetSafeValue(0)))
                    {
                        if (!_handler[parameters.GetSafeValue(0)].IsDecimal())
                        {
                            throw new OwlElementException(string.Format(ETexts.GT(ErrorType.ContadorVariableModified), parameters.GetSafeValue(0), _handler[parameters.GetSafeValue(0)], element.Counter), nElement.OuterXml, element.Name, _OutputSection);
                        }

                        // Si la variable ya existe se incrementa
                        nuevoValor = Convert.ToDecimal(_handler[parameters.GetSafeValue(0)]) + valorIncremento;
                    }
                    else { nuevoValor = valorIncremento; }

                    _handler[parameters.GetSafeValue(0)] = nuevoValor.ToString();

                    #endregion
                }
            }

            #endregion

            #region Requeridos

            _currentRequiredElements.AddValue(element.Name, element.Value);

            #endregion
        }

        /// <summary>
        /// Procesa la configuracion que genera validacion adicional
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="nElement">Nodo que representa el elemento</param>
        protected virtual void ProcessElementValidators(ElementOutput element, XmlNode nElement)
        {
            bool validateSeparator = false;

            #region Formato

            if (!element.Value.IsNullOrWhiteSpace() && !element.Format.IsNullOrWhiteSpace())
            {
                string[] formats = element.Format.Split(new string[] { "|" }, StringSplitOptions.None);

                foreach (string format in formats)
                {
                    #region Number

                    if (format.StartsWith("#"))
                    {
                        if (!_handler.Settings.Instance)
                        {
                            #region Cambiar separador

                            // Se hace el cambio para poder hacer la validacion, ya que podria llegar a fallar con un separador propio
                            string tempValue = element.Value.Replace(element.InputDecimalSeparator, Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);

                            if (!tempValue.IsDecimal())
                            {
                                throw new OwlElementException(string.Format(ETexts.GT(ErrorType.FormatIsForNumbers), element.Value, format), nElement.OuterXml, element.Name, _OutputSection);
                            }

                            #endregion

                            decimal numero = Convert.ToDecimal(tempValue);
                            element.Value = numero.ToString(format.GetSafeSubstring(1)).Replace(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0], element.InputDecimalSeparator);
                            validateSeparator = true;
                        }
                    }

                    #endregion

                    #region Text

                    else
                    {
                        switch (format)
                        {
                            case "A":
                                element.Value = element.Value.ToUpper();
                                break;
                            case "a":
                                element.Value = element.Value.ToLower();
                                break;
                            case "C":
                                element.Value = string.Concat(element.Value[0].ToString().ToUpper(), element.Value.GetSafeSubstring(1).ToLower());
                                break;
                            case "T":
                                element.Value = element.Value.Trim();
                                break;
                            case "TS":
                                element.Value = element.Value.TrimStart();
                                break;
                            case "TE":
                                element.Value = element.Value.TrimEnd();
                                break;
                            default:
                                throw new OwlElementException(string.Format(ETexts.GT(ErrorType.FormatNotValid), format), nElement.OuterXml, element.Name, _OutputSection);
                        }
                    }

                    #endregion
                }
            }

            #endregion

            #region Longitud

            if (element.Length != null)
            {
                #region Validacion para instancia

                // Se valida ya que cuando es una instancia no se procesan longitudes decimales
                if (_handler.Settings.Instance && element.Length.ValidateDecimalPart)
                {
                    element.DataType = ElementDataType.Alphanumeric;
                    element.Length.IntegerPart = element.Length.IntegerPart + 1 + element.Length.DecimalPart;
                    element.Length.ValidateDecimalPart = false;
                }

                #endregion

                #region Numeric Validation

                if (element.DataType == ElementDataType.Numeric && !element.Length.ValidateDecimalPart)
                {
                    element.Length.ValidateDecimalPart = true;
                    element.Length.DecimalPart = 0;
                }

                #endregion

                #region Validacion cuando solo hay parte entera

                if (!element.Length.ValidateDecimalPart)
                {
                    // Si parte entera es menor a 0 es decir que se envia toda la cadena
                    if (element.Length.IntegerPart >= 0)
                    {
                        if (!string.IsNullOrEmpty(element.Value) || (string.IsNullOrEmpty(element.Value) && element.Length.PaddingWhenIsEmpty == FieldLength.Padding.Pad))
                        {
                            element.Value = element.Value.GetSafeSubstring(0, element.Length.IntegerPart);
                            if (element.Length.Aligment == FieldLength.AligmentType.Right) { element.Value = element.Value.PadLeft(element.Length.IntegerPart, element.Length.PaddingChar); }
                            else if (element.Length.Aligment == FieldLength.AligmentType.Left) { element.Value = element.Value.PadRight(element.Length.IntegerPart, element.Length.PaddingChar); }
                        }
                    }
                }

                #endregion

                #region Validacion cuando hay parte decimal

                else
                {
                    bool validateLength = true;
                    string finalValue = string.Empty, parteEntera = string.Empty, parteDecimal = string.Empty;

                    if (!string.IsNullOrEmpty(element.Value))
                    {
                        #region Valida el numero

                        // Se hace el cambio para poder hacer la validacion, ya que podria llegar a fallar con un separador propio
                        string tempValue = element.Value.Replace(element.InputDecimalSeparator, Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);

                        if (!tempValue.IsDecimal())
                        {
                            throw new OwlElementException(string.Format(ETexts.GT(ErrorType.LengthIsForNumbers), element.Value), nElement.OuterXml, element.Name, _OutputSection);
                        }

                        #endregion

                        #region Obtener partes numero

                        decimal numero = Convert.ToDecimal(tempValue);
                        parteEntera = Math.Truncate(numero).ToString();
                        parteDecimal = string.Empty;

                        // Proceso para obtener la parte decimal
                        int indexDecimal = numero.ToString().IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        if (indexDecimal != -1)
                        {
                            indexDecimal++;
                            parteDecimal = numero.ToString().GetSafeSubstring(indexDecimal);
                        }

                        // Esta validación se hace ya que cuando vienen numero negativos que iniciaban con "0." se borraba el menos (ejemplo: -0.54)
                        if (tempValue.StartsWith("-") && !parteEntera.StartsWith("-")) { parteEntera = "-" + parteEntera; }

                        #endregion

                        #region Procesar partes numero

                        // Se formatean con las longitudes
                        if (element.Length.IntegerPart >= 0) { parteEntera = parteEntera.GetSafeSubstring(parteEntera.Length - element.Length.IntegerPart); }
                        else { validateLength = false; }
                        if (element.Length.DecimalPart >= 0) { parteDecimal = parteDecimal.GetSafeSubstring(0, element.Length.DecimalPart); }
                        else { validateLength = false; }

                        finalValue = parteEntera;
                        if (!parteDecimal.IsNullOrWhiteSpace())
                        {
                            if (string.IsNullOrEmpty(parteEntera)) { finalValue += parteDecimal; }
                            else { finalValue += element.OutputDecimalSeparator + parteDecimal; }
                            validateSeparator = false;
                        }

                        #endregion
                    }

                    #region Validacion de alineacion

                    if (validateLength)
                    {
                        if (!string.IsNullOrEmpty(element.Value) || (string.IsNullOrEmpty(element.Value) && element.Length.PaddingWhenIsEmpty != FieldLength.Padding.NotPad))
                        {
                            int longitudFinal = 0;
                            if (element.Length.IntegerPart > 0) { longitudFinal += element.Length.IntegerPart; }
                            if (element.Length.DecimalPart > 0)
                            {
                                if (longitudFinal > 0) { longitudFinal++; } // 1 is then decimal separator character
                                longitudFinal += element.Length.DecimalPart;
                            }

                            if (element.Length.Aligment == FieldLength.AligmentType.Right) { finalValue = finalValue.PadLeft(longitudFinal, element.Length.PaddingChar); }
                            else if (element.Length.Aligment == FieldLength.AligmentType.Left) { finalValue = finalValue.PadRight(longitudFinal, element.Length.PaddingChar); }
                            else if (element.Length.Aligment == FieldLength.AligmentType.Number || element.Length.Aligment == FieldLength.AligmentType.NumberWithoutSeparator)
                            {
                                parteEntera = parteEntera.PadLeft(element.Length.IntegerPart, element.Length.PaddingChar);
                                char padDecimal = element.Length.PaddingCharDecimalPart == char.MinValue ? element.Length.PaddingChar : element.Length.PaddingCharDecimalPart;
                                parteDecimal = parteDecimal.PadRight(element.Length.DecimalPart, padDecimal);

                                if (element.Length.Aligment == FieldLength.AligmentType.Number)
                                {
                                    // If the length is 0,0 return string.empty
                                    if ((element.Length.IntegerPart + element.Length.DecimalPart) == 0) { finalValue = string.Empty; }
                                    else
                                    {
                                        // When the Value is empty and the padding is PadWithoutSeparator, put space instead of decimal separator
                                        if (string.IsNullOrEmpty(element.Value) && element.Length.PaddingWhenIsEmpty == FieldLength.Padding.PadWithoutSeparator)
                                        {
                                            if (element.Length.IntegerPart == 0) { finalValue = parteDecimal; }
                                            else if (element.Length.DecimalPart == 0) { finalValue = parteEntera; }
                                            else { finalValue = string.Concat(parteEntera, element.Length.PaddingChar, parteDecimal); }
                                        }
                                        else
                                        {
                                            if (element.Length.IntegerPart == 0) { finalValue = parteDecimal; }
                                            else if (element.Length.DecimalPart == 0) { finalValue = parteEntera; }
                                            else { finalValue = string.Concat(parteEntera, element.OutputDecimalSeparator, parteDecimal); }
                                        }
                                    }
                                }
                                else { finalValue = string.Concat(parteEntera, parteDecimal); }
                            }
                        }
                    }

                    element.Value = finalValue;

                    #endregion
                }

                #endregion
            }

            #endregion

            #region Valida Separador de decimales

            if (validateSeparator) { element.Value = element.Value.Replace(element.InputDecimalSeparator, element.OutputDecimalSeparator); }

            #endregion
        }

        #endregion 

        #region Virtual Without Logic

        /// <summary>
        /// Se ejecuta cuando se inicia una nueva estructura
        /// </summary>
        protected virtual void StartNewStructure() { }

        /// <summary>
        /// Agrega contadores de la salida
        /// </summary>
        protected virtual void StartOutputCounters() { }

        /// <summary>
        /// Informacion adicional que agregue la estructura de salida en una seccion
        /// </summary>
        /// <returns>Informacion adicional</returns>
        protected virtual string ExtraInformation() { return string.Empty; }

        /// <summary>
        /// Contenido adicional para agregar al inicio del valor a retornar
        /// </summary>
        /// <returns>Contenido</returns>
        protected virtual string OpenContent() { return string.Empty; }

        /// <summary>
        /// Contenido adicional para agregar al final del valor a retornar
        /// </summary>
        /// <returns>Contenido</returns>
        protected virtual string CloseContent() { return string.Empty; }

        /// <summary>
        /// Agrega el valor de una palabra reservada de la estructura de salida
        /// </summary>
        protected virtual void AddReservedVarsOutput() { }

        /// <summary>
		/// Indica que la escritura de la seccion fue cancelada despues de ser capturada en un evento
		/// </summary>
		/// <param name="cancelado">true fue cancelado, de lo contrario false</param>
		protected virtual void StatusCancelSectionProcessed(bool cancelado) { }

        /// <summary>
		/// Indica la escritura de la seccion grupo fue cancelada despues de ser capturada en un evento
		/// </summary>
		/// <param name="cancelado">true fue cancelado, de lo contrario false</param>
		protected virtual void StatusCancelSectionGroupProcessed(bool cancelado) { }

        /// <summary>
        /// Get the structure object
        /// </summary>
        /// <param name="node">Configuration Node</param>
        /// <returns>Object</returns>
        protected virtual StructureOutput GetStructure(XmlNode node) { return (StructureOutput)_handler.XPMLValidator.GetXPMLObject(new StructureOutput(), node, _handler); }

        /// <summary>
        /// Get the section object
        /// </summary>
        /// <param name="node">Configuration Node</param>
        /// <returns>Object</returns>
        protected virtual SectionOutput GetSection(XmlNode node) { return (SectionOutput)_handler.XPMLValidator.GetXPMLObject(new SectionOutput(), node, _handler); }

        /// <summary>
        /// Termina la seccion
        /// </summary>
        /// <param name="section">Objeto con configuracion de la seccion</param>
        /// <param name="node">Nodo que se esta procesando</param>
        /// <returns>Contenido que cierra la seccion</returns>
        protected virtual string CloseSection(SectionOutput section, XmlNode node) { return string.Empty; }

        #endregion

        #region Abstracts

        /// <summary>
        /// Recorre el segmento actual para obtener los valores de los elementos
        /// </summary>
        /// <param name="section">Objeto con configuracion de la seccion</param>
        /// <param name="node">Nodo que se esta procesando</param>
        /// <returns>Contenido de la seccion</returns>
        protected abstract string GenerateSection(SectionOutput section, XmlNode node);

        #endregion

        #region Protected

        /// <summary>
        /// Agrega contadores de la salida
        /// </summary>
        protected void StartCounters()
        {
            _segmentCount = 0;
            StartOutputCounters();
        }

        /// <summary>
        /// Quita las variables globales que se crearon en la salida
        /// </summary>
        protected void DeleteGlobalVarsCreated()
        {
            foreach (string key in _lstGlobalVarsCreated) { _handler.RemoveVariable(key); }
            _lstGlobalVarsCreated.Clear();
        }

        /// <summary>
        /// Agrega el valor de una palabra reservada de la estructura de salida
        /// </summary>
        protected void AddReservedVars()
        {
            _handler["TOTAL_SEGMENTS"] = _segmentCount.ToString();
            AddReservedVarsOutput();
        }

        #endregion

        #region Privates

        /// <summary>
        /// Get the Required
        /// </summary>
        /// <param name="nRequireds">Nodo</param>
        /// <param name="requireds">Attribute</param>
        /// <returns>Required object</returns>
        Required GetRequired(XmlNode nRequireds, string requireds)
        {
            Required.RequiredType rType = Required.RequiredType.Node;
            if (nRequireds == null) { rType = Required.RequiredType.Attribute; }

            Required required = new Required(rType);
            if (rType == Required.RequiredType.Node) { required.AddRequireds(nRequireds); }
            else if (rType == Required.RequiredType.Attribute) { required.AddRequireds(requireds); }

            return required;
        }

        #endregion

        #region Events

        /// <summary>
        /// Evento que se produce cuando se inicia a procesar una nueva estructura
        /// </summary>
        public event EventHandler<OutputStructureEventArgs> StructureInitiated;

        /// <summary>
        /// Evento que se produce cuando se va a iniciar a procesar una seccion que tiene repeticiones
        /// </summary>
        public event EventHandler<OutputSectionEventArgs> SectionGroupInitiated;

        /// <summary>
        /// Evento que se produce cuando se va a iniciar a procesar una seccion
        /// </summary>
        public event EventHandler<OutputSectionEventArgs> SectionInitiated;

        /// <summary>
        /// Evento que se produce cuando se termina de cargar una seccion
        /// </summary>
        public event EventHandler<OutputSectionEventArgs> SectionProcessed;

        /// <summary>
        /// Evento que se produce cuando se procesa un elemento alfanumerico
        /// </summary>
        public event EventHandler<OutputElementEventArgs> AlphanumericElementProcessed;

        /// <summary>
        /// Evento que se produce cuando se procesa un elemento Numerico
        /// </summary>
        public event EventHandler<OutputElementEventArgs> NumericElementProcessed;

        /// <summary>
        /// Lanza el evento StructureInitiated
        /// </summary>
        /// <param name="structure">Configuracion XPML</param>
        /// <param name="count">Cantidad de veces que se repite</param>
        /// <returns>true si se lanza el evento, de lo contrario false</returns>
        protected bool LaunchStructureInitiated(StructureOutput structure, int count)
        {
            if (StructureInitiated != null)
            {
                StructureInitiated(this, new OutputStructureEventArgs(count) { XPMLConfig = structure });
                return true;
            }

            return false;
        }

        /// <summary>
        /// Lanza el evento SectionGroupInitiated
        /// </summary>
        /// <param name="section">Seccion que lanza el evento</param>
        /// <param name="count">Cantidad de veces que se va a realizar la iteracion</param>
        /// <param name="consecutive">Numero de iteracion de la seccion padre</param>
        protected bool LaunchSectionGroupInitiated(SectionOutput section)
        {
            if (SectionGroupInitiated != null)
            {
                bool launchEvent;
                if (section.EventGroup.HasValue) { launchEvent = section.EventGroup.Value; } else { launchEvent = _currentEstructuraOutput.EventSectionGroup; }
                if (!_handler.Settings.Instance && launchEvent)
                {
                    SectionGroupInitiated(this, new OutputSectionEventArgs() { XPMLConfig = section });
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Lanza el evento SectionGroupInitiated
        /// </summary>
        /// <param name="section">Seccion que lanza el evento</param>
        /// <param name="count">Cantidad de veces que se va a realizar la iteracion</param>
        /// <param name="consecutive">Numero de iteracion de la seccion padre</param>
        protected bool LaunchSectionInitiated(SectionOutput section)
        {
            if (SectionInitiated != null)
            {
                bool launchEvent;
                if (section.EventPrevious.HasValue) { launchEvent = section.EventPrevious.Value; } else { launchEvent = _currentEstructuraOutput.EventSectionPrevious; }
                if (!_handler.Settings.Instance && launchEvent)
                {
                    SectionInitiated(this, new OutputSectionEventArgs() { XPMLConfig = section });
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Lanza el evento SeccionProcesada
        /// </summary>
        /// <param name="seccion">Seccion que lanza el evento</param>
        /// <param name="consecutivo">Numero de iteracion de la seccion</param>
        /// <param name="linea">Linea de donde se obtiene la seccion</param>
        /// <param name="numeroLinea">Numero de la linea de donde se obtiene la seccion</param>
        /// <param name="descripcion">Descripcion adicional de la seccion</param>
        /// <param name="id">Id de la seccion</param>
        /// <returns>true si se lanza el evento, de lo contrario false</returns>
        protected bool LaunchSectionProcessed(SectionOutput section)
        {
            if (SectionProcessed != null)
            {
                bool launchEvent;
                if (section.Event.HasValue) { launchEvent = section.Event.Value; } else { launchEvent = _currentEstructuraOutput.EventSection; }
                if (!_handler.Settings.Instance && launchEvent)
                {
                    section.Elements = _currentElements;
                    SectionProcessed(this, new OutputSectionEventArgs() { XPMLConfig = section });
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Lanza el evento ElementoAlfanumericoProcesado o ElementoNumericoProcesado
        /// </summary>
        /// <param name="element">Elemento</param>
        /// <param name="section">Seccion</param>
        /// <returns>true si se lanza el evento, de lo contrario false</returns>
        protected bool LaunchElementProcessed(ElementOutput element, SectionOutput section)
        {
            bool launchEvent;
            if (element.Event.HasValue) { launchEvent = element.Event.Value; } else { launchEvent = _currentEstructuraOutput.EventElement; }

            if (!_handler.Settings.Instance && launchEvent)
            {
                if (element.DataType == ElementDataType.Alphanumeric && AlphanumericElementProcessed != null)
                {
                    AlphanumericElementProcessed(this, new OutputElementEventArgs() { XPMLConfig = element, Section = section });
                    return true;
                }
                else if (element.DataType == ElementDataType.Numeric && NumericElementProcessed != null)
                {
                    NumericElementProcessed(this, new OutputElementEventArgs() { XPMLConfig = element, Section = section });
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
