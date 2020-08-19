using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Formats.Output.XOML;

namespace Fiive.Owl.Formats.Output
{
    public class SQLOutput : GenericOutput
    {
        protected override string GenerateSection(SectionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder(), sbComplement = new StringBuilder(); ;
            SqlSectionOutput sectionSQL = (SqlSectionOutput)section;
            bool hasElements = false;

            #region Obtener informacion de la seccion

            #region Recorre elementos

            foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
            {
                SqlElementOutput element = (SqlElementOutput)_handler.XOMLValidator.GetXOMLObject(new SqlElementOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);

                if (!element.Hidden)
                {
                    if (sectionSQL.SqlType == SqlType.Delete) { element.SqlElementType = SqlElementType.Where; }

                    if (sectionSQL.SqlType != SqlType.Insert && element.SqlElementType == SqlElementType.Where)
                    {
                        // Where

                        if (element.WhereType == WhereType.Equal)
                        {
                            sbComplement.Append(element.Name);
                            if (string.IsNullOrEmpty(element.Value))
                            {
                                if (element.MandatoryValue) { sbComplement.Append(" = '' AND "); }
                                else { sbComplement.Append(" IS NULL AND "); }
                            }
                            else { sbComplement.Append(string.Concat(" = '", element.Value, "' AND ")); }
                        }
                        else if (element.WhereType == WhereType.Different)
                        {
                            sbComplement.Append(element.Name);
                            if (string.IsNullOrEmpty(element.Value))
                            {
                                if (element.MandatoryValue) { sbComplement.Append(" <> '' AND "); }
                                else { sbComplement.Append(" IS NOT NULL AND "); }
                            }
                            else { sbComplement.Append(string.Concat(" <> '", element.Value, "' AND ")); }
                        }
                        else if (element.WhereType == WhereType.Like)
                        {
                            sbComplement.Append(string.Concat(element.Name, " LIKE "));
                            sbComplement.Append(string.Concat("'%", element.Value, "%' AND "));
                        }
                        else if (element.WhereType == WhereType.In)
                        {
                            sbComplement.Append(string.Concat(element.Name, " IN "));
                            sbComplement.Append(string.Concat("(", element.Value, ") AND "));
                        }
                        else if (element.WhereType == WhereType.Between)
                        {
                            sbComplement.Append(string.Concat(element.Name, " BETWEEN "));
                            sbComplement.Append(string.Concat("", element.Value, " AND "));
                        }
                        else if (element.WhereType == WhereType.NotBetween)
                        {
                            sbComplement.Append(string.Concat(element.Name, " NOT BETWEEN "));
                            sbComplement.Append(string.Concat("", element.Value, " AND "));
                        }
                    }
                    else
                    {
                        if (sectionSQL.SqlType == SqlType.Select)
                        {
                            sb.Append(string.Concat(element.Name, ", "));
                        }
                        else if (sectionSQL.SqlType == SqlType.Insert)
                        {
                            sbComplement.Append(string.Concat(element.Name, ", "));

                            if (string.IsNullOrEmpty(element.Value))
                            {
                                if (element.MandatoryValue) { sb.Append("'', "); }
                                else { sb.Append("NULL, "); }
                            }
                            else { sb.Append(string.Concat("'", element.Value, "', ")); }
                        }
                        else if (sectionSQL.SqlType == SqlType.Update)
                        {
                            sb.Append(string.Concat(element.Name, " = "));
                            if (string.IsNullOrEmpty(element.Value))
                            {
                                if (element.MandatoryValue) { sb.Append("'', "); }
                                else { sb.Append("NULL, "); }
                            }
                            else { sb.Append(string.Concat("'", element.Value, "', ")); }
                        }
                    }

                    hasElements = true;
                }
            }

            #endregion

            #region Finalizar seccion

            if (hasElements)
            {
                if (sectionSQL.SqlType == SqlType.Select)
                {
                    if (sb.Length > 0) { sb.Remove(sb.Length - 2, 2); }

                    sb.Insert(0, "SELECT ");
                    sb.Append(string.Concat(" FROM ", section.Name));

                    if (sbComplement.Length > 0)
                    {
                        sbComplement.Remove(sbComplement.Length - 5, 5);
                        sb.Append(" WHERE ");
                        sb.Append(sbComplement.ToString());
                    }
                }
                else if (sectionSQL.SqlType == SqlType.Insert)
                {
                    if (sbComplement.Length > 0) { sbComplement.Remove(sbComplement.Length - 2, 2); }
                    if (sb.Length > 0) { sb.Remove(sb.Length - 2, 2); }

                    sb.Insert(0, string.Concat("INSERT INTO ", section.Name, " (", sbComplement.ToString(), ") VALUES ("));
                    sb.Append(")");
                }
                else if (sectionSQL.SqlType == SqlType.Update)
                {
                    if (sb.Length > 0) { sb.Remove(sb.Length - 2, 2); }
                    sb.Insert(0, string.Concat("UPDATE ", section.Name, " SET "));

                    if (sbComplement.Length > 0)
                    {
                        sbComplement.Remove(sbComplement.Length - 5, 5);
                        sb.Append(" WHERE ");
                        sb.Append(sbComplement.ToString());
                    }
                }
                else if (sectionSQL.SqlType == SqlType.Delete)
                {
                    if (sbComplement.Length > 0) { sbComplement.Remove(sbComplement.Length - 5, 5); }
                    sbComplement.Insert(0, string.Concat("DELETE FROM ", section.Name, " WHERE "));
                    sb = sbComplement;
                }

                _segmentCount++;
                return sb.ToString();
            }

            #endregion

            #endregion

            return null; // If all elements are (Oculto="Si")
        }

        protected override string ExtraInformation() { return Environment.NewLine; }

        protected override SectionOutput GetSection(XmlNode node) { return (SqlSectionOutput)_handler.XOMLValidator.GetXOMLObject(new SqlSectionOutput(), node, _handler); }
    }
}
