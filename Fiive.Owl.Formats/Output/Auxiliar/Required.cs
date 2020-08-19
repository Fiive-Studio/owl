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
    /// Represent the requireds fields
    /// </summary>
    public class Required
    {
        #region Vars

        Dictionary<string, string> _fieldsRequireds = new Dictionary<string, string>();
        XmlNode _nodeRequireds = null;

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene la cantidad de campos requeridos
        /// </summary>
        public int Count { get { return _fieldsRequireds.Count; } }

        /// <summary>
        /// Required Type
        /// </summary>
        RequiredType Type { get; set; }

        #endregion

        #region Constructor

        public Required(RequiredType requiredType) { Type = requiredType; }

        #endregion

        #region Publicos

        /// <summary>
        /// Agrega los campo requeridos
        /// </summary>
        /// <param name="nodo">Nodo con los campos</param>
        public void AddRequireds(XmlNode nodo)
        {
            _nodeRequireds = nodo;
            if (_nodeRequireds != null) { ProcessNode(_nodeRequireds); }
        }

        /// <summary>
        /// Add the requireds fields
        /// </summary>
        /// <param name="requireds">Requireds list</param>
        public void AddRequireds(string requireds)
        {
            if (requireds.IsNullOrWhiteSpace()) { return; }
            foreach (string field in requireds.Split(',')) { _fieldsRequireds.Add(field, string.Empty); }
        }

        /// <summary>
        /// Agrega un valor a un campo
        /// </summary>
        /// <param name="nombreCampo">Nombre del campo</param>
        /// <param name="valorCampo">Valor del campo</param>
        public void AddValue(string nombreCampo, string valorCampo)
        {
            if (_fieldsRequireds.ContainsKey(nombreCampo)) { _fieldsRequireds[nombreCampo] = valorCampo; }
        }

        /// <summary>
        /// Valida los campos requeridos
        /// </summary>
        /// <returns>true si los valida correctamente, de lo contrario false</returns>
        public bool Validate()
        {
            if (Type == RequiredType.Attribute)
            {
                foreach (KeyValuePair<string, string> field in _fieldsRequireds) { if (string.IsNullOrEmpty(field.Value)) { return false; } }
            }
            else if (Type == RequiredType.Node) { return ValidateNodes(_nodeRequireds); }

            return true;
        }

        /// <summary>
        /// Obtiene la lista de requeridos
        /// </summary>
        /// <returns>IEnumerable con la lista de requeridos</returns>
        public IEnumerable<string> GetRequireds()
        {
            List<string> lstTemp = new List<string>();
            lstTemp.AddRange(from d in _fieldsRequireds select d.Key);
            foreach (string requerido in lstTemp) { yield return requerido; }
        }

        #endregion

        #region Privados

        /// <summary>
        /// Metodo recursivo para obtener los campos requeridos
        /// </summary>
        /// <param name="nodo">Nodo actual</param>
        private void ProcessNode(XmlNode nodo)
        {
            foreach (XmlNode nodoHijo in nodo.ChildNodes)
            {
                if (nodoHijo.Name != "Campo") { throw new OwlException(string.Format(ETexts.GT(ErrorType.TagInvalid), nodoHijo.Name, "Requeridos")); }

                if (nodoHijo.FirstChild != null && nodoHijo.FirstChild.NodeType == XmlNodeType.Element)
                {
                    if (nodoHijo.FirstChild.Name == "Requeridos") { ProcessNode(nodoHijo.FirstChild); }
                    else { throw new OwlException(string.Format(ETexts.GT(ErrorType.TagInvalid), nodoHijo.FirstChild.Name, "Requeridos")); }
                }
                else { if (!_fieldsRequireds.ContainsKey(nodoHijo.InnerText)) { _fieldsRequireds.Add(nodoHijo.InnerText, string.Empty); } }
            }
        }

        /// <summary>
        /// Metodo recursivo para obtener los campos requeridos
        /// </summary>
        /// <param name="nodo">Nodo actual</param>
        private bool ValidateNodes(XmlNode nodo)
        {
            if (nodo == null) { return true; }

            int intContador = 1;
            bool booEstado = true;

            foreach (XmlNode nodoHijo in nodo.ChildNodes)
            {
                bool booValActual = false;

                if (nodoHijo.FirstChild != null && nodoHijo.FirstChild.NodeType == XmlNodeType.Element)
                {
                    booValActual = ValidateNodes(nodoHijo.FirstChild);
                    if (intContador == 1) { booEstado = booValActual; }
                }
                else
                {
                    if (intContador == 1) { if (string.IsNullOrEmpty(_fieldsRequireds[nodoHijo.InnerText])) { booEstado = false; } }
                    else { booValActual = !string.IsNullOrEmpty(_fieldsRequireds[nodoHijo.InnerText]); }
                }

                if (intContador != 1)
                {
                    string operadorLogico = nodoHijo.Attributes["OperadorLogico"] != null ? nodoHijo.Attributes["OperadorLogico"].Value : string.Empty;
                    if (operadorLogico == "O") { booEstado = booEstado || booValActual; }
                    else if (operadorLogico == "Y") { booEstado = booEstado && booValActual; }
                    else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XOMLPropertyInvalidValue), operadorLogico, "OperadorLogico")); }
                }

                intContador++;
            }

            return booEstado;
        }

        #endregion

        public enum RequiredType { Attribute, Node }
    }
}
