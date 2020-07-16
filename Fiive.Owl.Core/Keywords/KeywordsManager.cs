using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Fiive.Owl.Core.Input;
using System.Xml;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.Exceptions;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Provee metodos para manipular las palabras clave
    /// </summary>
    public class KeywordsManager
    {
        #region Constructor

        public KeywordsManager()
        {
            KeywordsList = Enum.GetNames(typeof(KeywordsType));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el valor por defecto para valores alfanumericos cuando se esta generando una instancia
        /// </summary>
        public string DefaultAlphanumericInstanceValue { get { return "VALOR_INSTANCIA"; } }

        /// <summary>
        /// Obtiene el valor por defecto para valores numericos cuando se esta generando una instancia
        /// </summary>
        public string DefaultNumericInstanceValue { get { return "1234567890"; } }

        /// <summary>
        /// Get the keywords list
        /// </summary>
        public string[] KeywordsList { get; private set; }

        #endregion

        #region Publics

        /// <summary>
        /// Get the Keyword
        /// </summary>
        /// <param name="node">Configuration node</param>
        /// <param name="handler">Orquestation</param>
        /// <returns>Keyword Object</returns>
        public IKeyword GetKeyword(XmlNode node, OwlHandler handler)
        {
            if (node == null) { return null; }

            #region XPML

            if (node.HasChildNodes)
            {
                XmlNode nHijo = handler.ConfigMap.GetElementValueNode(node);
                if (nHijo != null) { return GetXPMLKeyword(nHijo.FirstChild, handler); }
            }

            #endregion

            #region Atributo

            #region Predeterminado

            if (node.Attributes["Predeterminado"] != null) { return new Predeterminado { Valor = node.Attributes["Predeterminado"].Value }; }

            #endregion

            #region Variable

            if (node.Attributes["Variable"] != null) { return new Variable { Valor = node.Attributes["Variable"].Value }; }

            #endregion

            #region Reservada

            if (node.Attributes["Reservada"] != null) { return new Reservada { Valor = node.Attributes["Reservada"].Value }; }

            #endregion

            #region Buscar

            if (!handler.Settings.Instance && node.Attributes["Buscar"] != null) { return new Buscar { Valor = node.Attributes["Buscar"].Value }; }

            #endregion

            #endregion

            return null;
        }

        /// <summary>
        /// Get the Keyword
        /// </summary>
        /// <param name="values">Configuration node</param>
        /// <param name="handler">Orquestation</param>
        /// <returns>Keyword Object</returns>
        public IKeyword GetInlineKeyword(string[] values, OwlHandler handler)
        {
            #region Predeterminado

            if (values.GetSafeValue(0) == "Predeterminado") { return new Predeterminado { Valor = values.GetSafeValue(1) }; }

            #endregion

            #region Variable

            if (values.GetSafeValue(0) == "Variable") { return new Variable { Valor = values.GetSafeValue(1) }; }

            #endregion

            #region Reservada

            if (values.GetSafeValue(0) == "Reservada") { return new Reservada { Valor = values.GetSafeValue(1) }; }

            #endregion

            #region Buscar

            if (!handler.Settings.Instance && values.GetSafeValue(0) == "Buscar") { return new Buscar { Valor = values.GetSafeValue(1) }; }

            #endregion

            return null;
        }

        /// <summary>
        /// Get the Keyword
        /// </summary>
        /// <param name="node">Configuration node</param>
        /// <param name="handler">Orquestation</param>
        /// <returns>Keyword Object</returns>
        public IKeyword GetXPMLKeyword(XmlNode node, OwlHandler handler)
        {
            if (node == null) { return null; }

            #region Instancia

            // Para las instancias solo se permite Predeterminado, Variable y Reservada
            if (handler.Settings.Instance && (node.Name != "Predeterminado" && node.Name != "Variable" && node.Name != "Reservada")) { return null; }

            #endregion

            #region Value

            if (KeywordsList.Contains(node.Name))
            {
                IXPMLObject keywordInstance = (IXPMLObject)Activator.CreateInstance(Type.GetType(string.Format("Fiive.Owl.Core.Keywords.{0}", node.Name)));
                IKeyword keyword = (IKeyword)handler.XPMLValidator.GetXPMLObject(keywordInstance, node, handler);

                KeywordsType keywordType = (KeywordsType)Enum.Parse(typeof(KeywordsType), node.Name);
                keyword.KeywordType = keywordType;
                return keyword;
            }

            #endregion

            return null;
        }

        #endregion
    }
}
