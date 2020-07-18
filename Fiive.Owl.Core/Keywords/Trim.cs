using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    public class Trim : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el valor
        /// </summary>
        public string Value { get; set; }
        /// <summary>
		/// Obtiene / Establece el inicio
		/// </summary>
        public TrimType Type { get; set; }

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
                    new XPMLSigning.XPMLRestriction { TagName = "value", PropertyName = "Value", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "type", PropertyName = "Type", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum }
                }
            };
        }

        public void SetPropertyValue(string property, string value)
        {
            if (property == "Type") { Type = (TrimType)Enum.Parse(typeof(TrimType), value); }
            else { throw new OwlKeywordException(KeywordsType.Trim, string.Format(ETexts.GT(ErrorType.XPMLEnumInvalid), property)); }
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
            if (Type == TrimType.NotApply) { return Value.Trim(); }
            else if (Type == TrimType.Start) { return Value.TrimStart(); }
            else if (Type == TrimType.End) { return Value.TrimEnd(); }

            return Value;
        }

        #endregion

        /// <summary>
        /// Tipo de trim
        /// </summary>
        public enum TrimType { NotApply, Start, End }
    }
}
