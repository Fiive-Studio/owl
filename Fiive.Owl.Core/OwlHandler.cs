using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Input;
using Fiive.Owl.Core.Output;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XOML;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Core
{
    /// <summary>
    /// Clase encargada de orquestar el proceso de transformacion
    /// </summary>
    public class OwlHandler
    {
        #region Vars

        /// <summary>
        /// Storage Owl Vars
        /// </summary>
        Dictionary<string, string> _OwlVars;

        #endregion

        #region Properties

        /// <summary>
        /// Objeto con los datos de entrada
        /// </summary>
        public IFormatInput Input { get; private set; }

        /// <summary>
        /// Output object
        /// </summary>
        public IFormatOutput Output { get; private set; }

        /// <summary>
        /// Valor actual que se esta procesando
        /// </summary>
        public InputValue CurrentValue { get; set; }

        OwlSettings _owlSettings;
        /// <summary>
        /// Obtiene / Establece la configuracion del mapeo
        /// </summary>
        public OwlSettings Settings
        {
            get { return _owlSettings; }
            set
            {
                _owlSettings = value;
                ValidateNumberDecimalSeparator();
                LoadConfigMap();
            }
        }

        /// <summary>
        /// Objeto con la configuracion de mapeo
        /// </summary>
        public OwlConfigMap ConfigMap { get; private set; }

        /// <summary>
        /// Get the Keywords Manager
        /// </summary>
        public KeywordsManager KeywordsManager { get; private set; }

        /// <summary>
        /// Get thw XOML Validator
        /// </summary>
        public XOMLValidator XOMLValidator { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Instancia clase
        /// </summary>
        /// <param name="settings">Objeto con la configuracion de mapeo</param>
        public OwlHandler(OwlSettings settings)
        {
            ETexts.LoadTexts();
            Settings = settings;
            XOMLValidator = new XOMLValidator();
            KeywordsManager = new KeywordsManager();
            _OwlVars = new Dictionary<string, string>();
        }

        #endregion

        #region Privates

        /// <summary>
        /// Asigna los separadores de decimales
        /// </summary>
        void ValidateNumberDecimalSeparator()
        {
            // Se valida si se establecio el separador de decimales, en caso de que no se haya asignado se coloca el que este configurado en el Thread
            if (_owlSettings.InputNumberDecimalSeparator == char.MinValue) { _owlSettings.InputNumberDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; }
            if (_owlSettings.OutputNumberDecimalSeparator == char.MinValue) { _owlSettings.OutputNumberDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; }
        }

        #endregion

        #region Publics

        /// <summary>
        /// Valida y carga la informacion de la configuracion del mapeo
        /// </summary>
        /// <exception cref="OwlException">Error al cargar el archivo de Configuracion Xml</exception>
        public void LoadConfigMap()
        {
            if (_owlSettings == null) { throw new OwlException(ETexts.GT(ErrorType.OwlSettingsIsNull)); }
            if (_owlSettings.PathConfig.IsNullOrWhiteSpace() && _owlSettings.XmlConfig == null) { throw new OwlException(ETexts.GT(ErrorType.PathConfigMapIsEmpty)); }
            if (!_owlSettings.PathConfig.IsNullOrWhiteSpace() && !File.Exists(_owlSettings.PathConfig)) { throw new OwlException(string.Format(ETexts.GT(ErrorType.ConfigMapNotFound), _owlSettings.PathConfig)); }

            ConfigMap = new OwlConfigMap(Settings);
            ConfigMap.LoadConfigMap();
        }

        #endregion

        #region Interfaces

        /// <summary>
        /// Cargar datos de entrada
        /// </summary>
        /// <param name="oInput">Intefaz de entrada</param>
        public void LoadInput(IFormatInput oInput)
        {
            Input = oInput;
            Input.LoadData(ConfigMap, Settings);
        }

        /// <summary>
        /// Genera Salida
        /// </summary>
        /// <param name="oSalida">Intefaz de salida</param>
        /// <returns>IEnumerable con el objeto de salida que se va generando</returns>
        public IEnumerable<IOutputValue> WriteOutput(IFormatOutput oOutput)
        {
            Output = oOutput;
            return Output.Write(this);
        }

        #endregion

        #region Owl Vars

        /// <summary>
        /// Agrega variable global, en caso de que exista la actualiza
        /// </summary>
        /// <param name="key">Llave</param>
        /// <param name="value">Valor</param>
        private void AddVariable(string key, string value) { _OwlVars[key] = value; }

        /// <summary>
        /// Obtiene variable global
        /// </summary>
        /// <param name="key">Llave</param>
        /// <exception cref="OwlException">La variable no existe</exception>
        private string GetVariable(string key)
        {
            if (_OwlVars.ContainsKey(key)) { return _OwlVars[key]; }
            throw new OwlException(string.Format(ETexts.GT(ErrorType.OwlVarUndefined), key));
        }

        /// <summary>
        /// Valida si existe una variable
        /// </summary>
        /// <param name="key">Llave</param>
        /// <returns>true si existe, de lo contrario false</returns>
        public bool ExistVariable(string key) { return _OwlVars.ContainsKey(key); }

        /// <summary>
        /// Quita una variable global
        /// </summary>
        /// <param name="key">Llave</param>
        public void RemoveVariable(string key) { if (_OwlVars.ContainsKey(key)) { _OwlVars.Remove(key); } }

        /// <summary>
        /// Agrega u Obtiene la variable
        /// </summary>
        /// <param name="key">Variable</param>
        /// <returns>Valor de la variable</returns>
        public string this[string key]
        {
            get { return GetVariable(key); }
            set { AddVariable(key, value); }
        }

        #endregion
    }
}
