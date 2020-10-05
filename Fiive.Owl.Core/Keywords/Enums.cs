using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Keywords list
    /// </summary>
    [Flags]
    public enum KeywordsType
    {
        /// <summary>
        /// Indica PalabraClave No Existente
        /// </summary>
        NotFound = 0,
        /// <summary>
        /// Indica Predeterminado - default
        /// </summary>
        Default = 1,
        /// <summary>
        /// Indica Variable - variable
        /// </summary>
        Variable = 2,
        /// <summary>
        /// Indica Reservada - key
        /// </summary>
        Key = 4,
        /// <summary>
        /// Indica Buscar - xpath
        /// </summary>
        Xpath = 8,
        /// <summary>
        /// Indica Referencia - reference
        /// </summary>
        Reference = 16,
        /// <summary>
        /// Indica Concatenar - concatenate
        /// </summary>
        Concatenate = 32,
        /// <summary>
        /// Indica SubCadena - substring
        /// </summary>
        Substring = 64,
        /// <summary>
        /// Indica Longitud - length
        /// </summary>
        Length = 128,
        /// <summary>
        /// Indica si el valor representa un numero - is-number
        /// </summary>
        IsNumber = 256,
        /// <summary>
        /// Indica la posicion donde se encuentra una subcadena - index-of
        /// </summary>
        IndexOf = 512,
        /// <summary>
        /// Indica si la cadena esta vacia - is-empty
        /// </summary>
        IsEmpty = 1024,
        /// <summary>
        /// Indica Limpiar Espacios - trim
        /// </summary>
        Trim = 2048,
        /// <summary>
        /// Indica validador Si - if
        /// </summary>
        If = 4096
    }
}
