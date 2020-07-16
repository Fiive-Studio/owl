using Fiive.Owl.Core;
using Fiive.Owl.Core.Keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Output.Auxiliar
{
    /// <summary>
    /// Represent the if validation
    /// </summary>
    public class IfSection
    {
        #region Vars

        XmlNode _node;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a IfSection instance
        /// </summary>
        /// <param name="node">Configuration node</param>
        public IfSection(XmlNode node) { _node = node; }

        #endregion

        #region Publicos

        /// <summary>
        /// Valida los campos requeridos
        /// </summary>
        /// <param name="handler">Handler</param>
        /// <param name="isPrevious">true if is a previous validation, otherwise false</param>
        /// <returns>true si los valida correctamente, de lo contrario false</returns>
        public bool Validate(OwlHandler handler, bool isPrevious)
        {
            if (_node == null) { return true; }

            XmlAttribute attr = _node.Attributes["Previo"];
            string val = attr == null ? "No" : attr.Value;

            if (isPrevious && val == "Si") { return ValidateNode(_node, handler); }
            else if (!isPrevious && val == "No") { return ValidateNode(_node, handler); }

            return true;
        }

        #endregion

        #region Privados

        /// <summary>
        /// Metodo recursivo para obtener los campos requeridos
        /// </summary>
        /// <param name="handler">Handler</param>
        /// <returns>true si los valida correctamente, de lo contrario false</returns>
        private bool ValidateNode(XmlNode node, OwlHandler handler)
        {
            int intContador = 1;
            bool bolEstado = true;

            foreach (XmlNode nodoHijo in handler.ConfigMap.GetConditionNode(node))
            {
                #region Vars and previous validation

                bool bolValActual = false;
                XmlAttribute attr = nodoHijo.Attributes["OperadorLogico"];
                string operadorLogico = attr != null ? attr.Value : string.Empty;

                if (intContador != 1)
                {
                    // this validation is because if one validation is false in a "Y" Condition, all validation is false
                    if (operadorLogico == "Y" && !bolEstado) { break; }
                }

                #endregion

                #region Validate values

                XmlNode subSi = nodoHijo.HasChildNodes ? nodoHijo.SelectSingleNode("Si") : null;
                if (subSi != null)
                {
                    // Si el nodo tiene subnodo si, se valida el si de adentro para seguir con las demas condiciones
                    bolValActual = ValidateNode(subSi, handler);
                }
                else
                {
                    #region Valores

                    // Obtienes nodos
                    XmlNode valor1 = nodoHijo.SelectSingleNode("Valor1");
                    XmlNode valor2 = nodoHijo.SelectSingleNode("Valor2");

                    if (valor1 == null || valor2 == null) { throw new OwlException(string.Format(ETexts.GT(ErrorType.TagsDoesNotExists), nodoHijo.Name)); }

                    // Obtiene valores
                    string strValor1 = handler.XPMLValidator.GetKeywordValue(valor1, handler);
                    string strValor2 = handler.XPMLValidator.GetKeywordValue(valor2, handler);

                    #endregion

                    #region Tipo de comparacion

                    // Obtiene tipo de comparacion
                    XmlAttribute attr2 = valor2.Attributes["TipoComparacion"];
                    string tipoComparacion = attr2 != null ? attr2.Value : string.Empty;
                    switch (tipoComparacion)
                    {
                        #region Texto

                        case "Igual":
                            if (strValor1 == strValor2) { bolValActual = true; } else { bolValActual = false; }
                            break;

                        case "Diferente":
                            if (strValor1 != strValor2) { bolValActual = true; } else { bolValActual = false; }
                            break;

                        #endregion

                        #region Numericos

                        case "Mayor":
                        case "Menor":
                        case "MayorIgual":
                        case "MenorIgual":

                            decimal vValor1 = 0, vValor2 = 0;

                            #region Validaciones

                            if (!strValor1.IsNumber()) { throw new OwlException(string.Format(ETexts.GT(ErrorType.IfNonNumericValue), tipoComparacion, "TipoComparacion", strValor1, "Valor1")); }
                            else { vValor1 = Convert.ToDecimal(strValor1); }

                            if (!strValor2.IsNumber()) { throw new OwlException(string.Format(ETexts.GT(ErrorType.IfNonNumericValue), tipoComparacion, "TipoComparacion", strValor2, "Valor2")); }
                            else { vValor2 = Convert.ToDecimal(strValor2); }

                            #endregion

                            if (tipoComparacion == "Mayor") { if (vValor1 > vValor2) { bolValActual = true; } else { bolValActual = false; } }
                            else if (tipoComparacion == "Menor") { if (vValor1 < vValor2) { bolValActual = true; } else { bolValActual = false; } }
                            else if (tipoComparacion == "MayorIgual") { if (vValor1 >= vValor2) { bolValActual = true; } else { bolValActual = false; } }
                            else if (tipoComparacion == "MenorIgual") { if (vValor1 <= vValor2) { bolValActual = true; } else { bolValActual = false; } }

                            break;

                        #endregion

                        default:
                            throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLPropertyInvalidValue), tipoComparacion, "TipoComparacion"));
                    }

                    #endregion
                }

                #endregion

                #region Validacion de operador logico

                if (intContador == 1) { bolEstado = bolValActual; }
                else if (intContador != 1)
                {
                    if (operadorLogico == "O") { bolEstado = bolEstado || bolValActual; }
                    else if (operadorLogico == "Y")
                    {
                        bolEstado = bolEstado && bolValActual;
                        if (!bolEstado) { break; } // this validation is because if one validation is false in a "Y" Condition, all validation is false
                    }
                    else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLPropertyInvalidValue), operadorLogico, "OperadorLogico")); }
                }

                #endregion

                intContador++;
            }

            return bolEstado;
        }

        #endregion
    }
}
