using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

namespace Fiive.Owl.Core
{
    /// <summary>
    /// Configuracion para el mapeo que realiza Owl
    /// </summary>
    public class OwlSettings
    {
        public OwlSettings() { LoadXmlPrefix = true; }

        /// <summary>
        /// Obtiene / Establece la Ruta del archivo de configuracion
        /// </summary>
        public string PathConfig { get; set; }

        /// <summary>
        /// Get / Set Config Xml
        /// </summary>
        public XmlDocument XmlConfig { get; set; }

        /// <summary>
        /// Obtiene / Establece la Ruta del archivo de configuracion Base
        /// </summary>
        public string PathConfigBase { get; set; }

        /// <summary>
        /// Get / Set Config Xml Base
        /// </summary>
        public XmlDocument XmlConfigBase { get; set; }

        /// <summary>
        /// Obtiene / Establece el DataSet con las referencias cruzadas
        /// </summary>
        public DataSet References { get; set; }

        /// <summary>
        /// Obtiene / Establece el separador de decimales de la entrada
        /// </summary>
        public char InputNumberDecimalSeparator { get; set; }

        /// <summary>
        /// Obtiene / Establece el separador de decimales de la salida
        /// </summary>
        public char OutputNumberDecimalSeparator { get; set; }

        /// <summary>
        /// Obtiene / Establece si se va a generar una instancia del documento
        /// </summary>
        public bool Instance { get; set; }

        /// <summary>
        /// Obtiene / Establece si se cargan de forma automatica los prefijos del Xml
        /// </summary>
        public bool LoadXmlPrefix { get; set; }
    }
}
