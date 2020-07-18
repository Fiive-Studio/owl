using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Formats.Output.XPML;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Argumentos del evento SectionGroupInitiated
    /// </summary>
    public class OutputSectionEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Configuracion XPML
        /// </summary>
        public SectionOutput XPMLConfig { get; internal set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicia la clase
        /// </summary>
        public OutputSectionEventArgs() { }

        #endregion
    }
}
