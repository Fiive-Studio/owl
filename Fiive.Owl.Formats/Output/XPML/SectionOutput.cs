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
    public class SectionOutput : IXPMLObject
    {
        #region Constructor

        public SectionOutput() { Repetitions = 1; }

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Node { get; set; }
        public string Itera { get; set; }
        public bool? Event { get; set; }
        public bool? EventPrevious { get; set; }
        public bool? EventGroup { get; set; }
        public string Description { get; set; }
        public int Repetitions { get; set; }
        public string Id { get; set; }
        public bool ShowContent { get; set; }

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
        public List<ElementOutput> Elements { get; internal set; }

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
                    new XPMLSigning.XPMLRestriction { TagName = "name", PropertyName = "Name", Attribute = true, Tag = false, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "node", PropertyName = "Node", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "itera", PropertyName = "Itera", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "event", PropertyName = "Event", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "event-previous", PropertyName = "EventPrevious", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "event-group", PropertyName = "EventGroup", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "description", PropertyName = "Description", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { TagName = "repetitions", PropertyName = "Repetitions", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Int },
                    new XPMLSigning.XPMLRestriction { TagName = "show-content", PropertyName = "ShowContent", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { TagName = "id", PropertyName = "Id", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String }
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
