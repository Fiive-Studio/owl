using Fiive.Owl.Core.XOML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XOML
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

        #region IXOMLObject

        public override XOMLSigning GetSigning()
        {
            XOMLSigning signing = base.GetSigning();
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "sql-element-type", PropertyName = "SqlElementType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Enum });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "where-type", PropertyName = "WhereType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Enum });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "mandatory-value", PropertyName = "MandatoryValue", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean });

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
