using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Core.Keywords
{
    public class Si : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el primer valor a validar
        /// </summary>
        public string Valor1 { get; set; }
        /// <summary>
        /// Obtiene / Establece el segundo valor a validar
        /// </summary>
        public string Valor2 { get; set; }
        /// <summary>
        /// Obtiene / Establece el tipo de validacion
        /// </summary>
        public ValidationType TipoComparacion { get; set; }
        /// <summary>
		/// Obtiene / Establece el valor retornado si se cumple la condicion
		/// </summary>
        public string ValorVerdadero { get; set; }
        /// <summary>
		/// Obtiene / Establece el valor retornado si no se cumple la condicion
		/// </summary>
        public string ValorFalso { get; set; }

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
                    new XPMLSigning.XPMLRestriction { Name = "Valor1", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Valor2", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "TipoComparacion", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.Enum },
                    new XPMLSigning.XPMLRestriction { Name = "ValorVerdadero", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "ValorFalso", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String }
                }
            };
        }

        public void SetPropertyValue(string property, string value)
        {
            if (property == "TipoComparacion") { TipoComparacion = (ValidationType)Enum.Parse(typeof(ValidationType), value); }
            else { throw new OwlKeywordException(KeywordsType.Si, string.Format(ETexts.GT(ErrorType.XPMLEnumInvalid), property)); }
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
            if (ValorFalso == null) { ValorFalso = string.Empty; }

            switch (TipoComparacion)
            {
                #region Texto

                case ValidationType.Igual:
                    if (Valor1 == Valor2) { return ValorVerdadero; } else { return ValorFalso; }

                case ValidationType.Diferente:
                    if (Valor1 != Valor2) { return ValorVerdadero; } else { return ValorFalso; }

                #endregion

                #region Numericos

                case ValidationType.Mayor:
                case ValidationType.Menor:
                case ValidationType.MayorIgual:
                case ValidationType.MenorIgual:

                    decimal vValor1 = 0, vValor2 = 0;

                    #region Validaciones

                    if (!Valor1.IsDecimal())
                    {
                        throw new OwlKeywordException(KeywordsType.Si, string.Format(ETexts.GT(ErrorType.IfNonNumericValue), TipoComparacion, "TipoComparacion", Valor1, "Valor1"));
                    }
                    else { vValor1 = Convert.ToDecimal(Valor1); }

                    if (!Valor2.IsDecimal())
                    {
                        throw new OwlKeywordException(KeywordsType.Si, string.Format(ETexts.GT(ErrorType.IfNonNumericValue), TipoComparacion, "TipoComparacion", Valor2, "Valor2"));
                    }
                    else { vValor2 = Convert.ToDecimal(Valor2); }

                    #endregion

                    if (TipoComparacion == ValidationType.Mayor) { if (vValor1 > vValor2) { return ValorVerdadero; } else { return ValorFalso; } }
                    else if (TipoComparacion == ValidationType.Menor) { if (vValor1 < vValor2) { return ValorVerdadero; } else { return ValorFalso; } }
                    else if (TipoComparacion == ValidationType.MayorIgual) { if (vValor1 >= vValor2) { return ValorVerdadero; } else { return ValorFalso; } }
                    else if (TipoComparacion == ValidationType.MenorIgual) { if (vValor1 <= vValor2) { return ValorVerdadero; } else { return ValorFalso; } }

                    break;

                #endregion
            }

            return string.Empty;
        }

        #endregion

        public enum ValidationType { Igual, Diferente, Mayor, Menor, MayorIgual, MenorIgual }
    }
}
