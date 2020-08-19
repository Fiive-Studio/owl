using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Formats.Output.XOML;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Argumentos de los eventos de los elementos de salida
    /// </summary>
    public class OutputElementEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Configuracion XOML
        /// </summary>
        public ElementOutput XOMLConfig { get; internal set; }

        /// <summary>
        /// Configuracion XOML
        /// </summary>
        public SectionOutput Section { get; internal set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicia la clase
        /// </summary>
        public OutputElementEventArgs() { }

        #endregion
    }
}
