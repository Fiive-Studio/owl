using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Core.Extensions
{
    public static class StringArrayExtension
    {
        /// <summary>
        /// Método para obtener de forma segura los valores dentro de un array.
        /// </summary>
        /// <param name="array">El array del cual se desea obtener el valor.</param>
        /// <param name="index">La posición dentro del array del valor que se desea obtener. Inicia en 0</param>
        /// <returns>El valor solicitado; en caso de algún error, se retorna un String.Empty</returns>
        public static string GetSafeValue(this string[] array, int index)
        {
            return array.GetSafeValue(index, false);
        }

        /// <summary>
        /// Método para obtener de forma segura los valores dentro de un array.
        /// </summary>
        /// <param name="array">El array del cual se desea obtener el valor.</param>
        /// <param name="index">La posición dentro del array del valor que se desea obtener. Inicia en 0</param>
        /// <param name="trim">Indica si se le quitan los espacios al inicio y al final a la cadena retornada</param>
        /// <returns>El valor solicitado; en caso de algún error, se retorna un String.Empty</returns>
        public static string GetSafeValue(this string[] array, int index, bool trim)
        {
            if (array == null) { throw new ArgumentNullException("array", "Se debe enviar una instancia de un array de System.String"); }

            if (array.Length <= index) { return string.Empty; }

            try
            {
                if (array[index] == null) { return string.Empty; }
                else if (trim) { return array[index].Trim(); }
                else { return array[index]; }
            }
            catch { return string.Empty; }
        }
    }
}
