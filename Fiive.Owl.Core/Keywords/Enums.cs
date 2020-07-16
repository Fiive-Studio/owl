using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Define las palabras claves aceptadas
    /// </summary>
    [Flags]
    public enum KeywordsType
    {
        /// <summary>
        /// Indica PalabraClave No Existente
        /// </summary>
        NoEncontrada = 0,
        /// <summary>
        /// Indica Predeterminado
        /// </summary>
        Predeterminado = 1,
        /// <summary>
        /// Indica Variable
        /// </summary>
        Variable = 2,
        /// <summary>
        /// Indica Reservada
        /// </summary>
        Reservada = 4,
        /// <summary>
        /// Indica Buscar
        /// </summary>
        Buscar = 8,
        /// <summary>
        /// Indica Referencia
        /// </summary>
        Referencia = 16,
        /// <summary>
        /// Indica Concatenar
        /// </summary>
        Concatenar = 32,
        /// <summary>
        /// Indica SubCadena
        /// </summary>
        SubCadena = 64,
        /// <summary>
        /// Indica Longitud
        /// </summary>
        Longitud = 128,
        /// <summary>
        /// Indica si el valor representa un numero
        /// </summary>
        EsNumero = 256,
        /// <summary>
        /// Indica la posicion donde se encuentra una subcadena
        /// </summary>
        IndiceDe = 512,
        /// <summary>
        /// Indica si la cadena esta vacia
        /// </summary>
        EsVacio = 1024,
        /// <summary>
        /// Indica Limpiar Espacios
        /// </summary>
        LimpiarEspacios = 2048,
        /// <summary>
        /// Indica validador Si
        /// </summary>
        Si = 4096,
        /// <summary>
        /// Indica Expansion
        /// </summary>
        Expansion = 8192
    }
}
