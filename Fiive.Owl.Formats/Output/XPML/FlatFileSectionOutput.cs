using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Represent a Flat File Section configuration
    /// </summary>
    public class FlatFileSectionOutput : SectionOutput
    {
        #region Properties

        public string Separator { get; set; }
        public bool RemoveFinalSeparators { get; set; }

        #endregion

        #region Constructor

        public FlatFileSectionOutput() { this.Separator = string.Empty; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "separator", PropertyName = "Separator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { TagName = "remove-final-separators", PropertyName = "RemoveFinalSeparators", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        #endregion
    }
}
