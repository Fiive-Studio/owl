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
        EDIEstructuraOutput _structureEDI;
        EDISegmentProperties _segmentProperties;

        #endregion

        protected override string GenerateSection(SeccionOutput section, XmlNode node)
        {
            #region Separators

            if (validateSeparator)
            {
                _structureEDI = (EDIEstructuraOutput)_currentEstructuraOutput;
                _segmentProperties = new EDISegmentProperties { DecimalSeparator = _structureEDI.SeparadorDecimalesSalida };

                if (_structureEDI.TerminadorSegmento == char.MinValue) { _structureEDI.TerminadorSegmento = _segmentProperties.SegmentTerminator; }
                else if (_structureEDI.TerminadorSegmento != _segmentProperties.SegmentTerminator) { _segmentProperties.SegmentTerminator = _structureEDI.TerminadorSegmento; }

                if (_structureEDI.SeparadorElementos == char.MinValue) { _structureEDI.SeparadorElementos = _segmentProperties.ElementSeparator; }
                else if (_structureEDI.SeparadorElementos != _segmentProperties.ElementSeparator) { _segmentProperties.ElementSeparator = _structureEDI.SeparadorElementos; }

                if (_structureEDI.SeparadorSubElementos == char.MinValue) { _structureEDI.SeparadorSubElementos = _segmentProperties.SubElementSeparator; }
                else if (_structureEDI.SeparadorSubElementos != _segmentProperties.SubElementSeparator) { _segmentProperties.SubElementSeparator = _structureEDI.SeparadorSubElementos; }

                if (_structureEDI.CaracterEscape == char.MinValue) { _structureEDI.CaracterEscape = _segmentProperties.ReleaseChar; }
                else if (_structureEDI.CaracterEscape != _segmentProperties.ReleaseChar) { _segmentProperties.ReleaseChar = _structureEDI.CaracterEscape; }

                validateSeparator = false;
            }

            #endregion

            #region Hidden Elements

            foreach (XmlNode nElement in _handler.ConfigMap.GetHiddenOutputElements(node))
            {
                ElementoOutput element = (ElementoOutput)_handler.XPMLValidator.GetXPMLObject(new ElementoOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);
            }

            #endregion

            #region Segments

            Type type = Type.GetType(string.Format(OwlAdapterSettings.Settings.MapperEDILibrary, section.Nombre));
            if (type == null) { throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.InvalidSegment), section.Nombre), node.OuterXml, node.Name, section.Nombre); }

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

        protected override EstructuraOutput GetStructure(XmlNode node) { return (EDIEstructuraOutput)_handler.XPMLValidator.GetXPMLObject(new EDIEstructuraOutput(), node, _handler); }

        protected override void StartNewStructure() { validateSeparator = true; }
    }
}
