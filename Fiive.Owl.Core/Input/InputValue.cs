using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Input
{
    /// <summary>
    /// Define un tipo de valor generico para las entradas
    /// </summary>
    public interface InputValue
    {
        #region Publics

		/// <summary>
		/// Cantidad de resultados que retorna la expresion
		/// </summary>
		/// <param name="eval">Expresion a evaluar</param>
		/// <returns>Cantidad de resultados</returns>
		int Count( string eval );

		/// <summary>
		/// Devuelve los valores
		/// </summary>
		/// <param name="eval">Expresion a evaluar</param>
		/// <returns>IEnumerable con los resultados</returns>
		IEnumerable<InputValue> GetValues( string eval );

        /// <summary>
        /// Otiene un valor
        /// </summary>
        /// <param name="eval">Expresion a evaluar</param>
        /// <returns>Valor</returns>
        string GetValue(string eval);

		#endregion
    }
}
