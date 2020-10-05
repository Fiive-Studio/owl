using System;
using System.Collections.Generic;
using System.Text;
using Fiive.Owl.Core.Input;

namespace Fiive.Owl.Core.Output
{
    /// <summary>
    /// Inteface para estructuras de salida
    /// </summary>
    public interface IFormatOutput
    {
        /// <summary>
        /// Escribe la salida
        /// </summary>
        /// <param name="handler">Objeto orquestador del proceso</param>
        /// <returns>IEnumerable con los objetos de salida</returns>
        IEnumerable<IOutputValue> Write(OwlHandler handler);
    }
}
