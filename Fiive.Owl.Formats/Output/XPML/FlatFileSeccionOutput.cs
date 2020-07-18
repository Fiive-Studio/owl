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
    public class FlatFileSeccionOutput : SeccionOutput
    {
        #region Properties

        public string Separador { get; set; }
        public bool QuitarSeparadoresFinal { get; set; }

        #endregion

        #region Constructor

        public FlatFileSeccionOutput() { this.Separador = string.Empty; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public override XPMLSigning GetSigning()
        {
            XPMLSigning signing = base.GetSigning();

            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "Separador", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String });
            signing.Restrictions.Add(new XPMLSigning.XPMLRestriction { PropertyName = "QuitarSeparadoresFinal", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean });

            return signing;
        }

        #endregion
    }
}
