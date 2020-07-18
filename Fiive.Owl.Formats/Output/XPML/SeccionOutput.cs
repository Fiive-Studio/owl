using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Exceptions;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Seccion de Salida
    /// </summary>
    public class SeccionOutput : IXPMLObject
    {
        #region Constructor

        public SeccionOutput() { Repeticiones = 1; }

        #endregion

        #region Properties

        public string Nombre { get; set; }
        public string Nodo { get; set; }
        public string Itera { get; set; }
        public bool? Evento { get; set; }
        public bool? EventoPrevio { get; set; }
        public bool? EventoGrupo { get; set; }
        public string Descripcion { get; set; }
        public int Repeticiones { get; set; }
        public string Id { get; set; }
        public bool MostrarContenido { get; set; }

        /// <summary>
        /// Indica si se cancela la escritura de la seccion
        /// </summary>
        public bool CancelWriteSection { get; set; }

        #endregion

        #region Properties Read Only

        /// <summary>
        /// Obtiene el consecutivo de la iteracion
        /// </summary>
        public int Consecutive { get; internal set; }

        /// <summary>
        /// Obtiene la linea de donde se obtiene la seccion
        /// </summary>
        public string Line { get; internal set; }

        /// <summary>
        /// Obtiene el numero de la linea de donde se obtiene la seccion
        /// </summary>
        public string NumberLine { get; internal set; }

        /// <summary>
        /// Xpath para obtener la linea
        /// </summary>
        public string XpahtLine { get; internal set; }

        /// <summary>
        /// Obtiene para obtener el numero de la linea
        /// </summary>
        public string XpathNumberLine { get; internal set; }

        /// <summary>
        /// Lista de elementos de la seccion
        /// </summary>
        public List<ElementoOutput> Elements { get; internal set; }

        /// <summary>
        /// Obtiene el contenido de la seccion
        /// </summary>
        public string Content { get; internal set; }

        #endregion

        #region IXPMLObject

        public virtual XPMLSigning GetSigning()
        {
            return new XPMLSigning
            {
                Restrictions = new List<XPMLSigning.XPMLRestriction>()
                {
                    new XPMLSigning.XPMLRestriction { PropertyName = "Nombre", Attribute = true, Tag = false, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Nodo", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Itera", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Evento", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "EventoPrevio", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "EventoGrupo", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Descripcion", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Repeticiones", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Int },
                    new XPMLSigning.XPMLRestriction { PropertyName = "MostrarContenido", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Id", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String }
                }
            };
        }

        public virtual void SetPropertyValue(string property, string value)
        {
            throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLEnumInvalid), property));
        }

        #endregion
    }
}
