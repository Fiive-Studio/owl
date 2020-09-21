using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Core.Input;
using Fiive.Owl.Core;
using Fiive.Owl.Core.Exceptions;
using System.Xml.XPath;
using System.Text.RegularExpressions;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Input
{
    /// <summary>
    /// Estructura Xml de entrada
    /// </summary>
    public class XmlInput : IFormatInput
    {
        #region Vars

        XmlDocument _xml = null;
        XmlNamespaceManager _nsmgr = null;
        string _pathFile;
        string _prefix, _uri;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicia la clase
        /// </summary>
        /// <param name="ruta">Ruta del archivo de entrada</param>
        public XmlInput(string ruta) { _pathFile = ruta; }

        /// <summary>
        /// Inicia la clase
        /// </summary>
        /// <param name="ruta">Ruta del archivo de entrada</param>
        /// <param name="prefix">Prefijo que va a asociar al espacio de nombres</param>
        /// <param name="uri">Espacio de nombres a agregar</param>
        public XmlInput(string ruta, string prefix, string uri)
        {
            _pathFile = ruta;
            _prefix = prefix;
            _uri = uri;
        }

        /// <summary>
        /// Inicia la clase
        /// </summary>
        /// <param name="xml">Objeto con el XML</param>
        public XmlInput(XmlDocument xml)
        {
            this._xml = xml;
        }

        /// <summary>
        /// Inicia la clase
        /// </summary>
        /// <param name="xml">Objeto con el Xml</param>
        /// <param name="nsmgr">Objeto que administra espacios de nombres</param>
        public XmlInput(XmlDocument xml, XmlNamespaceManager nsmgr)
        {
            this._xml = xml;
            this._nsmgr = nsmgr;
        }

        #endregion

        #region Publics

        /// <summary>
        /// Agrega un espacio de nombres, se debe llamar despues del metodo LoadData
        /// </summary>
        /// <param name="prefix">Prefijo que va a asociar al namespace</param>
        /// <param name="uri">Espacio de nombres a agregar</param>
        public void AddNamespace(string prefix, string uri) { _nsmgr.AddNamespace(prefix, uri); }

        #endregion

        #region IFormatInput Members

        /// <summary>
        /// Carga los datos de la entrada
        /// </summary>
        /// <param name="configMap">Objeto de configuracion XML</param>
        /// <param name="configSettings">Objeto de configuracion de mapeo</param>
        public void LoadData(OwlConfigMap configMap, OwlSettings configSettings)
        {
            if (_xml == null)
            {
                _xml = new XmlDocument();
                try { _xml.Load(_pathFile); }
                catch (Exception e) { throw new OwlException(string.Format(ETexts.GT(ErrorType.ErrorLoadInputFile), _pathFile), e); }
            }

            if (_nsmgr == null)
            {
                _nsmgr = new XmlNamespaceManager(_xml.NameTable);
                if (!_prefix.IsNullOrWhiteSpace() && !_uri.IsNullOrWhiteSpace()) { AddNamespace(_prefix, _uri); }

                if (configSettings.LoadXmlPrefix)
                {
                    // Get the Namespaces with prefix
                    MatchCollection matches = Regex.Matches(_xml.OuterXml, "xmlns\\:(?<prefix>[A-Za-z][\\w\\d]*)\\=\\\"(?<uri>[\\w\\W][^\"]*)");
                    foreach (Match match in matches) { AddNamespace(match.Groups["prefix"].Value, match.Groups["uri"].Value); }

                    // Get the Namespaces without prefix
                    matches = Regex.Matches(_xml.OuterXml, "xmlns\\=\\\"(?<uri>[\\w\\W][^\"]*)");
                    foreach (Match match in matches) { AddNamespace("def", match.Groups["uri"].Value); }
                }
            }
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
                throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.ErrorExecuteExpression), eval), "", _xml.Name, "owl", e);
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
            try { nodes = _xml.SelectNodes(eval, _nsmgr); }
            catch (Exception e)
            {
                throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.ErrorExecuteExpression), eval), "", _xml.Name, "owl", e);
            }

            foreach (XmlNode node in nodes) { yield return new XmlInputValue(node, _nsmgr); }
        }

        /// <summary>
        /// Otiene un valor
        /// </summary>
        /// <param name="eval">Expresion a evaluar</param>
        /// <returns>Valor</returns>
        public string GetValue(string eval)
        {
            XPathNavigator nav = _xml.CreateNavigator();

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
                throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.ErrorExecuteExpression), eval), "", _xml.Name, "owl", e);
            }

            #endregion

            return string.Empty;
        }

        #endregion
    }
}