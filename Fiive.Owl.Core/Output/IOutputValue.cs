using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Output
{
    /// <summary>
    /// Interfaz de valor generico para la salida
    /// </summary>
    public interface IOutputValue
    {
        /// <summary>
        /// Obtiene / Establece el contenido de la salida
        /// </summary>
        string Content { get; }
    }
}
