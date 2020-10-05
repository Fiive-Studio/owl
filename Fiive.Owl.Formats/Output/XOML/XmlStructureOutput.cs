using Fiive.Owl.Core.XOML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XOML
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

        #region IXOMLObject

        /// <summary>
        /// Obtiene la firma XOML del objeto
        /// </summary>
        /// <returns>Firma XOML</returns>
        public override XOMLSigning GetSigning()
        {
            XOMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "xml-release-chars", PropertyName = "XmlReleaseChars", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean });

            return signing;
        }

        #endregion
    }
}
