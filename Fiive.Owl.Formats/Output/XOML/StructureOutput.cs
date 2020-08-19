using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XOML;

namespace Fiive.Owl.Formats.Output.XOML
{
    /// <summary>
    /// Estructura de Salida
    /// </summary>
    public class StructureOutput : IXOMLObject
    {
        #region Properties

        public string Itera { get; set; }
        public string Line { get; set; }
        public string NumberLine { get; set; }
        public bool EventSection { get; set; }
        public bool EventSectionPrevious { get; set; }
        public bool EventSectionGroup { get; set; }
        public bool EventElement { get; set; }
        public bool EventElementSection { get; set; }
        public char InputDecimalSeparator { get; set; }
        public char OutputDecimalSeparator { get; set; }
        public string Id { get; set; }
        public string Base { get; set; }

        #endregion

        #region IXOMLObject

        /// <summary>
        /// Obtiene la firma XOML del objeto
        /// </summary>
        /// <returns>Firma XOML</returns>
        public virtual XOMLSigning GetSigning()
        {
            return new XOMLSigning
            {
                Restrictions = new List<XOMLSigning.XOMLRestriction>()
                {
                    new XOMLSigning.XOMLRestriction { TagName = "itera", PropertyName = "Itera", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "line", PropertyName = "Line", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "number-line", PropertyName = "NumberLine", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "event-section", PropertyName = "EventSection", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean },
                    new XOMLSigning.XOMLRestriction { TagName = "event-section-previous", PropertyName = "EventSectionPrevious", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean },
                    new XOMLSigning.XOMLRestriction { TagName = "event-section-group", PropertyName = "EventSectionGroup", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean },
                    new XOMLSigning.XOMLRestriction { TagName = "event-element", PropertyName = "EventElement", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean },
                    new XOMLSigning.XOMLRestriction { TagName = "event-element-section", PropertyName = "EventElementSection", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean },
                    new XOMLSigning.XOMLRestriction { TagName = "input-decimal-separator", PropertyName = "InputDecimalSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Char },
                    new XOMLSigning.XOMLRestriction { TagName = "output-decimal-separator", PropertyName = "OutputDecimalSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Char },
                    new XOMLSigning.XOMLRestriction { TagName = "id", PropertyName = "Id", Attribute = true, Tag = false, Mandatory = false, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "base", PropertyName = "Base", Attribute = true, Tag = false, Mandatory = false, PropertyType = XOMLPropertyType.String }
                }
            };
        }

        public void SetPropertyValue(string property, string value) { }

        #endregion
    }
}
