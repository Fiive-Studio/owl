using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
	/// Define el tipo de dato del elemento
	/// </summary>
	public enum ElementDataType
    {
        /// <summary>
        /// Indica Alfanumerico
        /// </summary>
        Alphanumeric = 1,
        /// <summary>
        /// Indica Numerico
        /// </summary>
        Numeric = 2
    }

    /// <summary>
	/// Define el tipo de etiqueta XML
	/// </summary>
	public enum XmlTagType
    {
        /// <summary>
        /// No Aplica
        /// </summary>
        NotApply = 0,
        /// <summary>
        /// Indica Simple
        /// </summary>
        Simple = 1,
        /// <summary>
        /// Indica Compuesta
        /// </summary>
        Complex = 2,
        /// <summary>
        /// Indica Comentario
        /// </summary>
        Comment = 3,
        /// <summary>
        /// Indica CData
        /// </summary>
        CData = 4
    }

    /// <summary>
	/// Define el tipo de elemento XML
	/// </summary>
	public enum XmlElementType
    {
        /// <summary>
        /// No Aplica
        /// </summary>
        NotApply = 0,
        /// <summary>
        /// Indica Comentario
        /// </summary>
        Comment = 1,
        /// <summary>
        /// Indica CData
        /// </summary>
        CData = 2
    }

    /// <summary>
	/// Define el tipo de SQL que se va a generar
	/// </summary>
    public enum SqlType
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
	public enum SqlElementType
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
	public enum WhereType
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
