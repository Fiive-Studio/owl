using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    public class IsNumber : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el valor
        /// </summary>
        public string Value { get; set; }
        /// <summary>
		/// Obtiene / Establece el valor retornado si se cumple la condicion
		/// </summary>
        public string True { get; set; }
        /// <summary>
		/// Obtiene / Establece el valor retornado si no se cumple la condicion
		/// </summary>
        public string False { get; set; }

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
                    new XPMLSigning.XPMLRestriction { TagName = "true", PropertyName = "True", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "false", PropertyName = "False", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String }
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
            if (False == null) { False = string.Empty; }

            if (Value.IsDecimal()) { return True; }
            else { return False; }
        }

        #endregion
    }
}
