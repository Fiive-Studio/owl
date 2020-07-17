using Fiive.Owl.Core;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Output Validator XPML
    /// </summary>
    public class XPMLOutputValidator: XPMLValidator
    {
        #region Publics

        /// <summary>
        /// Add data in the EDI segment
        /// </summary>
        /// <param name="segment">Segment</param>
        /// <param name="node">Node with the configuration</param>
        /// <param name="handler">Orquestator</param>
        /// <param name="section">Parent Section</param>
        /// <param name="output">Output</param>
        /// <returns>Objeto con los datos</returns>
        public IEDISegment GetEDISegment(IEDISegment segment, XmlNode node, OwlHandler handler, SeccionOutput section, GenericOutput output)
        {
            foreach (XmlNode nElement in handler.ConfigMap.GetNotHiddenOutputElements(node))
            {
                ElementoOutput element = (ElementoOutput)handler.XPMLValidator.GetXPMLObject(new ElementoOutput(), nElement, handler);
                output.GetElementValue(element, nElement, section);
                SetProperty(element.Nombre, segment, element.Valor);
            }

            return segment;
        }

        /// <summary>
        /// Add data in the EDI segment
        /// </summary>
        /// <param name="segment">Segment</param>
        /// <param name="node">Node with the configuration</param>
        /// <param name="handler">Orquestator</param>
        /// <param name="section">Parent Section</param>
        /// <param name="output">Output</param>
        /// <returns>Objeto con los datos</returns>
        public IANSISegment GetANSISegment(IANSISegment segment, XmlNode node, OwlHandler handler, SeccionOutput section, GenericOutput output)
        {
            foreach (XmlNode nElement in handler.ConfigMap.GetNotHiddenOutputElements(node))
            {
                ElementoOutput element = (ElementoOutput)handler.XPMLValidator.GetXPMLObject(new ElementoOutput(), nElement, handler);
                output.GetElementValue(element, nElement, section);
                SetProperty(element.Nombre, segment, element.Valor);
            }

            return segment;
        }

        #endregion
    }
}
