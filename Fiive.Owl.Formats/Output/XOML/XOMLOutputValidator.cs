using Fiive.Owl.Core;
using Fiive.Owl.Core.XOML;
using Fiive.Owl.Core.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Fiive.Owl.Formats.Output.XOML
{
    /// <summary>
    /// Output Validator XOML
    /// </summary>
    public class XOMLOutputValidator: XOMLValidator
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
        public IEDISegment GetEDISegment(IEDISegment segment, XmlNode node, OwlHandler handler, SectionOutput section, GenericOutput output)
        {
            foreach (XmlNode nElement in handler.ConfigMap.GetNotHiddenOutputElements(node))
            {
                ElementOutput element = (ElementOutput)handler.XOMLValidator.GetXOMLObject(new ElementOutput(), nElement, handler);
                output.GetElementValue(element, nElement, section);
                SetProperty(element.Name, segment, element.Value);
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
        public IANSISegment GetANSISegment(IANSISegment segment, XmlNode node, OwlHandler handler, SectionOutput section, GenericOutput output)
        {
            foreach (XmlNode nElement in handler.ConfigMap.GetNotHiddenOutputElements(node))
            {
                ElementOutput element = (ElementOutput)handler.XOMLValidator.GetXOMLObject(new ElementOutput(), nElement, handler);
                output.GetElementValue(element, nElement, section);
                SetProperty(element.Name, segment, element.Value);
            }

            return segment;
        }

        #endregion
    }
}
