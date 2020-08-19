using Fiive.Owl.Core.XOML;
using Fiive.Owl.Core.Keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Core.Keywords
{
    public class If : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el primer valor a validar
        /// </summary>
        public string Value1 { get; set; }
        /// <summary>
        /// Obtiene / Establece el segundo valor a validar
        /// </summary>
        public string Value2 { get; set; }
        /// <summary>
        /// Obtiene / Establece el tipo de validacion
        /// </summary>
        public ValidationType Type { get; set; }
        /// <summary>
		/// Obtiene / Establece el valor retornado si se cumple la condicion
		/// </summary>
        public string True { get; set; }
        /// <summary>
		/// Obtiene / Establece el valor retornado si no se cumple la condicion
		/// </summary>
        public string False { get; set; }

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
                    new XOMLSigning.XOMLRestriction { TagName = "value-1", PropertyName = "Value1", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "value-2", PropertyName = "Value2", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "type", PropertyName = "Type", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.Enum },
                    new XOMLSigning.XOMLRestriction { TagName = "true", PropertyName = "True", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "false", PropertyName = "False", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.String }
                }
            };
        }

        public void SetPropertyValue(string property, string value)
        {
            if (property == "Type") { Type = (ValidationType)Enum.Parse(typeof(ValidationType), value); }
            else { throw new OwlKeywordException(KeywordsType.If, string.Format(ETexts.GT(ErrorType.XOMLEnumInvalid), property)); }
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
            if (False == null) { False = string.Empty; }

            switch (Type)
            {
                #region Texto

                case ValidationType.Equal:
                    if (Value1 == Value2) { return True; } else { return False; }

                case ValidationType.Different:
                    if (Value1 != Value2) { return True; } else { return False; }

                #endregion

                #region Numericos

                case ValidationType.Greater:
                case ValidationType.Less:
                case ValidationType.GreaterEqual:
                case ValidationType.LessEqual:

                    decimal vValor1 = 0, vValor2 = 0;

                    #region Validaciones

                    if (!Value1.IsDecimal())
                    {
                        throw new OwlKeywordException(KeywordsType.If, string.Format(ETexts.GT(ErrorType.IfNonNumericValue), Type, "type", Value1, "value-1"));
                    }
                    else { vValor1 = Convert.ToDecimal(Value1); }

                    if (!Value2.IsDecimal())
                    {
                        throw new OwlKeywordException(KeywordsType.If, string.Format(ETexts.GT(ErrorType.IfNonNumericValue), Type, "type", Value2, "value-2"));
                    }
                    else { vValor2 = Convert.ToDecimal(Value2); }

                    #endregion

                    if (Type == ValidationType.Greater) { if (vValor1 > vValor2) { return True; } else { return False; } }
                    else if (Type == ValidationType.Less) { if (vValor1 < vValor2) { return True; } else { return False; } }
                    else if (Type == ValidationType.GreaterEqual) { if (vValor1 >= vValor2) { return True; } else { return False; } }
                    else if (Type == ValidationType.LessEqual) { if (vValor1 <= vValor2) { return True; } else { return False; } }

                    break;

                    #endregion
            }

            return string.Empty;
        }

        #endregion

        public enum ValidationType { Equal, Different, Greater, Less, GreaterEqual, LessEqual }
    }
}
