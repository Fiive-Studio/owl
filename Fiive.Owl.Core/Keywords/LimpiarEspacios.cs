using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    public class LimpiarEspacios : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el valor
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
		/// Obtiene / Establece el inicio
		/// </summary>
        public TrimType Lado { get; set; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public XPMLSigning GetSigning()
        {
            return new XPMLSigning
            {
                Restrictions = new List<XPMLSigning.XPMLRestriction>()
                {
                    new XPMLSigning.XPMLRestriction { Name = "Valor", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Lado", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum }
                }
            };
        }

        public void SetPropertyValue(string property, string value)
        {
            if (property == "Lado") { Lado = (TrimType)Enum.Parse(typeof(TrimType), value); }
            else { throw new OwlKeywordException(KeywordsType.LimpiarEspacios, string.Format(ETexts.GT(ErrorType.XPMLEnumInvalid), property)); }
        }

        #endregion

        #region IKeyword

        /// <summary>
        /// Obtiene / Establece el tipo de palabra clave
        /// </summary>
        public KeywordsType KeywordType { get; set; }

        /// <summary>
        /// Obtiene el valor de la palabra clave
        /// </summary>
        /// <param name="handler">Orquestador</param>
        /// <returns>Valor</returns>
        public string GetValue(object handler)
        {
            if (Lado == TrimType.NoAplica) { return Valor.Trim(); }
            else if (Lado == TrimType.Inicio) { return Valor.TrimStart(); }
            else if (Lado == TrimType.Fin) { return Valor.TrimEnd(); }

            return Valor;
        }

        #endregion

        /// <summary>
        /// Tipo de trim
        /// </summary>
        public enum TrimType { NoAplica, Inicio, Fin }
    }
}
