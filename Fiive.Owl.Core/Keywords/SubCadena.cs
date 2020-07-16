using Fiive.Owl.Core.Extensions;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.XPML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Substring Value
    /// </summary>
    public class SubCadena : IKeyword
    {
        #region Constructor

        public SubCadena() { Largo = -1; }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene / Establece el valor
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
		/// Obtiene / Establece el inicio
		/// </summary>
        public int Inicio { get; set; }
        /// <summary>
		/// Obtiene / Establece el largo
		/// </summary>
        public int Largo { get; set; }
        /// <summary>
		/// Obtiene / Establece si se quitan los espacios en blanco despues de obtener la subcadena
		/// </summary>
        public bool Limpiar { get; set; }

        #endregion

        #region IXPMLObject

        /// <summary>
        /// Obtiene la firma XPML del objeto
        /// </summary>
        /// <returns>Firma XPML</returns>
        public XPMLSigning GetSigning()
        {
            return new XPMLSigning
            {
                Restrictions = new List<XPMLSigning.XPMLRestriction>()
                {
                    new XPMLSigning.XPMLRestriction { Name = "Valor", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Inicio", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.Int },
                    new XPMLSigning.XPMLRestriction { Name = "Largo", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Int },
                    new XPMLSigning.XPMLRestriction { Name = "Limpiar", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.Boolean }
                }
            };
        }

        public void SetPropertyValue(string property, string value) { }

        #endregion

        #region IKeyword

        /// <summary>
        /// Obtiene / Establece el tipo de palabra clave
        /// </summary>
        public KeywordsType KeywordType { get; set; }

        /// <summary>
        /// Obtiene el valor de la palabra clave
        /// </summary>
        /// <param name="handler">Orquestador</param>
        /// <returns>Valor</returns>
        public string GetValue(object handler)
        {
            if (Largo == -1) { return Valor.GetSafeSubstring(Inicio, Limpiar); }
            else { return Valor.GetSafeSubstring(Inicio, Largo, Limpiar); }
        }

        #endregion
    }
}
