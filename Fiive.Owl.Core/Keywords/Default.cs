using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Keywords;
using System.Xml;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Valor Predeterminado
    /// </summary>
    public class Default : IKeyword
    {
        #region Constructor

        public Default() { KeywordType = KeywordsType.Default; }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene / Establece el Valor
        /// </summary>
        public string Value { get; set; }

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
            return Value;
        }

        #endregion
    }
}
