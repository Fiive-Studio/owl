using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlAdapterException : ApplicationException
    {
        /// <summary>
        /// Construye la clase
        /// </summary>
        public OwlAdapterException() : base() { }

        /// <summary>
        /// Construye la clase
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public OwlAdapterException(string message) : base(message) { }

        /// <summary>
        /// Construye la clase
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="innerException">Excepcion que provoca la excepcion actual</param>
        public OwlAdapterException(string message, Exception innerException) : base(message, innerException) { }
    }
}
