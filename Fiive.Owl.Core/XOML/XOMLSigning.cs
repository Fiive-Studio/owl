using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.XOML
{
    /// <summary>
    /// Firma de una definicion XOML
    /// </summary>
    public class XOMLSigning
    {
        /// <summary>
        /// Obtiene / Establece las restricciones del XOML
        /// </summary>
        public List<XOMLRestriction> Restrictions { get; set; }

        /// <summary>
        /// Restriccion de una definicion XOML
        /// </summary>
        public class XOMLRestriction
        {
            public string TagName { get; set; }
            public string PropertyName { get; set; }
            public bool Attribute { get; set; }
            public bool Tag { get; set; }
            public bool Mandatory { get; set; }
            public XOMLPropertyType PropertyType { get; set; }
        }
    }
}
