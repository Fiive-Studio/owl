using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    public class SQLElementoOutput : ElementoOutput
    {
        #region Constructor

        public SQLElementoOutput()
        {
            TipoElementoSQL = TipoElementoSQL.Select;
            TipoWhere = TipoWhere.Equal;
        }

        #endregion

        #region Properties

        public TipoElementoSQL TipoElementoSQL { get; set; }

        public TipoWhere TipoWhere { get; set; }

        public bool ValorRequerido { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "TipoElementoSQL", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "TipoWhere", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "ValorRequerido", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "TipoElementoSQL") { TipoElementoSQL = (TipoElementoSQL)Enum.Parse(typeof(TipoElementoSQL), value); }
            else if (property == "TipoWhere") { TipoWhere = (TipoWhere)Enum.Parse(typeof(TipoWhere), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
