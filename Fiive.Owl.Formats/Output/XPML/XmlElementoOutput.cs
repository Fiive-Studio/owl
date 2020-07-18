using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    public class XmlElementoOutput : ElementoOutput
    {
        #region Properties

        public TipoElementoXml TipoElementoXml { get; set; }

        public bool ValorRequerido { get; set; }

        public bool? EscaparCaracteres { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "TipoElementoXml", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "ValorRequerido", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "EscaparCaracteres", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "TipoElementoXml") { TipoElementoXml = (TipoElementoXml)Enum.Parse(typeof(TipoElementoXml), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
