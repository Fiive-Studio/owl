using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XOML;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.Input;
using System.Xml;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Valor del archivo de entrada
    /// </summary>
    public class Xpath : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el Valor
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region IXOMLObject

        /// <summary>
        /// Obtiene la firma XOML del objeto
        /// </summary>
        /// <returns>Firma XOML</returns>
        public XOMLSigning GetSigning()
        {
            return new XOMLSigning
            {
                Restrictions = new List<XOMLSigning.XOMLRestriction>() 
                { 
                    new XOMLSigning.XOMLRestriction { TagName = "value", PropertyName = "Value", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.String },
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
            return ((OwlHandler)handler).CurrentValue.GetValue(Value);
        }
        
        #endregion
    }
}
