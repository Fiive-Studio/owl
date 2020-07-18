using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    public class SqlElementOutput : ElementOutput
    {
        #region Constructor

        public SqlElementOutput()
        {
            SqlElementType = SqlElementType.Select;
            WhereType = WhereType.Equal;
        }

        #endregion

        #region Properties

        public SqlElementType SqlElementType { get; set; }

        public WhereType WhereType { get; set; }

        public bool MandatoryValue { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "sql-element-type", PropertyName = "SqlElementType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "where-type", PropertyName = "WhereType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "mandatory-value", PropertyName = "MandatoryValue", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "SqlElementType") { SqlElementType = (SqlElementType)Enum.Parse(typeof(SqlElementType), value); }
            else if (property == "WhereType") { WhereType = (WhereType)Enum.Parse(typeof(WhereType), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
