using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
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

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "json-array", PropertyName = "JsonArray", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        #endregion
    }
}
