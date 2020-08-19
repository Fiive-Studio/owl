using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XOML;
using Fiive.Owl.Core.Keywords;
using System.Xml;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Valor de variables reservadas de Owl
    /// </summary>
    public class Key : IKeyword
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
            // Se hizo este metodo para poder darle soporte a la sintaxis vieja
            string[] partsReturn = Value.Split(new string[] { ":" }, 2, StringSplitOptions.None);
            string returnValue = partsReturn.GetSafeValue(0);
            string format = partsReturn.GetSafeValue(1);

            if (returnValue == "DATETIME")
            {
                if (format.IsNullOrWhiteSpace()) { return DateTime.Now.ToString("yyyyMMdd"); }
                else { return DateTime.Now.ToString(format); }
            }
            else
            {
                OwlHandler config = (OwlHandler)handler;

                // Si es una instancia y no existe la variable se retorna un valor generico
                if (config.Settings.Instance && !config.ExistVariable(returnValue)) { return config.KeywordsManager.DefaultAlphanumericInstanceValue; }

                if (config.ExistVariable(returnValue)) { return config[returnValue]; }
                else { throw new OwlException(string.Format(ETexts.GT(ErrorType.ReservadaWordDoesNotSupport), returnValue), "Key"); }
            }
        }
        
        #endregion
    }
}
