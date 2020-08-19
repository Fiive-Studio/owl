using Fiive.Owl.Core.XOML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XOML
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

        #region IXOMLObject

        /// <summary>
        /// Obtiene la firma XOML del objeto
        /// </summary>
        /// <returns>Firma XOML</returns>
        public override XOMLSigning GetSigning()
        {
            XOMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "element-separator", PropertyName = "ElementSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Char });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "segment-separator", PropertyName = "SegmentSeparator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Char });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "release-char", PropertyName = "ReleaseChar", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Char });

            return signing;
        }

        #endregion
    }
}
