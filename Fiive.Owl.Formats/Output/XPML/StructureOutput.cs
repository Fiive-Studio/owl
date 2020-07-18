using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XPML;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Estructura de Salida
    /// </summary>
    public class StructureOutput : IXPMLObject
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

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public virtual XPMLSigning GetSigning()
        {
            return new XPMLSigning
            {
                Restrictions = new List<XPMLSigning.XPMLRestriction>()
                {
                    new XPMLSigning.XPMLRestriction { TagName = "itera", PropertyName = "Itera", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "line", PropertyName = "Line", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "number-line", PropertyName = "NumberLine", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "event-section", PropertyName = "EventSection", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "event-section-previous", PropertyName = "EventSectionPrevious", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "event-section-group", PropertyName = "EventSectionGroup", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "event-element", PropertyName = "EventElement", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "event-element-section", PropertyName = "EventElementSection", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "input-decimal-separator", PropertyName = "InputDecimalSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { TagName = "output-decimal-separator", PropertyName = "OutputDecimalSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { TagName = "id", PropertyName = "Id", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "base", PropertyName = "Base", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String }
                }
            };
        }

        public void SetPropertyValue(string property, string value) { }

        #endregion
    }
}
