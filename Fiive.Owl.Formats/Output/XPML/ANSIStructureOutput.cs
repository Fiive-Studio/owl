using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Represent a ANSI Structure configuration
    /// </summary>
    public class ANSIStructureOutput : StructureOutput
    {
        #region Properties

        public char ElementSeparator { get; set; }
        public char SegmentSeparator { get; set; }
        public char ReleaseChar { get; set; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "element-separator", PropertyName = "ElementSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "segment-separator", PropertyName = "SegmentSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "release-char", PropertyName = "ReleaseChar", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char });

            return signing;
        }

        #endregion
    }
}
