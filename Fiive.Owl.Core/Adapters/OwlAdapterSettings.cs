using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Adapters
{
    /// <summary>
    /// Representa la configuracion de PGA Mapper
    /// </summary>
    public class OwlAdapterSettings: ConfigurationSection
    {
        #region Statics

        private static OwlAdapterSettings _settings = ConfigurationManager.GetSection("PGAMapperSettings") as OwlAdapterSettings;

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
        [ConfigurationProperty("MapperEDILibrary", DefaultValue = "Carvajal.SI.PGA.Mapper.EDI.Segments.{0}, Carvajal.SI.PGA.Mapper.EDI", IsRequired = false)]
        public string MapperEDILibrary
        {
            get { return (string)this["MapperEDILibrary"]; }
            set { this["MapperEDILibrary"] = value; }
        }

        /// <summary>
        /// Maximo numero de detalles de log a agregar
        /// </summary>
        [ConfigurationProperty("MapperANSILibrary", DefaultValue = "Carvajal.SI.PGA.Mapper.ANSI.Segments.{0}, Carvajal.SI.PGA.Mapper.ANSI", IsRequired = false)]
        public string MapperANSILibrary
        {
            get { return (string)this["MapperANSILibrary"]; }
            set { this["MapperANSILibrary"] = value; }
        }

        #endregion
    }
}
