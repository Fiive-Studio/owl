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
        protected override string GenerateSection(SeccionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder();

            #region Obtener informacion de la seccion

            bool addSeparator = false;
            foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
            {
                ElementoOutput element = (ElementoOutput)_handler.XPMLValidator.GetXPMLObject(new ElementoOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);
                if (!element.Oculto)
                {
                    if (addSeparator) { sb.Append(","); }
                    sb.Append($"\"{element.Nombre}\":\"{element.Valor}\"");
                    addSeparator = true;
                }
            }

            #endregion

            if (section.Repeticiones > 1 || !section.Itera.IsNullOrWhiteSpace())
            {
                if (section.Consecutive > 1) { sb.Insert(0, ",{"); }
                else { sb.Insert(0, "{"); }
                if (section.Consecutive == 1)
                {
                    sb.Insert(0, $"\"{section.Nombre}\":[");
                    if (node.PreviousSibling != null && (node.PreviousSibling.Name == "Elemento" || node.PreviousSibling.Name == "Seccion")) { sb.Insert(0, ","); }
                }
            }
            else
            {
                sb.Insert(0, $"\"{section.Nombre}\":{{");
                if (node.PreviousSibling != null && (node.PreviousSibling.Name == "Elemento" || node.PreviousSibling.Name == "Seccion")) { sb.Insert(0, ","); }
            }

            _segmentCount++;
            return sb.ToString();
        }

        protected override string CloseSection(SeccionOutput section, XmlNode node)
        {
            if ((section.Repeticiones > 1 || !section.Itera.IsNullOrWhiteSpace()) && section.Consecutive == section.Repeticiones) { return "}]"; }
            else { return "}"; }
        }

        public override void GetElementValue(ElementoOutput element, XmlNode node, SeccionOutput section)
        {
            base.GetElementValue(element, node, section);
            element.Valor = element.Valor.Replace("\"", "\\\"").Replace("\\", "\\\\");
        }

        protected override string OpenContent() { return "{"; }

        protected override string CloseContent() { return "}"; }
    }
}
