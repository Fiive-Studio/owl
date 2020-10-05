using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.XOML
{
    /// <summary>
    /// Interfaz para los objetos que se definan por XOML
    /// </summary>
    public interface IXOMLObject
    {
        /// <summary>
        /// Obtiene la firma XOML del objeto
        /// </summary>
        /// <returns>Firma XOML</returns>
        XOMLSigning GetSigning();

        /// <summary>
        /// Set the enums properties
        /// </summary>
        /// <param name="property">Property Name</param>
        /// <param name="value">Value</param>
        void SetPropertyValue(string property, string value);
    }
}
