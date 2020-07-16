using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Fiive.Owl.Formats.Input
{
    /// <summary>
    /// Define un tipo de valor Xml
    /// </summary>
    public class XmlInputValue : InputValue
    {
        #region Vars

        XmlNode _node = null;
        XmlNamespaceManager _nsmgr = null;

        #endregion

        #region Constructor

        /// <summary>
		/// Inicia la clase
		/// </summary>
        /// <param name="node">Nodo con los datos</param>
		/// <param name="nsmgr">Objeto que administra los espacios de nombre</param>
        public XmlInputValue(XmlNode node, XmlNamespaceManager nsmgr)
        {
            _nsmgr = nsmgr;
            _node = node;
        }

        #endregion

        #region InputValue Members

        /// <summary>
        /// Cantidad de resultados que retorna la expresion
        /// </summary>
        /// <param name="eval">Expresion a evaluar</param>
        /// <returns>Cantidad de resultados</returns>
        public int Count(string eval)
        {
            try
            {
                string value = GetValue(string.Format("count({0})", eval));
                return Convert.ToInt32(value);
            }
            catch (Exception e)
            {
                throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.ErrorExecuteExpression), eval), "", _node.Name, "Documento/Entrada", e);
            }
        }

        /// <summary>
        /// Devuelve los valores
        /// </summary>
        /// <param name="eval">Expresion a evaluar</param>
        /// <returns>IEnumerable con los resultados</returns>
        public IEnumerable<InputValue> GetValues(string eval)
        {
            XmlNodeList nodes = null;
            try { nodes = _node.SelectNodes(eval, _nsmgr); }
            catch (Exception e)
            {
                throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.ErrorExecuteExpression), eval), "", _node.Name, "Documento/Entrada", e);
            }

            foreach (XmlNode node in nodes)
            {
                yield return new XmlInputValue(node, _nsmgr);
            }
        }

        /// <summary>
        /// Otiene un valor
        /// </summary>
        /// <param name="eval">Expresion a evaluar</param>
        /// <returns>Valor</returns>
        public string GetValue(string eval)
        {
            #region Valida sobre quien se hace la consulta

            XPathNavigator nav = _node.CreateNavigator();

            #endregion

            #region Ejecutar XPath

            try
            {
                XPathExpression exp = nav.Compile(eval);

                if (exp.ReturnType == XPathResultType.String || exp.ReturnType == XPathResultType.Number) { return nav.Evaluate(eval, _nsmgr).ToString(); }
                else if (exp.ReturnType == XPathResultType.NodeSet)
                {
                    XPathNodeIterator nodes = nav.Select(eval, _nsmgr);
                    while (nodes.MoveNext()) { return nodes.Current.ToString(); }
                }
            }
            catch (Exception e)
            {
                throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.ErrorExecuteExpression), eval), "", _node.Name, "Documento/Entrada", e);
            }

            #endregion

            return string.Empty;
        }

        #endregion
    }
}
