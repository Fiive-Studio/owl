using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Formats.Output.XPML;
using Fiive.Owl.Core.Adapters;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Output
{
    public class ANSIOutput : GenericOutput
    {
        #region Variables

        /// <summary>
        /// Indicate if is necesary validate the separator
        /// </summary>
        bool validateSeparator = true;
        /// <summary>
        /// Current structure
        /// </summary>
        ANSIStructureOutput _structureANSI;
        ANSISegmentProperties _segmentProperties;

        #endregion

        protected override string GenerateSection(SectionOutput section, XmlNode node)
        {
            #region Separators

            if (validateSeparator)
            {
                _structureANSI = (ANSIStructureOutput)_currentEstructuraOutput;
                _segmentProperties = new ANSISegmentProperties();

                if (_structureANSI.SegmentSeparator == char.MinValue) { _structureANSI.SegmentSeparator = _segmentProperties.SegmentTerminator; }
                else if (_structureANSI.SegmentSeparator != _segmentProperties.SegmentTerminator) { _segmentProperties.SegmentTerminator = _structureANSI.SegmentSeparator; }

                if (_structureANSI.ElementSeparator == char.MinValue) { _structureANSI.ElementSeparator = _segmentProperties.ElementSeparator; }
                else if (_structureANSI.ElementSeparator != _segmentProperties.ElementSeparator) { _segmentProperties.ElementSeparator = _structureANSI.ElementSeparator; }

                if (_structureANSI.ReleaseChar == char.MinValue) { _structureANSI.ReleaseChar = _segmentProperties.ReleaseChar; }
                else if (_structureANSI.ReleaseChar != _segmentProperties.ReleaseChar) { _segmentProperties.ReleaseChar = _structureANSI.ReleaseChar; }

                validateSeparator = false;
            }

            #endregion

            #region Hidden Elements

            foreach (XmlNode nElement in _handler.ConfigMap.GetHiddenOutputElements(node))
            {
                ElementOutput element = (ElementOutput)_handler.XPMLValidator.GetXPMLObject(new ElementOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);
            }

            #endregion

            #region Segments

            string name = section.Name;
            if (name == "CON") { name = "CON_"; }
            Type type = Type.GetType(string.Format(OwlAdapterSettings.Settings.MapperANSILibrary, name));
            if (type == null) { throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.InvalidSegment), section.Name), node.OuterXml, node.Name, section.Name); }

            IANSISegment segment = (IANSISegment)Activator.CreateInstance(type);
            segment.Properties = _segmentProperties;

            #endregion

            if (segment != null)
            {
                string value = XPMLOutputValidator.GetANSISegment(segment, node, _handler, section, this).ToString();
                if (!value.IsNullOrWhiteSpace())
                {
                    _segmentCount++;
                    return value;
                }
            }
            return null;
        }

        protected override StructureOutput GetStructure(XmlNode node) { return (ANSIStructureOutput)_handler.XPMLValidator.GetXPMLObject(new ANSIStructureOutput(), node, _handler); }

        protected override void StartNewStructure() { validateSeparator = true; }
    }
}
