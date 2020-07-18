using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Core;
using Fiive.Owl.Formats.Output.XPML;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Represent a Flat File
    /// </summary>
    public class FlatFileOutput : GenericOutput
    {
        protected override string GenerateSection(SectionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            FlatFileSectionOutput sectionFlat = (FlatFileSectionOutput)section;
            bool hasElements = false;

            #region Obtener informacion de la seccion

            foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
            {
                ElementOutput element = (ElementOutput)_handler.XPMLValidator.GetXPMLObject(new ElementOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);

                if (!element.Hidden) { sb.Append(string.Concat(element.Value, sectionFlat.Separator)); hasElements = true; }
            }

            string resultValue = string.Empty;
            if (sectionFlat.RemoveFinalSeparators) { resultValue = sb.ToString().TrimEnd(sectionFlat.Separator.ToCharArray()); }
            else
            {
                resultValue = sb.ToString();
                if (resultValue.Length > 0) { resultValue = resultValue.GetSafeSubstring(0, resultValue.Length - sectionFlat.Separator.Length); }
            }

            #endregion

            if (hasElements)
            {
                _segmentCount++;
                return resultValue;
            }
            return null; // If all elements are (Oculto="Si")
        }

        protected override string ExtraInformation() { return Environment.NewLine; }

        protected override SectionOutput GetSection(XmlNode node) { return (FlatFileSectionOutput)_handler.XPMLValidator.GetXPMLObject(new FlatFileSectionOutput(), node, _handler); }
    }
}
