using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Represent a Xml Structure configuration
    /// </summary>
    public class XmlStructureOutput : StructureOutput
    {
        #region Constructor

        public XmlStructureOutput() { XmlReleaseChars = true; }

        #endregion

        #region Properties

        public bool XmlReleaseChars { get; set; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "xml-release-chars", PropertyName = "XmlReleaseChars", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        #endregion
    }
}
