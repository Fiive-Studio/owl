using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    public class IndexOf : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el valor
        /// </summary>
        public string Value { get; set; }
        /// <summary>
		/// Obtiene / Establece la subcadena a buscar
		/// </summary>
        public string StringSeek { get; set; }
        /// <summary>
		/// Obtiene / Establece la posicion desde donde se va a iniciar la busqueda
		/// </summary>
        public int Start { get; set; }

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
                    new XPMLSigning.XPMLRestriction { TagName = "string-seek", PropertyName = "StringSeek", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "start", PropertyName = "Start", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Int }
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
            return Value.IndexOf(StringSeek, Start).ToString();
        }

        #endregion
    }
}
