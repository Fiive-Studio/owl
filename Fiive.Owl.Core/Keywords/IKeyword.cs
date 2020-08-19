using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fiive.Owl.Core.XOML;
using System.Xml;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Interfaz para las palabras claves
    /// </summary>
    public interface IKeyword : IXOMLObject
    {
        /// <summary>
        /// Obtiene / Establece el tipo de palabra clave
        /// </summary>
        KeywordsType KeywordType { get; set; }

        /// <summary>
        /// Obtiene el valor de la palabra clave
        /// </summary>
        /// <param name="handler">Orquestador</param>
        /// <returns>Valor</returns>
        string GetValue(object handler);
    }
}
