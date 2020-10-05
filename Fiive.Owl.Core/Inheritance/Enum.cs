using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Core
{
    public enum InheritancePosition
    {
        /// <summary>
        /// No Aplica
        /// </summary>
        NotApply = 0,
        /// <summary>
        /// Se agrega antes de la etiqueta
        /// </summary>
        Before = 1,
        /// <summary>
        /// Se agrega despues de la etiqueta
        /// </summary>
        After = 2
    }

    /// <summary>
    /// Define el tipo de etiqueta
    /// </summary>
    enum ConfigTagType
    {
        /// <summary>
        /// Indica Elemento
        /// </summary>
        Element = 0,
        /// <summary>
        /// Indica Seccion
        /// </summary>
        Section = 1
    }
}