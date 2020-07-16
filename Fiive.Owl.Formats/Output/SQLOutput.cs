using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Fiive.Owl.Formats.Output.XPML;

namespace Fiive.Owl.Formats.Output
{
    public class SQLOutput : GenericOutput
    {
        protected override string GenerateSection(SeccionOutput section, XmlNode node)
        {
            StringBuilder sb = new StringBuilder(), sbComplement = new StringBuilder(); ;
            SQLSeccionOutput sectionSQL = (SQLSeccionOutput)section;
            bool hasElements = false;

            #region Obtener informacion de la seccion

            #region Recorre elementos

            foreach (XmlNode nElement in _handler.ConfigMap.GetOutputElements(node))
            {
                SQLElementoOutput element = (SQLElementoOutput)_handler.XPMLValidator.GetXPMLObject(new SQLElementoOutput(), nElement, _handler);
                GetElementValue(element, nElement, section);

                if (!element.Oculto)
                {
                    if (sectionSQL.TipoSQL == TipoSQL.Delete) { element.TipoElementoSQL = TipoElementoSQL.Where; }

                    if (sectionSQL.TipoSQL != TipoSQL.Insert && element.TipoElementoSQL == TipoElementoSQL.Where)
                    {
                        // Where

                        if (element.TipoWhere == TipoWhere.Equal)
                        {
                            sbComplement.Append(element.Nombre);
                            if (string.IsNullOrEmpty(element.Valor))
                            {
                                if (element.ValorRequerido) { sbComplement.Append(" = '' AND "); }
                                else { sbComplement.Append(" IS NULL AND "); }
                            }
                            else { sbComplement.Append(string.Concat(" = '", element.Valor, "' AND ")); }
                        }
                        else if (element.TipoWhere == TipoWhere.Different)
                        {
                            sbComplement.Append(element.Nombre);
                            if (string.IsNullOrEmpty(element.Valor))
                            {
                                if (element.ValorRequerido) { sbComplement.Append(" <> '' AND "); }
                                else { sbComplement.Append(" IS NOT NULL AND "); }
                            }
                            else { sbComplement.Append(string.Concat(" <> '", element.Valor, "' AND ")); }
                        }
                        else if (element.TipoWhere == TipoWhere.Like)
                        {
                            sbComplement.Append(string.Concat(element.Nombre, " LIKE "));
                            sbComplement.Append(string.Concat("'%", element.Valor, "%' AND "));
                        }
                        else if (element.TipoWhere == TipoWhere.In)
                        {
                            sbComplement.Append(string.Concat(element.Nombre, " IN "));
                            sbComplement.Append(string.Concat("(", element.Valor, ") AND "));
                        }
                        else if (element.TipoWhere == TipoWhere.Between)
                        {
                            sbComplement.Append(string.Concat(element.Nombre, " BETWEEN "));
                            sbComplement.Append(string.Concat("", element.Valor, " AND "));
                        }
                        else if (element.TipoWhere == TipoWhere.NotBetween)
                        {
                            sbComplement.Append(string.Concat(element.Nombre, " NOT BETWEEN "));
                            sbComplement.Append(string.Concat("", element.Valor, " AND "));
                        }
                    }
                    else
                    {
                        if (sectionSQL.TipoSQL == TipoSQL.Select)
                        {
                            sb.Append(string.Concat(element.Nombre, ", "));
                        }
                        else if (sectionSQL.TipoSQL == TipoSQL.Insert)
                        {
                            sbComplement.Append(string.Concat(element.Nombre, ", "));

                            if (string.IsNullOrEmpty(element.Valor))
                            {
                                if (element.ValorRequerido) { sb.Append("'', "); }
                                else { sb.Append("NULL, "); }
                            }
                            else { sb.Append(string.Concat("'", element.Valor, "', ")); }
                        }
                        else if (sectionSQL.TipoSQL == TipoSQL.Update)
                        {
                            sb.Append(string.Concat(element.Nombre, " = "));
                            if (string.IsNullOrEmpty(element.Valor))
                            {
                                if (element.ValorRequerido) { sb.Append("'', "); }
                                else { sb.Append("NULL, "); }
                            }
                            else { sb.Append(string.Concat("'", element.Valor, "', ")); }
                        }
                    }

                    hasElements = true;
                }
            }

            #endregion

            #region Finalizar seccion

            if (hasElements)
            {
                if (sectionSQL.TipoSQL == TipoSQL.Select)
                {
                    if (sb.Length > 0) { sb.Remove(sb.Length - 2, 2); }

                    sb.Insert(0, "SELECT ");
                    sb.Append(string.Concat(" FROM ", section.Nombre));

                    if (sbComplement.Length > 0)
                    {
                        sbComplement.Remove(sbComplement.Length - 5, 5);
                        sb.Append(" WHERE ");
                        sb.Append(sbComplement.ToString());
                    }
                }
                else if (sectionSQL.TipoSQL == TipoSQL.Insert)
                {
                    if (sbComplement.Length > 0) { sbComplement.Remove(sbComplement.Length - 2, 2); }
                    if (sb.Length > 0) { sb.Remove(sb.Length - 2, 2); }

                    sb.Insert(0, string.Concat("INSERT INTO ", section.Nombre, " (", sbComplement.ToString(), ") VALUES ("));
                    sb.Append(")");
                }
                else if (sectionSQL.TipoSQL == TipoSQL.Update)
                {
                    if (sb.Length > 0) { sb.Remove(sb.Length - 2, 2); }
                    sb.Insert(0, string.Concat("UPDATE ", section.Nombre, " SET "));

                    if (sbComplement.Length > 0)
                    {
                        sbComplement.Remove(sbComplement.Length - 5, 5);
                        sb.Append(" WHERE ");
                        sb.Append(sbComplement.ToString());
                    }
                }
                else if (sectionSQL.TipoSQL == TipoSQL.Delete)
                {
                    if (sbComplement.Length > 0) { sbComplement.Remove(sbComplement.Length - 5, 5); }
                    sbComplement.Insert(0, string.Concat("DELETE FROM ", section.Nombre, " WHERE "));
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

        protected override SeccionOutput GetSection(XmlNode node) { return (SQLSeccionOutput)_handler.XPMLValidator.GetXPMLObject(new SQLSeccionOutput(), node, _handler); }
    }
}
