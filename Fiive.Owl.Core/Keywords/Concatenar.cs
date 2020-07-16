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
    public class Concatenar : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el caracter usado para separar los valores
        /// </summary>
        public string Separador { get; set; }
        /// <summary>
        /// Obtiene / Establece el Formato de la cadena de salida
        /// </summary>
        public string Formato { get; set; }
        /// <summary>
        /// Obtiene / Establece los Valores a ser concatenados
        /// </summary>
        public List<string> Valores { get; set; }

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
                    new XPMLSigning.XPMLRestriction { Name = "Separador", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Formato", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Valores", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.List }
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

            if (Valores == null || Valores.Count == 0) { throw new OwlKeywordException(KeywordsType.Concatenar, string.Format(ETexts.GT(ErrorType.KeywordPropertyUndefined), "Valores")); }

            #endregion

            if (!string.IsNullOrEmpty(Separador)) { return string.Join(Separador, Valores.ToArray()); }
            else
            {
                if (Formato.IsNullOrWhiteSpace()) { return string.Concat(Valores.ToArray()); }
                else { return string.Format(Formato, Valores.ToArray()); }
            }
        }

        #endregion
    }
}
