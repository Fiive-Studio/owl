using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Adapters
{
    /// <summary>
    /// Representa la configuracion de Owl Mapper
    /// </summary>
    public class OwlAdapterSettings: ConfigurationSection
    {
        #region Statics

        private static OwlAdapterSettings _settings = ConfigurationManager.GetSection("OwlAdapterSettings") as OwlAdapterSettings;

        /// <summary>
        /// Obtiene la configuracion de log del App.config
        /// </summary>
        public static OwlAdapterSettings Settings
        {
            get
            {
                object objLock = new object();
                lock (objLock) { if (_settings == null) { _settings = new OwlAdapterSettings(); } }
                return _settings;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Maximo numero de detalles de log a agregar
        /// </summary>
        [ConfigurationProperty("OwlEDILibrary", DefaultValue = "Fiive.Owl.EDI.Segments.{0}, Fiive.Owl.EDI", IsRequired = false)]
        public string MapperEDILibrary
        {
            get { return (string)this["OwlEDILibrary"]; }
            set { this["OwlEDILibrary"] = value; }
        }

        /// <summary>
        /// Maximo numero de detalles de log a agregar
        /// </summary>
        [ConfigurationProperty("OwlANSILibrary", DefaultValue = "Fiive.Owl.ANSI.Segments.{0}, Fiive.Owl.ANSI", IsRequired = false)]
        public string MapperANSILibrary
        {
            get { return (string)this["OwlANSILibrary"]; }
            set { this["OwlANSILibrary"] = value; }
        }

        #endregion
    }
}
