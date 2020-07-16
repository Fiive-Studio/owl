using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Fiive.Owl.Core.Exceptions;
using System.Xml;
using Fiive.Owl.Core.Input;
using System.Data;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
using System.Xml.XPath;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Core
{
    /// <summary>
    /// Configuracion Xml
    /// </summary>
    public class OwlConfigMap
    {
        #region Vars

        /// <summary>
        /// Settings
        /// </summary>
        OwlSettings _settings;

        /// <summary>
        /// XML de configuracion principal
        /// </summary>
        XmlDocument _xmlConfig = null, _xmlConfigBase = null;

        #endregion

        #region XPath

        readonly string _xpathOutputStructures = "/Configuracion/Documento/Salida/Estructura";
        readonly string _xpathOutputBaseStructure = "/Configuracion/Documento/Salida/Estructura[@Id='{0}']";
        readonly string _xpathOutputNoBaseStructure = "/Configuracion/Documento/Salida/Estructura[not(@Id='{0}')]";
        readonly string _xpathXPMLStructure = "*[starts-with(name(), 'Estructura.')]";
        readonly string _xpathXPMLSection = "*[starts-with(name(), 'Seccion.')]";
        readonly string _xpathXPMLElement = "*[starts-with(name(), 'Elemento.')]";
        readonly string _xpathSections = "Seccion";
        readonly string _xpathElements = "Elemento";
        readonly string _xpathSingleElement = "Elemento[@Nombre='{0}']";
        readonly string _xpathHiddenElements = "Elemento[@Oculto='Si']";
        readonly string _xpathNotHiddenElements = "Elemento[(@Oculto='No') or not(@Oculto='Si')]";
        readonly string _xpathValidateElements = "count(Elemento)";
        readonly string _xpathRequiredsNode = "Seccion.Requeridos";
        readonly string _xpathRequiredsGroupNode = "Seccion.RequeridosGrupo";
        readonly string _xpathIfNode = "Seccion.Si";
        readonly string _xpathRequiredsAttribute = "Requeridos";
        readonly string _xpathRequiredsGroupAttribute = "RequeridosGrupo";
        readonly string _xpathConditionNode = "Condicion";
        readonly string _xpathElementValue = "Elemento.Valor";

        #endregion

        #region Constructor

        public OwlConfigMap(OwlSettings settings) { _settings = settings; }

        #endregion

        #region Publics

        /// <summary>
        /// Carga los archivos de configuracion, se debe llamar de primero
        /// </summary>
        public void LoadConfigMap() { LoadConfigMap(false); }

        /// <summary>
        /// Carga los archivos de configuracion, se debe llamar de primero
        /// </summary>
        /// <param name="instance">true si se va a utilizar para generar una instancia, de lo contrario false</param>
        /// <exception cref="OwlException">Error al cargar el archivo de Configuracion Xml</exception>
        public void LoadConfigMap(bool instance)
        {
            if (_settings.XmlConfig == null)
            {
                try
                {
                    _xmlConfig = new XmlDocument();
                    _xmlConfig.Load(_settings.PathConfig);
                }
                catch (Exception e) { throw new OwlException(ETexts.GT(ErrorType.ErrorLoadConfigMap), e); }
            }
            else { _xmlConfig = _settings.XmlConfig; }

            if (_settings.XmlConfigBase != null) { _xmlConfigBase = _settings.XmlConfigBase; }
            else if (!_settings.PathConfigBase.IsNullOrWhiteSpace())
            {
                try
                {
                    _xmlConfigBase = new XmlDocument();
                    _xmlConfigBase.Load(_settings.PathConfigBase);
                }
                catch (Exception e) { throw new OwlException(ETexts.GT(ErrorType.ErrorLoadConfigMapBase), e); }
            }

            if (_xmlConfigBase != null) { ValidateAndLoadBaseConfiguration(); }
        }

        #endregion

        #region IFormatOutput

        /// <summary>
		/// Retorna las estructuras de salida configuradas
		/// </summary>
		/// <returns>IEnumerable con las estructuras</returns>
		public IEnumerable<XmlNode> GetOutputStructures()
        {
            foreach (XmlNode nodo in _xmlConfig.SelectNodes(_xpathOutputStructures)) { yield return nodo; }
        }

        /// <summary>
        /// Obtiene las secciones de la estructura de salida
        /// </summary>
        /// <param name="nodo">Estructura para obtener secciones</param>
        /// <returns>IEnumerable con el nodo de la seccion</returns>
        public IEnumerable<XmlNode> GetOutputSections(XmlNode nodo)
        {
            foreach (XmlNode nNodo in nodo.SelectNodes(_xpathSections)) { yield return nNodo; }
        }

        /// <summary>
        /// Valida si la seccion tiene algun elemento
        /// </summary>
        /// <param name="node">Seccion para obtener los elementos</param>
        /// <returns>true si existen Elementos, de lo contrario false</returns>
        public bool ValidateIfExistElements(XmlNode node)
        {
            XPathNavigator nav = node.CreateNavigator();
            int result = Convert.ToInt32(nav.Evaluate(_xpathValidateElements));
            return result > 0 ? true : false;
        }

        /// <summary>
        /// Obtiene los elementos de la seccion de salida
        /// </summary>
        /// <param name="nodo">Seccion para obtener los elementos</param>
        /// <returns>IEnumerable con el nodo del elemento</returns>
        public IEnumerable<XmlNode> GetOutputElements(XmlNode nodo)
        {
            foreach (XmlNode nNodo in nodo.SelectNodes(_xpathElements)) { yield return nNodo; }
        }

        /// <summary>
        /// Obtiene el nodo de la seccion de salida
        /// </summary>
        /// <param name="nodo">Seccion para obtener el elemento</param>
        /// <param name="name">Nombre del elemento</param>
        /// <returns>Nodo del elemento</returns>
        public XmlNode GetOutputElement(XmlNode nodo, string name) { return nodo.SelectSingleNode(string.Format(_xpathSingleElement, name)); }

        /// <summary>
        /// Obtiene los elementos ocultos de la seccion de salida
        /// </summary>
        /// <param name="nodo">Seccion para obtener los elementos</param>
        /// <returns>IEnumerable con el nodo del elemento</returns>
        public IEnumerable<XmlNode> GetNotHiddenOutputElements(XmlNode nodo)
        {
            foreach (XmlNode nNodo in nodo.SelectNodes(_xpathNotHiddenElements)) { yield return nNodo; }
        }

        /// <summary>
        /// Obtiene los elementos ocultos de la seccion de salida
        /// </summary>
        /// <param name="nodo">Seccion para obtener los elementos</param>
        /// <returns>IEnumerable con el nodo del elemento</returns>
        public IEnumerable<XmlNode> GetHiddenOutputElements(XmlNode nodo)
        {
            foreach (XmlNode nNodo in nodo.SelectNodes(_xpathHiddenElements)) { yield return nNodo; }
        }

        /// <summary>
        /// Get the Requireds Node
        /// </summary>
        /// <param name="nodo">Seccion</param>
        /// <returns>Node</returns>
        public XmlNode GetRequiredsNode(XmlNode node) { return node.SelectSingleNode(_xpathRequiredsNode); }

        /// <summary>
        /// Get the Requireds Group Node
        /// </summary>
        /// <param name="nodo">Seccion</param>
        /// <returns>Node</returns>
        public XmlNode GetRequiredsGroupNode(XmlNode node) { return node.SelectSingleNode(_xpathRequiredsGroupNode); }

        /// <summary>
        /// Get the Requireds Attribute
        /// </summary>
        /// <param name="nodo">Seccion</param>
        /// <returns>Value</returns>
        public string GetRequiredsAttribute(XmlNode node)
        {
            XmlAttribute attr = node.Attributes[_xpathRequiredsAttribute];
            return attr != null ? attr.Value : string.Empty;
        }

        /// <summary>
        /// Get the Requireds Group Attribute
        /// </summary>
        /// <param name="nodo">Seccion</param>
        /// <returns>Value</returns>
        public string GetRequiredsGroupAttribute(XmlNode node)
        {
            XmlAttribute attr = node.Attributes[_xpathRequiredsGroupAttribute];
            return attr != null ? attr.Value : string.Empty;
        }

        /// <summary>
        /// Get the Requireds Node
        /// </summary>
        /// <param name="nodo">Seccion</param>
        /// <returns>Node</returns>
        public XmlNode GetIfNode(XmlNode node) { return node.SelectSingleNode(_xpathIfNode); }

        /// <summary>
        /// Get the Condition Node
        /// </summary>
        /// <param name="nodo">Seccion</param>
        /// <returns>Node</returns>
        public XmlNodeList GetConditionNode(XmlNode node) { return node.SelectNodes(_xpathConditionNode); }

        /// <summary>
        /// Get the Requireds Node
        /// </summary>
        /// <param name="nodo">Element</param>
        /// <returns>Node</returns>
        public XmlNode GetElementValueNode(XmlNode node) { return node.SelectSingleNode(_xpathElementValue); }

        #endregion

        #region Inheritance

        /// <summary>
		/// Valida las configuraciones para verificar si hereda
		/// </summary>
		private void ValidateAndLoadBaseConfiguration()
        {
            foreach (XmlNode nStructureChild in GetOutputStructures())
            {
                string idConfigBase = GetAttributeValue("Base", nStructureChild);

                // Si la estructura tiene configuracion base se carga
                if (!idConfigBase.IsNullOrWhiteSpace())
                {
                    #region Cargar config base

                    // Valida si existe el nodo base
                    XmlNode nStructureBase = _xmlConfigBase.SelectSingleNode(string.Format(_xpathOutputBaseStructure, idConfigBase));
                    if (nStructureBase == null) { throw new OwlException(string.Format(ETexts.GT(ErrorType.ErrorConfigBaseDoesNotExist), idConfigBase)); }

                    #endregion

                    #region Procesa estructura

                    // Procesa las configuraciones para unirlas
                    ProcessAttributes(nStructureBase, nStructureChild, "Id", "Base");
                    ProcessSections(nStructureChild.SelectNodes(_xpathSections), string.Format(_xpathOutputBaseStructure, idConfigBase));
                    ProcessXPMLConfiguration(nStructureChild.SelectNodes(_xpathXPMLStructure), nStructureBase);

                    // Se borran las demas estructuras que estan en el config base para que solo quede la que heredo
                    XmlNodeList nEstructuras = _xmlConfig.SelectNodes(string.Format(_xpathOutputNoBaseStructure, idConfigBase));
                    foreach (XmlNode nEstructura in nEstructuras) { nEstructura.ParentNode.RemoveChild(nEstructura); }

                    #endregion

                    _xmlConfig = _xmlConfigBase;
                }

                break;
            }
        }

        /// <summary>
        /// Actualiza los atributos hijos en la base
        /// </summary>
        /// <param name="nBase">Nodo Base</param>
        /// <param name="nChild">Nodo Hijo</param>
        /// <param name="restricted">Atributos que no se pueden actualizar</param>
        private void ProcessAttributes(XmlNode nBase, XmlNode nChild, params string[] restricted)
        {
            foreach (XmlAttribute attribute in nChild.Attributes)
            {
                // Valida si es un atributo que no se puede cambiar
                if (restricted.Contains(attribute.Name)) { continue; }

                if (nBase.Attributes[attribute.Name] == null)
                {
                    // Si no existe el atributo lo crea
                    XmlAttribute newAttribute = nBase.OwnerDocument.CreateAttribute(attribute.Name);
                    newAttribute.Value = attribute.Value;
                    nBase.Attributes.Append(newAttribute);
                }
                // Si ya existe lo actualiza
                else { nBase.Attributes[attribute.Name].Value = attribute.Value; }
            }
        }

        /// <summary>
        /// Procesa la configuracion hija
        /// </summary>
        /// <param name="nChildNodes">Lista de nodos</param>
        /// <param name="xpath">Xpath</param>
        private void ProcessSections(XmlNodeList nChildNodes, string xpath)
        {
            string xpathSection = string.Empty;
            foreach (XmlNode nChildNode in nChildNodes)
            {
                #region Vars

                InheritancePosition ubicacion;
                bool overrideSection = false;
                string strAttribute;
                string overrideValue = GetAttributeValue("Sobreescribir", nChildNode);
                if (overrideValue == "Si") { overrideSection = true; }

                #endregion

                #region Procesa Xpath

                XmlAttribute idSeccion = nChildNode.Attributes["Id"];
                if (idSeccion == null)
                {
                    string nombre = nChildNode.Attributes["Nombre"] != null ? nChildNode.Attributes["Nombre"].Value : string.Empty;
                    xpathSection = string.Concat(xpath, string.Format("/Seccion[@Nombre='{0}']", nombre));
                }
                else { xpathSection = string.Concat(xpath, string.Format("/Seccion[@Id='{0}']", idSeccion.Value)); }

                #endregion

                GetInheritanceUbication(nChildNode, out ubicacion, out strAttribute);

                if (overrideSection || !ExistsNode(xpathSection))
                {
                    ProcessNode(xpathSection, nChildNode, ubicacion, strAttribute, ConfigTagType.Section);
                }
                else
                {
                    XmlNode nBase = _xmlConfigBase.SelectSingleNode(xpathSection);
                    ProcessAttributes(nBase, nChildNode, "Nombre", "Id", "Sobreescribir", "AntesDe", "DespuesDe");
                    ProcessUbications(xpathSection, ubicacion, strAttribute, ConfigTagType.Section);
                    ProcessXPMLConfiguration(nChildNode.SelectNodes(_xpathXPMLSection), nBase);

                    ProcessSections(nChildNode.SelectNodes(_xpathSections), xpathSection);

                    #region Elementos

                    string xpathElemento = string.Empty;
                    // Se procesan los elementos internos
                    foreach (XmlNode nElement in nChildNode.SelectNodes(_xpathElements))
                    {
                        bool overrideElement = false;
                        overrideValue = GetAttributeValue("Sobreescribir", nElement);
                        if (overrideValue == "Si") { overrideElement = true; }

                        XmlAttribute idElement = nElement.Attributes["Id"];
                        if (idElement == null)
                        {
                            string nombre = nElement.Attributes["Nombre"] != null ? nElement.Attributes["Nombre"].Value : string.Empty;
                            xpathElemento = string.Concat(xpathSection, string.Format("/Elemento[@Nombre='{0}']", nombre));
                        }
                        else { xpathElemento = string.Concat(xpathSection, string.Format("/Elemento[@Id='{0}']", idElement.Value)); }

                        GetInheritanceUbication(nElement, out ubicacion, out strAttribute);

                        // Valida si el nodo existe, en caso de que no exista se agrega
                        if (overrideElement || !ExistsNode(xpathElemento))
                        {
                            ProcessNode(xpathElemento, nElement, ubicacion, strAttribute, ConfigTagType.Element);
                        }
                        else
                        {
                            nBase = _xmlConfigBase.SelectSingleNode(xpathElemento);
                            ProcessElementsAttributes(nBase, nElement);
                            ProcessUbications(xpathElemento, ubicacion, strAttribute, ConfigTagType.Element);
                            ProcessXPMLConfiguration(nElement.SelectNodes(_xpathXPMLElement), nBase);
                        }
                    }

                    #endregion
                }
            }
        }

        /// <summary>
        /// Verifica si el nodo a procesar existe
        /// </summary>
        /// <param name="xpath">Xpath</param>
        /// <returns>true si existe, de lo contrario false</returns>
        private bool ExistsNode(string xpath)
        {
            XmlNode nodoOrigen = _xmlConfigBase.SelectSingleNode(xpath);
            if (nodoOrigen == null) { return false; }
            return true;
        }

        /// <summary>
        /// Obtiene los valores que indican en que posicion se hace la herencia
        /// </summary>
        /// <param name="nNodo">Nodo que se esta procesando</param>
        /// <param name="ubicacion">Ubicacion donde se va a colocar</param>
        /// <param name="strAtributo">Nodo de referencia de la base</param>
        private void GetInheritanceUbication(XmlNode nNodo, out InheritancePosition ubicacion, out string strAtributo)
        {
            ubicacion = InheritancePosition.NotApply;
            strAtributo = GetAttributeValue("AntesDe", nNodo);
            if (strAtributo.IsNullOrWhiteSpace())
            {
                strAtributo = GetAttributeValue("DespuesDe", nNodo);
                if (!strAtributo.IsNullOrWhiteSpace()) { ubicacion = InheritancePosition.After; }
            }
            else { ubicacion = InheritancePosition.Before; }
        }

        /// <summary>
		/// Obtiene el valor del atributo
		/// </summary>
		/// <param name="attribute">Atributo a buscar</param>
		/// <param name="node">Estructura para validar</param>
		/// <returns>Valor del atributo, si no lo encuentra string.Empty</returns>
		public string GetAttributeValue(string attribute, XmlNode node)
        {
            if (node != null) { if (node.Attributes[attribute] != null) { return node.Attributes[attribute].Value; } }
            return string.Empty;
        }

        /// <summary>
        /// Procesa el nodo hijo actual para agregarlo en la configuracion base y en caso de ser necesario reemplazar el de la base
        /// </summary>
        /// <param name="xpath">Xpath</param>
        /// <param name="nChildNode">Nodo de la configuracion hija</param>
        /// <param name="herencia">Posicion donde se hace la herencia</param>
        /// <param name="valorReferencia">Nombre de la etiqueta de referencia</param>
        /// <param name="tipoEtiqueta">Tipo de etiqueta que se esta procesando</param>
        private void ProcessNode(string xpath, XmlNode nChildNode, InheritancePosition herencia, string valorReferencia, ConfigTagType tipoEtiqueta)
        {
            #region Duplicate Node

            XmlNode nodoOrigen = _xmlConfigBase.SelectSingleNode(xpath);
            XmlNode nodoTemp = _xmlConfigBase.CreateNode(XmlNodeType.Element, "Temporal", "");
            nodoTemp.InnerXml = nChildNode.OuterXml;

            #endregion

            #region Xpath Referencia

            string strXpathRef = string.Empty;
            // Se realiza este proceso si se configura la etiqueta AntesDe o DespuesDe ya que se requiere hacer la consulta
            // para acomodar la etiqueta
            if (tipoEtiqueta == ConfigTagType.Section) { strXpathRef = string.Format("Seccion[@Id='{0}']", valorReferencia); }
            else if (tipoEtiqueta == ConfigTagType.Element) { strXpathRef = string.Format("Elemento[@Id='{0}']", valorReferencia); }

            #endregion

            #region Proceso si ya existe

            if (nodoOrigen != null)
            {
                // Si existe se sobreescribe
                if (herencia == InheritancePosition.NotApply) { nodoOrigen.ParentNode.InsertAfter(nodoTemp.FirstChild, nodoOrigen); }
                else if (herencia == InheritancePosition.Before)
                {
                    XmlNode nodoReferencia = nodoOrigen.ParentNode.SelectSingleNode(strXpathRef);
                    if (nodoReferencia == null) { nodoOrigen.ParentNode.InsertAfter(nodoTemp.FirstChild, nodoOrigen); }
                    else { nodoOrigen.ParentNode.InsertBefore(nodoTemp.FirstChild, nodoReferencia); }
                }
                else if (herencia == InheritancePosition.After)
                {
                    XmlNode nodoReferencia = nodoOrigen.ParentNode.SelectSingleNode(strXpathRef);
                    if (nodoReferencia == null) { nodoOrigen.ParentNode.InsertAfter(nodoTemp.FirstChild, nodoOrigen); }
                    else { nodoOrigen.ParentNode.InsertAfter(nodoTemp.FirstChild, nodoReferencia); }
                }

                nodoOrigen.ParentNode.RemoveChild(nodoOrigen);
            }

            #endregion

            #region Proceso si no existe

            else
            {
                // Se procesa el xpath para quedar ubicado en la etiqueta padre de la que se va a agregar
                xpath = xpath.ReverseString();
                xpath = xpath.GetSafeSubstring(xpath.IndexOf('/') + 1).ReverseString();
                nodoOrigen = _xmlConfigBase.SelectSingleNode(xpath);

                if (herencia == InheritancePosition.NotApply) { nodoOrigen.AppendChild(nodoTemp.FirstChild); }
                else if (herencia == InheritancePosition.Before)
                {
                    XmlNode nodoReferencia = nodoOrigen.SelectSingleNode(strXpathRef);
                    if (nodoReferencia == null) { nodoOrigen.AppendChild(nodoTemp.FirstChild); }
                    else { nodoOrigen.InsertBefore(nodoTemp.FirstChild, nodoReferencia); }
                }
                else if (herencia == InheritancePosition.After)
                {
                    XmlNode nodoReferencia = nodoOrigen.SelectSingleNode(strXpathRef);
                    if (nodoReferencia == null) { nodoOrigen.AppendChild(nodoTemp.FirstChild); }
                    else { nodoOrigen.InsertAfter(nodoTemp.FirstChild, nodoReferencia); }
                }
            }

            #endregion
        }

        /// <summary>
        /// Procesa la ubicacion del nodo actual
        /// </summary>
        /// <param name="xpath">Xpath</param>
        /// <param name="herencia">Posicion donde se hace la herencia</param>
        /// <param name="valorReferencia">Nombre de la etiqueta de referencia</param>
        /// <param name="tipoEtiqueta">Tipo de etiqueta que se esta procesando</param>
        private void ProcessUbications(string xpath, InheritancePosition herencia, string valorReferencia, ConfigTagType tipoEtiqueta)
        {
            // Se obtiene el nodo base
            XmlNode nodoOrigen = _xmlConfigBase.SelectSingleNode(xpath);
            XmlNode nodoTemp = _xmlConfigBase.CreateNode(XmlNodeType.Element, "Temporal", "");
            nodoTemp.InnerXml = nodoOrigen.OuterXml;

            #region Xpath Referencia

            string strXpathRef = string.Empty;
            // Se realiza este proceso si se configura la etiqueta AntesDe o DespuesDe ya que se requiere hacer la consulta
            // para acomodar la etiqueta
            if (tipoEtiqueta == ConfigTagType.Section) { strXpathRef = string.Format("Seccion[@Id='{0}']", valorReferencia); }
            else if (tipoEtiqueta == ConfigTagType.Element) { strXpathRef = string.Format("Elemento[@Id='{0}']", valorReferencia); }

            #endregion

            if (herencia == InheritancePosition.Before)
            {
                XmlNode nodoReferencia = nodoOrigen.ParentNode.SelectSingleNode(strXpathRef);
                if (nodoReferencia != null)
                {
                    nodoOrigen.ParentNode.InsertBefore(nodoTemp.FirstChild, nodoReferencia);
                    nodoOrigen.ParentNode.RemoveChild(nodoOrigen);
                }
            }
            else if (herencia == InheritancePosition.After)
            {
                XmlNode nodoReferencia = nodoOrigen.ParentNode.SelectSingleNode(strXpathRef);
                if (nodoReferencia != null)
                {
                    nodoOrigen.ParentNode.InsertAfter(nodoTemp.FirstChild, nodoReferencia);
                    nodoOrigen.ParentNode.RemoveChild(nodoOrigen);
                }
            }
        }

        /// <summary>
        /// Actualiza los atributos hijos de los elementos en la base
        /// </summary>
        /// <param name="nodoBase">Nodo Base</param>
        /// <param name="nodoHijo">Nodo Hijo</param>
        private void ProcessElementsAttributes(XmlNode nodoBase, XmlNode nodoHijo)
        {
            #region Atributos

            // Actualiza los atributos de la config hija a la base
            List<string> lstRestringidos = new List<string>(new string[] { "Nombre", "Id", "Sobreescribir", "AntesDe", "DespuesDe" });
            List<string> lstPalabrasClave = new List<string>(new string[] { "Predeterminado", "Variable", "Reservada", "Buscar" });

            Dictionary<string, string> dicPalabraClave = new Dictionary<string, string>();

            #region Recorre atributos

            foreach (XmlAttribute atributo in nodoHijo.Attributes)
            {
                if (lstRestringidos.Contains(atributo.Name)) { continue; }
                if (lstPalabrasClave.Contains(atributo.Name)) { dicPalabraClave.Add(atributo.Name, atributo.Value); }
                else
                {
                    if (nodoBase.Attributes[atributo.Name] == null)
                    {
                        // Si no existe, lo crea
                        XmlAttribute atributoNuevo = nodoBase.OwnerDocument.CreateAttribute(atributo.Name);
                        atributoNuevo.Value = atributo.Value;
                        nodoBase.Attributes.Append(atributoNuevo);
                    }
                    else
                    {
                        // Si existe, lo actualiza
                        nodoBase.Attributes[atributo.Name].Value = atributo.Value;
                    }
                }
            }

            #endregion

            #region Procesa palabras clave

            // Se verifica el diccionario que almacena las palabras clave de la config hija para
            // actualizarlas en la base
            if (dicPalabraClave.Count > 0)
            {
                List<XmlAttribute> atributosRemover = new List<XmlAttribute>();
                foreach (XmlAttribute atributo in nodoBase.Attributes)
                {
                    // Se almacenan los atributos que se van a remover de la base
                    if (lstPalabrasClave.Contains(atributo.Name)) { atributosRemover.Add(atributo); }
                }

                // Se borran los atributos
                foreach (XmlAttribute atributo in atributosRemover) { nodoBase.Attributes.Remove(atributo); }

                // Se agregan los nuevos atributos
                foreach (KeyValuePair<string, string> atributo in dicPalabraClave)
                {
                    XmlAttribute atributoNuevo = nodoBase.OwnerDocument.CreateAttribute(atributo.Key);
                    atributoNuevo.Value = atributo.Value;
                    nodoBase.Attributes.Append(atributoNuevo);
                }
            }

            #endregion

            #endregion

            #region Palabra Clave

            // Si se ha configurado XPML se actualiza
            XmlNode nodoPC = nodoHijo.SelectSingleNode(_xpathElementValue);
            if (nodoPC != null)
            {
                XmlNode nodoTemp = _xmlConfigBase.CreateNode(XmlNodeType.Element, "Temporal", "");
                nodoTemp.InnerXml = nodoPC.OuterXml;

                XmlNode nodoPCBase = nodoBase.SelectSingleNode(_xpathElementValue);
                if (nodoPCBase != null) { nodoBase.RemoveChild(nodoPCBase); }

                nodoBase.AppendChild(nodoTemp.FirstChild);
            }

            #endregion
        }

        /// <summary>
        /// Procesa la configuracion XPML
        /// </summary>
        /// <param name="nChildNodes">Configuracion</param>
        /// <param name="nBase">Base</param>
        private void ProcessXPMLConfiguration(XmlNodeList nChildNodes, XmlNode nBase)
        {
            foreach (XmlNode nChild in nChildNodes)
            {
                XmlNode nodoTemp = _xmlConfigBase.CreateNode(XmlNodeType.Element, "Temporal", "");
                nodoTemp.InnerXml = nChild.OuterXml;

                XmlNode nodoXPMLBase = nBase.SelectSingleNode(nChild.Name);
                if (nodoXPMLBase != null) { nBase.RemoveChild(nodoXPMLBase); }

                nBase.AppendChild(nodoTemp.FirstChild);
            }
        }

        #endregion
    }
}
