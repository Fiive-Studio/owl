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
    public class EDIOutput : GenericOutput
    {
        #region Variables

        /// <summary>
        /// Indicate if is necesary validate the separator
        /// </summary>
        bool validateSeparator = true;
        /// <summary>
        /// Current structure
        /// </summary>
        EDIStructureOutput _structureEDI;
        EDISegmentProperties _segmentProperties;

        #endregion

        protected override string GenerateSection(SectionOutput section, XmlNode node)
        {
            #region Separators

            if (validateSeparator)
            {
                _structureEDI = (EDIStructureOutput)_currentEstructuraOutput;
                _segmentProperties = new EDISegmentProperties { DecimalSeparator = _structureEDI.OutputDecimalSeparator };

                if (_structureEDI.SegmentSeparator == char.MinValue) { _structureEDI.SegmentSeparator = _segmentProperties.SegmentTerminator; }
                else if (_structureEDI.SegmentSeparator != _segmentProperties.SegmentTerminator) { _segmentProperties.SegmentTerminator = _structureEDI.SegmentSeparator; }

                if (_structureEDI.ElementGroupSeparator == char.MinValue) { _structureEDI.ElementGroupSeparator = _segmentProperties.ElementSeparator; }
                else if (_structureEDI.ElementGroupSeparator != _segmentProperties.ElementSeparator) { _segmentProperties.ElementSeparator = _structureEDI.ElementGroupSeparator; }

                if (_structureEDI.ElementSeparator == char.MinValue) { _structureEDI.ElementSeparator = _segmentProperties.SubElementSeparator; }
                else if (_structureEDI.ElementSeparator != _segmentProperties.SubElementSeparator) { _segmentProperties.SubElementSeparator = _structureEDI.ElementSeparator; }

                if (_structureEDI.ReleaseChar == char.MinValue) { _structureEDI.ReleaseChar = _segmentProperties.ReleaseChar; }
                else if (_structureEDI.ReleaseChar != _segmentProperties.ReleaseChar) { _segmentProperties.ReleaseChar = _structureEDI.ReleaseChar; }

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

            Type type = Type.GetType(string.Format(OwlAdapterSettings.Settings.MapperEDILibrary, section.Name));
            if (type == null) { throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.InvalidSegment), section.Name), node.OuterXml, node.Name, section.Name); }

            IEDISegment segment = (IEDISegment)Activator.CreateInstance(type);
            segment.Properties = _segmentProperties;

            #endregion

            if (segment != null)
            {
                string value = XPMLOutputValidator.GetEDISegment(segment, node, _handler, section, this).ToString();
                if (!value.IsNullOrWhiteSpace())
                {
                    _segmentCount++;
                    return value;
                }
            }

            return null;
        }

        protected override StructureOutput GetStructure(XmlNode node) { return (EDIStructureOutput)_handler.XPMLValidator.GetXPMLObject(new EDIStructureOutput(), node, _handler); }

        protected override void StartNewStructure() { validateSeparator = true; }
    }
}
