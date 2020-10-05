using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Formats.Output.XOML;

namespace Fiive.Owl.Formats.Output
{
    /// <summary>
    /// Argumentos del evento StructureInitiated
    /// </summary>
	public class OutputStructureEventArgs : EventArgs
	{
        #region Propiedades

        /// <summary>
        /// Configuracion XOML
        /// </summary>
        public StructureOutput XOMLConfig { get; internal set; }
        
        /// <summary>
        /// Obtiene la cantidad de veces que se repite, si es -1 es porque es una instancia o fallo al obtener el valor
        /// </summary>
        public int Count { get; internal set; }

		#endregion

        #region Constructor

        /// <summary>
        /// Inicia la clase
        /// </summary>
        /// <param name="count">Cantidad de veces que se repite</param>
        public OutputStructureEventArgs(int count) { Count = count; }

        #endregion
	}
}
