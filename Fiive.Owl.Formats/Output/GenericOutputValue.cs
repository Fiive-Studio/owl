using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.Output;
using Fiive.Owl.Formats.Output.XOML;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Define un tipo de valor generico para la salida
    /// </summary>
    public class GenericOutputValue : IOutputValue
    {
        #region IOutputValue Members

        /// <summary>
        /// Obtiene / Establece el contenido de la salida
        /// </summary>
        public string Content { get { return _sbContent.ToString(); } }

        #endregion

        #region Publics

        StringBuilder _sbContent = new StringBuilder();
        public void Append(string value) { _sbContent.Append(value); }
        public void Insert(int index, string value) { _sbContent.Insert(index, value); }

        #endregion
    }
}
