using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XPML;
using Fiive.Owl.Core.Keywords;
using Fiive.Owl.Core.Exceptions;
using System.Xml;
using System.Data;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Core.Keywords
{
    /// <summary>
    /// Valor de una referencia cruzada
    /// </summary>
    public class Referencia : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el Nombre de la Tabla
        /// </summary>
        public string Tabla { get; set; }
        /// <summary>
        /// Obtiene / Establece el Valor por defecto
        /// </summary>
        public string ValorDefecto { get; set; }
        /// <summary>
        /// Obtiene / Establece el Formato de la cadena de salida
        /// </summary>
        public string Formato { get; set; }
        /// <summary>
        /// Obtiene / Establece los Campos que se van a obtener
        /// </summary>
        public List<string> CamposObtener { get; set; }
        /// <summary>
        /// Obtiene / Establece los Campos donde se va a buscar
        /// </summary>
        public List<string> CamposBuscar { get; set; }
        /// <summary>
        /// Obtiene / Establece los Valores que se van a buscar
        /// </summary>
        public List<string> ValoresBuscar { get; set; }
        /// <summary>
        /// Obtiene si el valor de la referencia fue encontrado. true si fue encontrado, false si devolvio valor por defecto
        /// </summary>
        public bool ValorEncontrado { get; private set; }

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
                    new XPMLSigning.XPMLRestriction { Name = "Tabla", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "ValorDefecto", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "Formato", Attribute = true, Tag = true, Mandatory = false, PropertyType = XPMLPropertyType.String },
                    new XPMLSigning.XPMLRestriction { Name = "CamposObtener", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.List },
                    new XPMLSigning.XPMLRestriction { Name = "CamposBuscar", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.List },
                    new XPMLSigning.XPMLRestriction { Name = "ValoresBuscar", Attribute = true, Tag = true, Mandatory = true, PropertyType = XPMLPropertyType.List }
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
            #region Validate that the configuration have at least one item

            if ((CamposObtener == null || CamposBuscar == null || ValoresBuscar == null) || (CamposObtener.Count == 0 || CamposBuscar.Count == 0 || ValoresBuscar.Count == 0))
            {
                throw new OwlKeywordException(KeywordsType.Referencia, string.Format(ETexts.GT(ErrorType.KeywordPropertyUndefined), "CamposObtener, CamposBuscar y ValoresBuscar"));
            }

            #endregion

            #region Valida que los valores y columnas a buscar sean igual en cantidad

            if (CamposBuscar.Count != ValoresBuscar.Count) { throw new OwlKeywordException(KeywordsType.Referencia, ETexts.GT(ErrorType.ReferenceValuesAndFieldsNotEquals)); }

            #endregion

            #region Valida que existan los valores configurados

            OwlHandler config = (OwlHandler)handler;

            if (config.Settings.References == null) { throw new OwlKeywordException(KeywordsType.Referencia, ETexts.GT(ErrorType.ReferenceDataSetNull)); }

            // Valida existencia tabla y columna
            if (!config.Settings.References.Tables.Contains(Tabla)) { throw new OwlKeywordException(KeywordsType.Referencia, string.Format(ETexts.GT(ErrorType.ReferenceTableDontExist), Tabla)); }
            else
            {
                // Query for validate if exists all columns
                var columns = config.Settings.References.Tables[Tabla].Columns.Cast<DataColumn>();
                var result = (from co in CamposObtener
                              join col in columns on co equals col.ColumnName into gr
                              from subgr in gr.DefaultIfEmpty()
                              where subgr == null
                              select co).ToArray<string>();

                if (result.Length > 0)
                {
                    string fields = string.Join(", ", result);
                    throw new OwlKeywordException(KeywordsType.Referencia, string.Format(ETexts.GT(ErrorType.ReferenceColumnDontExist), fields));
                }
            }

            #endregion

            #region Consulta

            StringBuilder sb = new StringBuilder();
            
            #region Create Query

            // Ciclo para generar el where de la consulta
            for (int i = 0; i < CamposBuscar.Count; i++)
            {
                if (!config.Settings.References.Tables[Tabla].Columns.Contains(CamposBuscar[i]))
                {
                    throw new OwlKeywordException(KeywordsType.Referencia, string.Format(ETexts.GT(ErrorType.ReferenceColumnDontExist), CamposBuscar[i]));
                }

                sb.Append(string.Format("{0} = '{1}'", CamposBuscar[i], ValoresBuscar[i].Replace("'", "''")));
                sb.Append(" AND ");
            }

            string select = sb.ToString(0, sb.Length - 5); // Elimina el ultimo " AND "

            #endregion

            #region Execute Query

            DataRow[] drs = config.Settings.References.Tables[Tabla].Select(select);

            if (drs.Length == 0)
            {
                ValorEncontrado = false;
                if (ValorDefecto != null) { return ValorDefecto; }
                return string.Empty;
            }
            else
            {
                ValorEncontrado = true;
                if (CamposObtener.Count == 1)
                {
                    string value = drs[0][CamposObtener[0]].ToString();
                    if (Formato.IsNullOrWhiteSpace()) { return value; }
                    else { return string.Format(Formato, value); }
                }
                else
                {
                    string[] values = new string[CamposObtener.Count];
                    for (int i = 0; i < CamposObtener.Count; i++) { values[i] = drs[0][CamposObtener[i]].ToString(); }
                    if (Formato.IsNullOrWhiteSpace()) { return string.Concat(values); }
                    else{ return string.Format(Formato, values); }
                }
            }

            #endregion

            #endregion
        }

        #endregion
    }
}
