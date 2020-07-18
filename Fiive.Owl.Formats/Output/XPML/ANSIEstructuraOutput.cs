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
    public class ANSIEstructuraOutput : EstructuraOutput
    {
        #region Properties

        public char SeparadorElementos { get; set; }
        public char TerminadorSegmento { get; set; }
        public char CaracterEscape { get; set; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "SeparadorElementos", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "TerminadorSegmento", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "CaracterEscape", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char });

            return signing;
        }

        #endregion
    }
}
