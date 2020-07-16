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
        protected override string GenerateSection(SeccionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            FlatFileSeccionOutput sectionFlat = (FlatFileSeccionOutput)section;
            bool hasElements = false;

            #region Obtener informacion de la seccion

            foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
            {
                ElementoOutput element = (ElementoOutput)_handler.XPMLValidator.GetXPMLObject(new ElementoOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);

                if (!element.Oculto) { sb.Append(string.Concat(element.Valor, sectionFlat.Separador)); hasElements = true; }
            }

            string resultValue = string.Empty;
            if (sectionFlat.QuitarSeparadoresFinal) { resultValue = sb.ToString().TrimEnd(sectionFlat.Separador.ToCharArray()); }
            else
            {
                resultValue = sb.ToString();
                if (resultValue.Length > 0) { resultValue = resultValue.GetSafeSubstring(0, resultValue.Length - sectionFlat.Separador.Length); }
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

        protected override SeccionOutput GetSection(XmlNode node) { return (FlatFileSeccionOutput)_handler.XPMLValidator.GetXPMLObject(new FlatFileSeccionOutput(), node, _handler); }
    }
}
