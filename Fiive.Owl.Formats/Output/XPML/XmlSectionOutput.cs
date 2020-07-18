using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Represent a Xml Section configuration
    /// </summary>
    public class XmlSectionOutput : SectionOutput
    {
        #region Constructor

        public XmlSectionOutput() { XmlTagType = XmlTagType.Complex; }

        #endregion

        #region Properties

        public XmlTagType XmlTagType { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "xml-tag-type", PropertyName = "XmlTagType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "XmlTagType") { XmlTagType = (XmlTagType)Enum.Parse(typeof(XmlTagType), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
