using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.XOML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XOML
{
    public class XmlElementOutput : ElementOutput
    {
        #region Properties

        public XmlElementType XmlElementType { get; set; }

        public bool MandatoryValue { get; set; }

        public bool? ReleaseChars { get; set; }
        public bool XmlValue { get; set; }

        #endregion

        #region IXOMLObject

        public override XOMLSigning GetSigning()
        {
            XOMLSigning signing = base.GetSigning();
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "xml-element-type", PropertyName = "XmlElementType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Enum });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "mandatory-value", PropertyName = "MandatoryValue", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "release-chars", PropertyName = "ReleaseChars", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "xml-value", PropertyName = "XmlValue", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "XmlElementType") { XmlElementType = (XmlElementType)Enum.Parse(typeof(XmlElementType), value.XOMLName()); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
