using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
	/// Define el tipo de dato del elemento
	/// </summary>
	public enum ElementoTipoDato
    {
        /// <summary>
        /// Indica Alfanumerico
        /// </summary>
        Alfanumerico = 1,
        /// <summary>
        /// Indica Numerico
        /// </summary>
        Numerico = 2
    }

    /// <summary>
	/// Define el tipo de etiqueta XML
	/// </summary>
	public enum TipoEtiquetaXml
    {
        /// <summary>
        /// No Aplica
        /// </summary>
        NoAplica = 0,
        /// <summary>
        /// Indica Apertura
        /// </summary>
        Apertura = 1,
        /// <summary>
        /// Indica Simple
        /// </summary>
        Simple = 2,
        /// <summary>
        /// Indica Compuesta
        /// </summary>
        Compuesta = 3,
        /// <summary>
        /// Indica Cierre
        /// </summary>
        Cierre = 4,
        /// <summary>
        /// Indica Comentario
        /// </summary>
        Comentario = 5,
        /// <summary>
        /// Indica CData
        /// </summary>
        CData = 6
    }

    /// <summary>
	/// Define el tipo de elemento XML
	/// </summary>
	public enum TipoElementoXml
    {
        /// <summary>
        /// No Aplica
        /// </summary>
        NoAplica = 0,
        /// <summary>
        /// Indica Comentario
        /// </summary>
        Comentario = 1,
        /// <summary>
        /// Indica CData
        /// </summary>
        CData = 2
    }

    /// <summary>
	/// Define el tipo de SQL que se va a generar
	/// </summary>
    public enum TipoSQL
    {
        /// <summary>
        /// Indica que la sentencia es de consulta
        /// </summary>
        Select,
        /// <summary>
        /// Indica que la sentencia es de insercion
        /// </summary>
        Insert,
        /// <summary>
        /// Indica que la sentencia es de actualizacion
        /// </summary>
        Update,
        /// <summary>
        /// Indica que la sentecia es de eliminacion
        /// </summary>
        Delete
    }

    /// <summary>
	/// Define el tipo de elemento SQL
	/// </summary>
	public enum TipoElementoSQL
    {
        /// <summary>
        /// Indica Select
        /// </summary>
        Select = 1,
        /// <summary>
        /// Indica Where
        /// </summary>
        Where = 2
    }

    /// <summary>
	/// Define el tipo de elemento SQL
	/// </summary>
	public enum TipoWhere
    {
        /// <summary>
        /// Indica Igual
        /// </summary>
        Equal = 1,
        /// <summary>
        /// Indica Diferente
        /// </summary>
        Different = 2,
        /// <summary>
        /// Indica Like
        /// </summary>
        Like = 3,
        /// <summary>
        /// Indica In
        /// </summary>
        In = 4,
        /// <summary>
        /// Indica Between
        /// </summary>
        Between = 5,
        /// <summary>
        /// Indica Not Between
        /// </summary>
        NotBetween = 6
    }
}
