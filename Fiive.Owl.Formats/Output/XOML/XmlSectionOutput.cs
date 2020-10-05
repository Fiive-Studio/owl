using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.XOML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XOML
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

        #region IXOMLObject

        public override XOMLSigning GetSigning()
        {
            XOMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "xml-tag-type", PropertyName = "XmlTagType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Enum });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "XmlTagType") { XmlTagType = (XmlTagType)Enum.Parse(typeof(XmlTagType), value.XOMLName()); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
