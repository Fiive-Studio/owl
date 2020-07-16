using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Formats.Output.XPML;
using System.Text.RegularExpressions;
using System.Security;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Represent a Xml
    /// </summary>
    public class XmlOutput : GenericOutput
    {
        #region Variables

        /// <summary>
        /// Nombre por defecto del elemento que trae el valor interno de la etiqueta
        /// </summary>
        readonly string _defaultXmlValue = "PGA_ValorXML";
        /// <summary>
        /// Indica si se valida el nombre del atributo del nombre de los valores de las etiquetas
        /// </summary>
        bool _validateXmlValue = true;
        /// <summary>
        /// Current structure
        /// </summary>
        XmlEstructuraOutput _structureXml;

        #endregion

        protected override string GenerateSection(SeccionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            XmlSeccionOutput sectionXml = (XmlSeccionOutput)section;

            #region Get the XmlValue

            if (_validateXmlValue)
            {
                // Valida si el nombre del elemento de valor es cambiado en la configuracion
                _structureXml = (XmlEstructuraOutput)_currentEstructuraOutput;
                if (_structureXml.XMLValor.IsNullOrWhiteSpace()) { _structureXml.XMLValor = _defaultXmlValue; }
                _validateXmlValue = false;
            }

            #endregion

            #region Obtener informacion de la seccion

            if (sectionXml.TipoEtiqueta == TipoEtiquetaXml.Cierre) { sb.Append(string.Format("</{0}>", sectionXml.Nombre)); }
            else
            {
                string internalValue = string.Empty;

                // Se valida ya que lo comentarios y CData se construyen de otra forma
                if (sectionXml.TipoEtiqueta != TipoEtiquetaXml.Comentario && sectionXml.TipoEtiqueta != TipoEtiquetaXml.CData)
                { sb.Append("<" + sectionXml.Nombre); }

                #region Recorre elementos

                foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
                {
                    XmlElementoOutput element = (XmlElementoOutput)_handler.XPMLValidator.GetXPMLObject(new XmlElementoOutput(), nElement, _handler);
                    GetElementValue(element, nElement, section);

                    if (element.Nombre == _structureXml.XMLValor)
                    {
                        if (element.TipoElementoXml == TipoElementoXml.NoAplica)
                        { internalValue += element.Valor; }
                        else if (element.TipoElementoXml == TipoElementoXml.Comentario)
                        { internalValue += string.Format("<!--{0}-->", element.Valor); }
                        else if (element.TipoElementoXml == TipoElementoXml.CData)
                        { internalValue += string.Format("<![CDATA[{0}]]>", element.Valor); }
                    }
                    else
                    {
                        if (!element.Oculto)
                        {
                            if (!element.ValorRequerido || (element.ValorRequerido && !string.IsNullOrEmpty(element.Valor)))
                            { sb.Append(string.Format(" {0}=\"{1}\"", element.Nombre, element.Valor)); }
                        }
                    }
                }

                #endregion

                #region Finalizar seccion

                if (sectionXml.TipoEtiqueta == TipoEtiquetaXml.Compuesta) { sb.Append(string.Format(">{0}", internalValue)); }
                else if (sectionXml.TipoEtiqueta == TipoEtiquetaXml.Simple) { sb.Append("/>"); }
                else if (sectionXml.TipoEtiqueta == TipoEtiquetaXml.Comentario) { sb.Append(string.Format("<!--{0}-->", internalValue)); }
                else if (sectionXml.TipoEtiqueta == TipoEtiquetaXml.CData) { sb.Append(string.Format("<![CDATA[{0}]]>", internalValue)); }
                else if (sectionXml.TipoEtiqueta == TipoEtiquetaXml.Apertura) { sb.Append(">"); }

                _segmentCount++;

                #endregion
            }

            #endregion

            return sb.ToString();
        }

        protected override string CloseSection(SeccionOutput section, XmlNode node)
        {
            XmlSeccionOutput sectionXml = (XmlSeccionOutput)section;
            if (sectionXml.TipoEtiqueta == TipoEtiquetaXml.Compuesta) { return string.Format("</{0}>", sectionXml.Nombre); }
            return string.Empty;
        }

        protected override SeccionOutput GetSection(XmlNode node) { return (XmlSeccionOutput)_handler.XPMLValidator.GetXPMLObject(new XmlSeccionOutput(), node, _handler); }

        protected override EstructuraOutput GetStructure(XmlNode node) { return (XmlEstructuraOutput)_handler.XPMLValidator.GetXPMLObject(new XmlEstructuraOutput(), node, _handler); }

        protected override void StartNewStructure() { _validateXmlValue = true; }

        public override void GetElementValue(ElementoOutput element, XmlNode node, SeccionOutput section)
        {
            XmlElementoOutput elementXml = (XmlElementoOutput)element;
            if (!elementXml.EscaparCaracteres.HasValue) { elementXml.EscaparCaracteres = _structureXml.EscaparCaracteres; }

            base.GetElementValue(element, node, section);
            if (elementXml.EscaparCaracteres.Value) { element.Valor = SecurityElement.Escape(element.Valor); }
        }
    }
}
