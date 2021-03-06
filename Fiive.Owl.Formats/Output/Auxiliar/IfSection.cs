﻿using Fiive.Owl.Core;
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
        /// <param name="isLater">true if is a later validation, otherwise false</param>
        /// <returns>true si los valida correctamente, de lo contrario false</returns>
        public bool Validate(OwlHandler handler, bool isLater)
        {
            if (_node == null) { return true; }

            XmlAttribute attr = _node.Attributes["later"];
            string val = attr == null ? "no" : attr.Value;

            if ((isLater && val == "yes") || (!isLater && val == "no")) { return ValidateNode(_node, handler); }

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
                XmlAttribute attr = nodoHijo.Attributes["logical-operator"];
                string operadorLogico = attr != null ? attr.Value : string.Empty;

                if (intContador != 1)
                {
                    // this validation is because if one validation is false in a "Y" Condition, all validation is false
                    if (operadorLogico == "and" && !bolEstado) { break; }
                }

                #endregion

                #region Validate values

                XmlNode subSi = nodoHijo.HasChildNodes ? nodoHijo.SelectSingleNode("if") : null;
                if (subSi != null)
                {
                    // Si el nodo tiene subnodo si, se valida el si de adentro para seguir con las demas condiciones
                    bolValActual = ValidateNode(subSi, handler);
                }
                else
                {
                    #region Valores

                    // Obtienes nodos
                    XmlNode valor1 = nodoHijo.SelectSingleNode("value-1");
                    XmlNode valor2 = nodoHijo.SelectSingleNode("value-2");

                    if (valor1 == null || valor2 == null) { throw new OwlException(string.Format(ETexts.GT(ErrorType.TagsDoesNotExists), nodoHijo.Name)); }

                    // Obtiene valores
                    string strValor1 = handler.XOMLValidator.GetKeywordValue(valor1, handler);
                    string strValor2 = handler.XOMLValidator.GetKeywordValue(valor2, handler);

                    #endregion

                    #region Tipo de comparacion

                    // Obtiene tipo de comparacion
                    XmlAttribute attr2 = valor2.Attributes["compare-operator"];
                    string tipoComparacion = attr2 != null ? attr2.Value : string.Empty;
                    switch (tipoComparacion)
                    {
                        #region Texto

                        case "equal":
                            if (strValor1 == strValor2) { bolValActual = true; } else { bolValActual = false; }
                            break;

                        case "different":
                            if (strValor1 != strValor2) { bolValActual = true; } else { bolValActual = false; }
                            break;

                        #endregion

                        #region Numericos

                        case "greater":
                        case "less":
                        case "greater-equal":
                        case "less-equal":

                            decimal vValor1 = 0, vValor2 = 0;

                            #region Validaciones

                            if (!strValor1.IsDecimal()) { throw new OwlException(string.Format(ETexts.GT(ErrorType.IfNonNumericValue), tipoComparacion, "compare-operator", strValor1, "value-1")); }
                            else { vValor1 = Convert.ToDecimal(strValor1); }

                            if (!strValor2.IsDecimal()) { throw new OwlException(string.Format(ETexts.GT(ErrorType.IfNonNumericValue), tipoComparacion, "compare-operator", strValor2, "value-2")); }
                            else { vValor2 = Convert.ToDecimal(strValor2); }

                            #endregion

                            if (tipoComparacion == "greater") { if (vValor1 > vValor2) { bolValActual = true; } else { bolValActual = false; } }
                            else if (tipoComparacion == "less") { if (vValor1 < vValor2) { bolValActual = true; } else { bolValActual = false; } }
                            else if (tipoComparacion == "greater-equal") { if (vValor1 >= vValor2) { bolValActual = true; } else { bolValActual = false; } }
                            else if (tipoComparacion == "less-equal") { if (vValor1 <= vValor2) { bolValActual = true; } else { bolValActual = false; } }

                            break;

                        #endregion

                        default:
                            throw new OwlException(string.Format(ETexts.GT(ErrorType.XOMLPropertyInvalidValue), tipoComparacion, "compare-operator"));
                    }

                    #endregion
                }

                #endregion

                #region Validacion de operador logico

                if (intContador == 1) { bolEstado = bolValActual; }
                else if (intContador != 1)
                {
                    if (operadorLogico == "or") { bolEstado = bolEstado || bolValActual; }
                    else if (operadorLogico == "and")
                    {
                        bolEstado = bolEstado && bolValActual;
                        if (!bolEstado) { break; } // this validation is because if one validation is false in a "Y" Condition, all validation is false
                    }
                    else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XOMLPropertyInvalidValue), operadorLogico, "logical-operator")); }
                }

                #endregion

                intContador++;
            }

            return bolEstado;
        }

        #endregion
    }
}
