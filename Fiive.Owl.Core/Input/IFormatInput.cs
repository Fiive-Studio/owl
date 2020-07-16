using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Core.Input
{
    /// <summary>
    /// Inteface para estructuras de entrada
    /// </summary>
    public interface IFormatInput : InputValue
    {
        /// <summary>
        /// Carga los datos de la entrada
        /// </summary>
        /// <param name="configMap">Objeto de Configuracion Xml</param>
        /// <param name="configSettings">Objeto de Configuracion de mapeo</param>
        void LoadData(OwlConfigMap configMap, OwlSettings configSettings);
    }
}
