using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Formats.Output.Auxiliar;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Seccion de Salida
    /// </summary>
    public class ElementoOutput : IXPMLObject
    {
        #region Constructor

        public ElementoOutput() { TipoDato = ElementoTipoDato.Alfanumerico; }

        #endregion

        #region Properties

        public string Nombre { get; set; }
        public FieldLength Longitud { get; set; }
        public ElementoTipoDato TipoDato { get; set; }
        public bool Requerido { get; set; }
        public string Formato { get; set; }
        public string VariableGlobal { get; set; }
        public string Contador { get; set; }
        public bool? Evento { get; set; }
        public bool? EventoSeccion { get; set; }
        public string Descripcion { get; set; }
        public bool Oculto { get; set; }
        public char SeparadorDecimalesEntrada { get; set; }
        public char SeparadorDecimalesSalida { get; set; }
        public bool Sobreescribir { get; set; }
        public string Id { get; set; }
        public string AntesDe { get; set; }
        public string DespuesDe { get; set; }
        public string Nodo { get; set; }

        /// <summary>
        /// Obtiene / Establece el valor del Elemento
        /// </summary>
        public string Valor { get; set; }

        public IKeyword Keyword { get; set; }

        /// <summary>
        /// Obtiene / Establece un valor que indica si el elemento tiene un error
        /// </summary>
        public bool ElementWithError { get; set; }

        #endregion

        #region Properties Read Only

        /// <summary>
        /// Obtiene la linea de donde se obtiene el elemento
        /// </summary>
        public string Line { get; internal set; }

        /// <summary>
        /// Obtiene el numero de la linea de donde se obtiene el elemento
        /// </summary>
        public string NumberLine { get; internal set; }

        #endregion

        #region IXPMLObject

        public virtual XPMLSigning GetSigning()
        {
            return new XPMLSigning
            {
                Restrictions = new List<XPMLSigning.XPMLRestriction>() 
                { 
                    new XPMLSigning.XPMLRestriction { Name = "Nombre", Attribute = true, Tag = false, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "VariableGlobal", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Evento", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "EventoSeccion", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "Descripcion", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Oculto", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "SeparadorDecimalesEntrada", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { Name = "SeparadorDecimalesSalida", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { Name = "Sobreescribir", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "Id", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "AntesDe", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "DespuesDe", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Nodo", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "TipoDato", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Enum },
                    new XPMLSigning.XPMLRestriction { Name = "Requerido", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "Longitud", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Object },
                    new XPMLSigning.XPMLRestriction { Name = "Formato", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Contador", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String }
                }
            };
        }

        public virtual void SetPropertyValue(string property, string value)
        {
            if (property == "TipoDato") { TipoDato = (ElementoTipoDato)Enum.Parse(typeof(ElementoTipoDato), value); }
            else if (property == "Longitud") { Longitud = new FieldLength(value); }
            else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLEnumInvalid), property)); }
        }

        #endregion
    }
}
