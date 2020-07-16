using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Input;
using Fiive.Owl.Core.Output;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
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
        /// Storage PGA Vars
        /// </summary>
        Dictionary<string, string> _PGAVars;

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

        OwlSettings _pgaSettings;
        /// <summary>
        /// Obtiene / Establece la configuracion del mapeo
        /// </summary>
        public OwlSettings Settings
        {
            get { return _pgaSettings; }
            set
            {
                _pgaSettings = value;
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
        /// Get thw XPML Validator
        /// </summary>
        public XPMLValidator XPMLValidator { get; private set; }

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
            XPMLValidator = new XPMLValidator();
            KeywordsManager = new KeywordsManager();
            _PGAVars = new Dictionary<string, string>();
        }

        #endregion

        #region Privates

        /// <summary>
        /// Asigna los separadores de decimales
        /// </summary>
        void ValidateNumberDecimalSeparator()
        {
            // Se valida si se establecio el separador de decimales, en caso de que no se haya asignado se coloca el que este configurado en el Thread
            if (_pgaSettings.InputNumberDecimalSeparator == char.MinValue) { _pgaSettings.InputNumberDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; }
            if (_pgaSettings.OutputNumberDecimalSeparator == char.MinValue) { _pgaSettings.OutputNumberDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]; }
        }

        #endregion

        #region Publics

        /// <summary>
        /// Valida y carga la informacion de la configuracion del mapeo
        /// </summary>
        /// <exception cref="OwlException">Error al cargar el archivo de Configuracion Xml</exception>
        public void LoadConfigMap()
        {
            if (_pgaSettings == null) { throw new OwlException(ETexts.GT(ErrorType.OwlSettingsIsNull)); }
            if (_pgaSettings.PathConfig.IsNullOrWhiteSpace() && _pgaSettings.XmlConfig == null) { throw new OwlException(ETexts.GT(ErrorType.PathConfigMapIsEmpty)); }
            if (!_pgaSettings.PathConfig.IsNullOrWhiteSpace() && !File.Exists(_pgaSettings.PathConfig)) { throw new OwlException(string.Format(ETexts.GT(ErrorType.ConfigMapNotFound), _pgaSettings.PathConfig)); }

            ConfigMap = new OwlConfigMap(Settings);
            ConfigMap.LoadConfigMap(_pgaSettings.Instance);
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

        #region PGA Vars

        /// <summary>
        /// Agrega variable global, en caso de que exista la actualiza
        /// </summary>
        /// <param name="key">Llave</param>
        /// <param name="value">Valor</param>
        private void AddVariable(string key, string value) { _PGAVars[key] = value; }

        /// <summary>
        /// Obtiene variable global
        /// </summary>
        /// <param name="key">Llave</param>
        /// <exception cref="OwlException">La variable no existe</exception>
        private string GetVariable(string key)
        {
            if (_PGAVars.ContainsKey(key)) { return _PGAVars[key]; }
            throw new OwlException(string.Format(ETexts.GT(ErrorType.OwlVarUndefined), key));
        }

        /// <summary>
        /// Valida si existe una variable
        /// </summary>
        /// <param name="key">Llave</param>
        /// <returns>true si existe, de lo contrario false</returns>
        public bool ExistVariable(string key) { return _PGAVars.ContainsKey(key); }

        /// <summary>
        /// Quita una variable global
        /// </summary>
        /// <param name="key">Llave</param>
        public void RemoveVariable(string key) { if (_PGAVars.ContainsKey(key)) { _PGAVars.Remove(key); } }

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
