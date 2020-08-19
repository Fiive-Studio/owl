using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Formats.Output.XOML;
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
        /// Current structure
        /// </summary>
        XmlStructureOutput _structureXml;
        bool _validateStructure = true;

        #endregion

        protected override string GenerateSection(SectionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            XmlSectionOutput sectionXml = (XmlSectionOutput)section;

            #region Get the XmlValue

            if (_validateStructure)
            {
                _structureXml = (XmlStructureOutput)_currentEstructuraOutput;
                _validateStructure = false;
            }

            #endregion

            #region Obtener informacion de la seccion

            string internalValue = string.Empty;

            // Se valida ya que lo comentarios y CData se construyen de otra forma
            if (sectionXml.XmlTagType != XmlTagType.Comment && sectionXml.XmlTagType != XmlTagType.CData)
            { sb.Append("<" + sectionXml.Name); }

            #region Recorre elementos

            foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
            {
                XmlElementOutput element = (XmlElementOutput)_handler.XOMLValidator.GetXOMLObject(new XmlElementOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);

                if (element.XmlValue)
                {
                    if (element.XmlElementType == XmlElementType.NotApply)
                    { internalValue += element.Value; }
                    else if (element.XmlElementType == XmlElementType.Comment)
                    { internalValue += string.Format("<!--{0}-->", element.Value); }
                    else if (element.XmlElementType == XmlElementType.CData)
                    { internalValue += string.Format("<![CDATA[{0}]]>", element.Value); }
                }
                else
                {
                    if (!element.Hidden)
                    {
                        if (!element.MandatoryValue || (element.MandatoryValue && !string.IsNullOrEmpty(element.Value)))
                        { sb.Append(string.Format(" {0}=\"{1}\"", element.Name, element.Value)); }
                    }
                }
            }

            #endregion

            #region Finalizar seccion

            if (sectionXml.XmlTagType == XmlTagType.Complex) { sb.Append(string.Format(">{0}", internalValue)); }
            else if (sectionXml.XmlTagType == XmlTagType.Simple) { sb.Append("/>"); }
            else if (sectionXml.XmlTagType == XmlTagType.Comment) { sb.Append(string.Format("<!--{0}-->", internalValue)); }
            else if (sectionXml.XmlTagType == XmlTagType.CData) { sb.Append(string.Format("<![CDATA[{0}]]>", internalValue)); }

            _segmentCount++;

            #endregion

            #endregion

            return sb.ToString();
        }

        protected override string CloseSection(SectionOutput section, XmlNode node)
        {
            XmlSectionOutput sectionXml = (XmlSectionOutput)section;
            if (sectionXml.XmlTagType == XmlTagType.Complex) { return string.Format("</{0}>", sectionXml.Name); }
            return string.Empty;
        }

        protected override SectionOutput GetSection(XmlNode node) { return (XmlSectionOutput)_handler.XOMLValidator.GetXOMLObject(new XmlSectionOutput(), node, _handler); }

        protected override StructureOutput GetStructure(XmlNode node) { return (XmlStructureOutput)_handler.XOMLValidator.GetXOMLObject(new XmlStructureOutput(), node, _handler); }

        protected override void StartNewStructure() { _validateStructure = true; }

        public override void GetElementValue(ElementOutput element, XmlNode node, SectionOutput section)
        {
            XmlElementOutput elementXml = (XmlElementOutput)element;
            if (!elementXml.ReleaseChars.HasValue) { elementXml.ReleaseChars = _structureXml.XmlReleaseChars; }

            base.GetElementValue(element, node, section);
            if (elementXml.ReleaseChars.Value) { element.Value = SecurityElement.Escape(element.Value); }
        }
    }
}
