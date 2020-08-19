using Fiive.Owl.Core.XOML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XOML
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

        #region IXOMLObject

        /// <summary>
        /// Obtiene la firma XOML del objeto
        /// </summary>
        /// <returns>Firma XOML</returns>
        public override XOMLSigning GetSigning()
        {
            XOMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "separator", PropertyName = "Separator", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.String });
            signing.Restrictions.Add(new XOMLSigning.XOMLRestriction { TagName = "remove-final-separators", PropertyName = "RemoveFinalSeparators", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.Boolean });

            return signing;
        }

        #endregion
    }
}
