using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.XPML
{
    /// <summary>
    /// Interfaz para los objetos que se definan por XPML
    /// </summary>
    public interface IXPMLObject
    {
        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        XPMLSigning GetSigning();

        /// <summary>
        /// Set the enums properties
        /// </summary>
        /// <param name="property">Property Name</param>
        /// <param name="value">Value</param>
        void SetPropertyValue(string property, string value);
    }
}
