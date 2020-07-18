using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.XPML
{
    /// <summary>
    /// Firma de una definicion XPML
    /// </summary>
    public class XPMLSigning
    {
        /// <summary>
        /// Obtiene / Establece las restricciones del XPML
        /// </summary>
        public List<XPMLRestriction> Restrictions { get; set; }

        /// <summary>
        /// Restriccion de una definicion XPML
        /// </summary>
        public class XPMLRestriction
        {
            public string TagName { get; set; }
            public string PropertyName { get; set; }
            public bool Attribute { get; set; }
            public bool Tag { get; set; }
            public bool Mandatory { get; set; }
            public XPMLPropertyType PropertyType { get; set; }
        }
    }
}
