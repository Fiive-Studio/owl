using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Represent a SQL Section configuration
    /// </summary>
    public class SqlSectionOutput : SectionOutput
    {
        #region Constructor

        public SqlSectionOutput() { SqlType = SqlType.Select; }

        #endregion

        #region Properties

        public SqlType SqlType { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "sql-type", PropertyName = "SqlType", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "SqlType") { SqlType = (SqlType)Enum.Parse(typeof(SqlType), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
