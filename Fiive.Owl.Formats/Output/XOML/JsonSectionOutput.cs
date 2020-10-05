using Fiive.Owl.Core.XOML;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Formats.Output.XOML
{
    /// <summary>
    /// Represent a Json Section configuration
    /// </summary>
    public class JsonSectionOutput : SectionOutput
    {
        #region Constructor

        public JsonSectionOutput() { }

        #endregion

        #region Properties

        public bool JsonArray { get; set; }

        #endregion

        #region IXOMLObject

        public override XOMLSigning GetSigning()
        {
            XOMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "json-array", PropertyName = "JsonArray", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean });

            return signing;
        }

        #endregion
    }
}
