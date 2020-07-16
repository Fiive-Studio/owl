using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Represent a Xml Section configuration
    /// </summary>
    public class XmlSeccionOutput : SeccionOutput
    {
        #region Constructor

        public XmlSeccionOutput() { TipoEtiqueta = TipoEtiquetaXml.Compuesta; }

        #endregion

        #region Properties

        public TipoEtiquetaXml TipoEtiqueta { get; set; }

        #endregion

        #region IXPMLObject

        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { Name = "TipoEtiqueta", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum });

            return signing;
        }

        public override void SetPropertyValue(string property, string value)
        {
            if (property == "TipoEtiqueta") { TipoEtiqueta = (TipoEtiquetaXml)Enum.Parse(typeof(TipoEtiquetaXml), value); }
            else { base.SetPropertyValue(property, value); }
        }

        #endregion
    }
}
