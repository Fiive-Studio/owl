using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Formats.Output.XPML;
using Fiive.Owl.Core.Mapper;
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
        ANSIEstructuraOutput _structureANSI;
        ANSISegmentProperties _segmentProperties;

        #endregion

        protected override string GenerateSection(SeccionOutput section, XmlNode node)
        {
            #region Separators

            if (validateSeparator)
            {
                _structureANSI = (ANSIEstructuraOutput)_currentEstructuraOutput;
                _segmentProperties = new ANSISegmentProperties();

                if (_structureANSI.TerminadorSegmento == char.MinValue) { _structureANSI.TerminadorSegmento = _segmentProperties.SegmentTerminator; }
                else if (_structureANSI.TerminadorSegmento != _segmentProperties.SegmentTerminator) { _segmentProperties.SegmentTerminator = _structureANSI.TerminadorSegmento; }

                if (_structureANSI.SeparadorElementos == char.MinValue) { _structureANSI.SeparadorElementos = _segmentProperties.ElementSeparator; }
                else if (_structureANSI.SeparadorElementos != _segmentProperties.ElementSeparator) { _segmentProperties.ElementSeparator = _structureANSI.SeparadorElementos; }

                if (_structureANSI.CaracterEscape == char.MinValue) { _structureANSI.CaracterEscape = _segmentProperties.ReleaseChar; }
                else if (_structureANSI.CaracterEscape != _segmentProperties.ReleaseChar) { _segmentProperties.ReleaseChar = _structureANSI.CaracterEscape; }

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

            string name = section.Nombre;
            if (name == "CON") { name = "CON_"; }
            Type type = Type.GetType(string.Format(PGAMapperSettings.Settings.MapperANSILibrary, name));
            if (type == null) { throw new OwlSectionException(string.Format(ETexts.GT(ErrorType.InvalidSegment), section.Nombre), node.OuterXml, node.Name, section.Nombre); }

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

        protected override EstructuraOutput GetStructure(XmlNode node) { return (ANSIEstructuraOutput)_handler.XPMLValidator.GetXPMLObject(new ANSIEstructuraOutput(), node, _handler); }

        protected override void StartNewStructure() { validateSeparator = true; }
    }
}
