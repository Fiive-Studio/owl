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
                    new XPMLSigning.XPMLRestriction { Name = "Itera", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Linea", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "NumeroLinea", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "SeccionEvento", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "SeccionEventoPrevio", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "SeccionEventoGrupo", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "ElementoEvento", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "ElementoEventoSeccion", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean },
                    new XPMLSigning.XPMLRestriction { Name = "SeparadorDecimalesEntrada", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { Name = "SeparadorDecimalesSalida", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Char },
                    new XPMLSigning.XPMLRestriction { Name = "Id", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Base", Attribute = true, Tag = false, Mandatory = false, PropertyType = XPMLPropertyType.String }
                }
            };
        }

        public void SetPropertyValue(string property, string value) { }

        #endregion
    }
}
