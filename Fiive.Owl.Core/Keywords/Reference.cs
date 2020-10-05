using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.XOML;
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
    public class Reference : IKeyword
    {
        #region Properties

        /// <summary>
        /// Obtiene / Establece el Nombre de la Tabla
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        /// Obtiene / Establece el Valor por defecto
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// Obtiene / Establece el Formato de la cadena de salida
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Obtiene / Establece los Campos que se van a obtener
        /// </summary>
        public List<string> FieldsGet { get; set; }
        /// <summary>
        /// Obtiene / Establece los Campos donde se va a buscar
        /// </summary>
        public List<string> FieldsSeek { get; set; }
        /// <summary>
        /// Obtiene / Establece los Valores que se van a buscar
        /// </summary>
        public List<string> ValuesSeek { get; set; }
        /// <summary>
        /// Obtiene si el valor de la referencia fue encontrado. true si fue encontrado, false si devolvio valor por defecto
        /// </summary>
        public bool ValueFound { get; private set; }

        #endregion

        #region IXOMLObject

        /// <summary>
        /// Obtiene la firma XOML del objeto
        /// </summary>
        /// <returns>Firma XOML</returns>
        public XOMLSigning GetSigning()
        {
            return new XOMLSigning
            {
                Restrictions = new List<XOMLSigning.XOMLRestriction>()
                {
                    new XOMLSigning.XOMLRestriction { TagName = "table", PropertyName = "Table", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "default-value", PropertyName = "DefaultValue", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName= "format", PropertyName = "Format", Attribute = true, Tag = true, Mandatory = false, PropertyType = XOMLPropertyType.String },
                    new XOMLSigning.XOMLRestriction { TagName = "fields-get", PropertyName = "FieldsGet", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.List },
                    new XOMLSigning.XOMLRestriction { TagName = "fields-seek", PropertyName = "FieldsSeek", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.List },
                    new XOMLSigning.XOMLRestriction { TagName = "values-seek", PropertyName = "ValuesSeek", Attribute = true, Tag = true, Mandatory = true, PropertyType = XOMLPropertyType.List }
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

            if ((FieldsGet == null || FieldsSeek == null || ValuesSeek == null) || (FieldsGet.Count == 0 || FieldsSeek.Count == 0 || ValuesSeek.Count == 0))
            {
                throw new OwlKeywordException(KeywordsType.Reference, string.Format(ETexts.GT(ErrorType.KeywordPropertyUndefined), "FieldsGet, FieldsSeek and ValuesSeek"));
            }

            #endregion

            #region Valida que los valores y columnas a buscar sean igual en cantidad

            if (FieldsSeek.Count != ValuesSeek.Count) { throw new OwlKeywordException(KeywordsType.Reference, ETexts.GT(ErrorType.ReferenceValuesAndFieldsNotEquals)); }

            #endregion

            #region Valida que existan los valores configurados

            OwlHandler config = (OwlHandler)handler;

            if (config.Settings.References == null) { throw new OwlKeywordException(KeywordsType.Reference, ETexts.GT(ErrorType.ReferenceDataSetNull)); }

            // Valida existencia tabla y columna
            if (!config.Settings.References.Tables.Contains(Table)) { throw new OwlKeywordException(KeywordsType.Reference, string.Format(ETexts.GT(ErrorType.ReferenceTableDontExist), Table)); }
            else
            {
                // Query for validate if exists all columns
                var columns = config.Settings.References.Tables[Table].Columns.Cast<DataColumn>();
                var result = (from co in FieldsGet
                              join col in columns on co equals col.ColumnName into gr
                              from subgr in gr.DefaultIfEmpty()
                              where subgr == null
                              select co).ToArray<string>();

                if (result.Length > 0)
                {
                    string fields = string.Join(", ", result);
                    throw new OwlKeywordException(KeywordsType.Reference, string.Format(ETexts.GT(ErrorType.ReferenceColumnDontExist), fields));
                }
            }

            #endregion

            #region Consulta

            StringBuilder sb = new StringBuilder();

            #region Create Query

            // Ciclo para generar el where de la consulta
            for (int i = 0; i < FieldsSeek.Count; i++)
            {
                if (!config.Settings.References.Tables[Table].Columns.Contains(FieldsSeek[i]))
                {
                    throw new OwlKeywordException(KeywordsType.Reference, string.Format(ETexts.GT(ErrorType.ReferenceColumnDontExist), FieldsSeek[i]));
                }

                sb.Append(string.Format("{0} = '{1}'", FieldsSeek[i], ValuesSeek[i].Replace("'", "''")));
                sb.Append(" AND ");
            }

            string select = sb.ToString(0, sb.Length - 5); // Elimina el ultimo " AND "

            #endregion

            #region Execute Query

            DataRow[] drs = config.Settings.References.Tables[Table].Select(select);

            if (drs.Length == 0)
            {
                ValueFound = false;
                if (DefaultValue != null) { return DefaultValue; }
                return string.Empty;
            }
            else
            {
                ValueFound = true;
                if (FieldsGet.Count == 1)
                {
                    string value = drs[0][FieldsGet[0]].ToString();
                    if (Format.IsNullOrWhiteSpace()) { return value; }
                    else { return string.Format(Format, value); }
                }
                else
                {
                    string[] values = new string[FieldsGet.Count];
                    for (int i = 0; i < FieldsGet.Count; i++) { values[i] = drs[0][FieldsGet[i]].ToString(); }
                    if (Format.IsNullOrWhiteSpace()) { return string.Concat(values); }
                    else { return string.Format(Format, values); }
                }
            }

            #endregion

            #endregion
        }

        #endregion
    }
}
