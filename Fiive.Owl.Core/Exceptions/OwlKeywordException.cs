using Fiive.Owl.Core.Keywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public class OwlKeywordException : OwlException
    {
        #region Properties

        public KeywordsType KeywordType { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Construye la clase
        /// </summary>
        public OwlKeywordException(KeywordsType keywordType) : base() { this.KeywordType = keywordType; }

        /// <summary>
        /// Construye la clase
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public OwlKeywordException(KeywordsType keywordType, string message) : base(message) { this.KeywordType = keywordType; }

        /// <summary>
        /// Construye la clase
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="xml">Valor contenido en el nodo XML</param>
        /// <param name="parentNode">Nombre del nodo padre del atributo</param>
        /// <param name="section">Seccion donde se produjo el error</param>
        public OwlKeywordException(KeywordsType keywordType, string message, string section) : base(message, section) { this.KeywordType = keywordType; }

        /// <summary>
        /// Construye la clase
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="xml">Valor contenido en el nodo XML</param>
        /// <param name="parentNode">Nombre del nodo padre del atributo</param>
        /// <param name="section">Seccion donde se produjo el error</param>
        /// <param name="innerException">Excepcion que provoca la excepcion actual</param>
        public OwlKeywordException(KeywordsType keywordType, string message, string section, System.Exception innerException) : base(message, section, innerException) { this.KeywordType = keywordType; }

        #endregion
    }
}
