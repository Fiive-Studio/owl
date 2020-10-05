using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Formats.Output.XOML;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Argumentos del evento SectionGroupInitiated
    /// </summary>
    public class OutputSectionEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Configuracion XOML
        /// </summary>
        public SectionOutput XOMLConfig { get; internal set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicia la clase
        /// </summary>
        public OutputSectionEventArgs() { }

        #endregion
    }
}
