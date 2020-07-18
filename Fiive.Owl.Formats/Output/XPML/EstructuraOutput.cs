using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XPML;

namespace Fiive.Owl.Formats.Output.XPML
{
    /// <summary>
    /// Estructura de Salida
    /// </summary>
    public class EstructuraOutput : IXPMLObject
    {
        #region Properties

        public string Itera { get; set; }
        public string Linea { get; set; }
        public string NumeroLinea { get; set; }
        public bool SeccionEvento { get; set; }
        public bool SeccionEventoPrevio { get; set; }
        public bool SeccionEventoGrupo { get; set; }
        public bool ElementoEvento { get; set; }
        public bool ElementoEventoSeccion { get; set; }
        public char SeparadorDecimalesEntrada { get; set; }
        public char SeparadorDecimalesSalida { get; set; }
        public string Id { get; set; }
        public string Base { get; set; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public virtual XPMLSigning GetSigning()
        {
            return new XPMLSigning
            {
                Restrictions = new List<XPMLSigning.XPMLRestriction>() 
                { 
                    new XPMLSigning.XPMLRestriction { PropertyName = "Itera", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Linea", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "NumeroLinea", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "SeccionEvento", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "SeccionEventoPrevio", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "SeccionEventoGrupo", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "ElementoEvento", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "ElementoEventoSeccion", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { PropertyName = "SeparadorDecimalesEntrada", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { PropertyName = "SeparadorDecimalesSalida", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Id", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { PropertyName = "Base", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String }
                }
            };
        }

        public void SetPropertyValue(string property, string value) { }

        #endregion
    }
}
