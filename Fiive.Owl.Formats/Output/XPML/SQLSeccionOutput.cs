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
    public class SQLSeccionOutput : SeccionOutput
    {
        #region Constructor

        public SQLSeccionOutput() { TipoSQL = TipoSQL.Select; }

        #endregion

        #region Properties

        public TipoSQL TipoSQL { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { Name = "TipoSQL", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "TipoSQL") { TipoSQL = (TipoSQL)Enum.Parse(typeof(TipoSQL), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
