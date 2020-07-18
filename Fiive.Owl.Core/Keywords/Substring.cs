using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Substring Value
    /// </summary>
    public class Substring : IKeyword
    {
        #region Constructor

        public Substring() { Length = -1; }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene / Establece el valor
        /// </summary>
        public string Value { get; set; }
        /// <summary>
		/// Obtiene / Establece el inicio
		/// </summary>
        public int Start { get; set; }
        /// <summary>
		/// Obtiene / Establece el largo
		/// </summary>
        public int Length { get; set; }
        /// <summary>
		/// Obtiene / Establece si se quitan los espacios en blanco despues de obtener la subcadena
		/// </summary>
        public bool Trim { get; set; }

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
                    new XPMLSigning.XPMLRestriction { TagName = "start", PropertyName = "Start", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.Int },
                    new XPMLSigning.XPMLRestriction { TagName = "length", PropertyName = "Length", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Int },
                    new XPMLSigning.XPMLRestriction { TagName = "trim", PropertyName = "Trim", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean }
                }
            };
        }

        public void SetPropertyValue(string property, string value) { }

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
            if (Length == -1) { return Value.GetSafeSubstring(Start, Trim); }
            else { return Value.GetSafeSubstring(Start, Length, Trim); }
        }

        #endregion
    }
}
