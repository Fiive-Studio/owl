using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    public class XmlElementOutput : ElementOutput
    {
        #region Properties

        public XmlElementType XmlElementType { get; set; }

        public bool MandatoryValue { get; set; }

        public bool? ReleaseChars { get; set; }
        public bool XmlValue { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "xml-element-type", PropertyName = "XmlElementType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "mandatory-value", PropertyName = "MandatoryValue", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "release-chars", PropertyName = "ReleaseChars", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "xml-value", PropertyName = "XmlValue", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "XmlElementType") { XmlElementType = (XmlElementType)Enum.Parse(typeof(XmlElementType), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
