using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Formats.Output.XPML;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Represent a Json
    /// </summary>
    public class JsonOutput : GenericOutput
    {
        protected override string GenerateSection(SectionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            JsonSectionOutput sectionJson = (JsonSectionOutput)section;

            #region Obtener informacion de la seccion

            bool addSeparator = false;
            foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
            {
                ElementOutput element = (ElementOutput)_handler.XPMLValidator.GetXPMLObject(new ElementOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);
                if (!element.Hidden)
                {
                    if (addSeparator) { sb.Append(","); }
                    sb.Append($"\"{element.Name}\":\"{element.Value}\"");
                    addSeparator = true;
                }
            }

            #endregion

            if (section.Repetitions > 1 || !section.Itera.IsNullOrWhiteSpace() || sectionJson.JsonArray)
            {
                if (section.Consecutive > 1) { sb.Insert(0, ",{"); }
                else { sb.Insert(0, "{"); }
                if (section.Consecutive == 1)
                {
                    sb.Insert(0, $"\"{section.Name}\":[");
                    if (node.PreviousSibling != null && (node.PreviousSibling.Name == "element" || node.PreviousSibling.Name == "section")) { sb.Insert(0, ","); }
                }
            }
            else
            {
                sb.Insert(0, $"\"{section.Name}\":{{");
                if (node.PreviousSibling != null && (node.PreviousSibling.Name == "element" || node.PreviousSibling.Name == "section")) { sb.Insert(0, ","); }
            }

            _segmentCount++;
            return sb.ToString();
        }

        protected override string CloseSection(SectionOutput section, XmlNode node)
        {
            JsonSectionOutput sectionJson = (JsonSectionOutput)section;

            if ((section.Repetitions > 1 || !section.Itera.IsNullOrWhiteSpace() || sectionJson.JsonArray) && section.Consecutive == section.Repetitions) { return "}]"; }
            else { return "}"; }
        }

        public override void GetElementValue(ElementOutput element, XmlNode node, SectionOutput section)
        {
            base.GetElementValue(element, node, section);
            element.Value = element.Value.Replace("\"", "\\\"").Replace("\\", "\\\\");
        }

        protected override string OpenContent() { return "{"; }

        protected override string CloseContent() { return "}"; }
    }
}
