using Fiive.Owl.Core.Exceptions;
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
    /// Concatenate values
    /// </summary>
    public class Concatenate : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el caracter usado para separar los valores
        /// </summary>
        public string Separator { get; set; }
        /// <summary>
        /// Obtiene / Establece el Formato de la cadena de salida
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Obtiene / Establece los Valores a ser concatenados
        /// </summary>
        public List<string> Values { get; set; }

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
                    new XPMLSigning.XPMLRestriction { TagName = "separator", PropertyName = "Separator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "format", PropertyName = "Format", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "values", PropertyName = "Values", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.List }
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
            #region Validate values

            if (Values == null || Values.Count == 0) { throw new OwlKeywordException(KeywordsType.Concatenate, string.Format(ETexts.GT(ErrorType.KeywordPropertyUndefined), "values")); }

            #endregion

            if (!string.IsNullOrEmpty(Separator)) { return string.Join(Separator, Values.ToArray()); }
            else
            {
                if (Format.IsNullOrWhiteSpace()) { return string.Concat(Values.ToArray()); }
                else { return string.Format(Format, Values.ToArray()); }
            }
        }

        #endregion
    }
}
