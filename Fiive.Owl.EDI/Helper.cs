using Fiive.Owl.Core.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Fiive.Owl.EDI
{
    public class Helper
    {
        /// <summary>
        /// Release de field value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="properties"></param>
        /// <returns>New value</returns>
        public static string ReleaseValue(string content, EDISegmentProperties properties)
        {
            if (string.IsNullOrEmpty(content)) { return content; }

            string result = Regex.Replace(content,
                                            string.Format(@"\{0}|\{1}|\{2}|\{3}"
                                                            , properties.ElementGroupSeparator, properties.ReleaseChar, properties.SegmentSeparator, properties.ElementSeparator)
                                            , (match) => { return properties.ReleaseChar + match.Value; });
            return result;
        }

        /// <summary>
        /// Trim the segment
        /// </summary>
        /// <param name="name">Segment Name</param>
        /// <param name="content">Segment Content</param>
        /// <param name="properties">Properties</param>
        /// <returns>New value</returns>
        public static string TrimSegment(string name, string content, EDISegmentProperties properties)
        {
            if (string.IsNullOrEmpty(content)) { return content; }

            #region Previous Validation

            // This validation is for don't remove release values
            content = Regex.Replace(content,
                string.Format(@"\{0}\{0}|\{0}\{1}|\{0}\{2}", properties.ReleaseChar, properties.ElementGroupSeparator, properties.ElementSeparator),
                (match) =>
                {
                    if (match.Value == string.Format("{0}{1}", properties.ReleaseChar, properties.ElementGroupSeparator)) { return "¨¨¨"; }
                    else if (match.Value == string.Format("{0}{1}", properties.ReleaseChar, properties.ElementSeparator)) { return "°°°"; }
                    else if (match.Value == string.Format("{0}{0}", properties.ReleaseChar)) { return "^^^"; }
                    return match.Value;
                });

            #endregion

            // NAD+SU+R0591::+::::+:BONETERA  ORBE S,A ,DE, C,V,::::+:::++++'
            string[] parts = content.TrimEnd(properties.SegmentSeparator).Split(properties.ElementGroupSeparator);
            StringBuilder returnValue = new StringBuilder();

            // Se quita el separador de SubElementos
            foreach (string part in parts) { returnValue.Append(part.TrimEnd(properties.ElementSeparator) + properties.ElementGroupSeparator); }

            // Se quita el separador de Elementos
            content = returnValue.ToString().TrimEnd(properties.ElementGroupSeparator);

            // Si solo esta el nombre se retorna con el terminador
            if (content == name) { return string.Concat(content, properties.SegmentSeparator); }

            #region Final Validation

            // This validation is for put the original release value
            content = Regex.Replace(content, @"°°°|¨¨¨|\^\^\^",
                (match) =>
                {
                    if (match.Value == "¨¨¨") { return string.Format("{0}{1}", properties.ReleaseChar, properties.ElementGroupSeparator); }
                    else if (match.Value == "°°°") { return string.Format("{0}{1}", properties.ReleaseChar, properties.ElementSeparator); }
                    else if (match.Value == "^^^") { return string.Format("{0}{0}", properties.ReleaseChar); }
                    return match.Value;
                });

            #endregion

            return string.Concat(content, properties.SegmentSeparator);
        }

        /// <summary>
        /// Método encargado de realizar el parseo de una cadena correspondiente a un segmento EDI.
        /// El parseo se realiza de la siguiente manera:
        /// Se realiza un split de la cadena sobre el caracter '+', de modo que se obtiene un array de los elementos 
        /// que componen el segmento, en donde el primer elemento [indice 0] es el nombre del segmento, por lo que los 
        /// datos usables del segmento se encuentran a partir del segundo elemento [índice 1].
        /// Luego, se recorre cada uno de los elementos, haciendo un split en cada indice por el caracter ':' para obtener 
        /// los subelementos, de tal manera que finalmente se obtiene un array de 2 dimensiones de la siguiente manera:
        /// array[posicion1] = elemento 1 del segmento
        /// array[posicion1][posicion2] = subelemento 1 del elemento 1 del segmento
        /// </summary>
        /// <param name="content">La cadena que se debe parsear.</param>
        /// <returns>El array bidimensional con la información</returns>
        public static List<List<string>> ProcessSegment(string content, EDISegmentProperties properties)
        {
            // Array bidimensional
            List<List<string>> strElementos = new List<List<string>>();

            #region Previous Validation

            // This validation is for don't remove release values
            content = Regex.Replace(content,
                string.Format(@"\{0}\{1}|\{0}\{2}", properties.ReleaseChar, properties.ElementGroupSeparator, properties.ElementSeparator),
                (match) =>
                {
                    if (match.Value == string.Format("{0}{1}", properties.ReleaseChar, properties.ElementGroupSeparator)) { return "¨¨¨"; }
                    else if (match.Value == string.Format("{0}{1}", properties.ReleaseChar, properties.ElementSeparator)) { return "°°°"; }
                    return match.Value;
                });

            #endregion

            // Dividir la cadena por el caracter 'ElementSeparator' para sacar los elementos que componen el segmento.
            string[] strLineas = content.TrimEnd(properties.SegmentSeparator).Split(properties.ElementGroupSeparator);

            // Recorrer cada elemento y realizar la división del mismo por el caracter 'SubElementSeparator'
            foreach (string strLinea in strLineas)
            {
                List<string> strSubElementosFinal = new List<string>();
                string[] strSubElementos = strLinea.Split(properties.ElementSeparator);

                // Recorrer cada subelemento y agregarlo a la lista.
                foreach (string strSubElemento in strSubElementos)
                {
                    #region Final Validation

                    // This validation is for put the original value without release
                    string finalValue = Regex.Replace(strSubElemento, @"°°°|¨¨¨|```",
                        (match) =>
                        {
                            if (match.Value == "¨¨¨") { return string.Format("{0}", properties.ElementGroupSeparator); }
                            else if (match.Value == "°°°") { return string.Format("{0}", properties.ElementSeparator); }
                            else if (match.Value == "```") { return string.Format("{0}", properties.SegmentSeparator); }
                            return match.Value;
                        });

                    #endregion

                    strSubElementosFinal.Add(finalValue);
                }

                // La lista de subelementos agregarla a la de elementos.
                strElementos.Add(strSubElementosFinal);
            }

            return strElementos;
        }

        /// <summary>
        /// Obtener el valor de manera segura de un array bidimensional.
        /// </summary>
        /// <param name="lista">La lista que contiene los datos a procesar para el segmento</param>
        /// <param name="indice1">El elemento dentro del estandar. Inicia en 1, debido a que la posición 0 pertenece al nombre del segmento.</param>
        /// <param name="indice2">El subelemento dentro del elemento. Inicia a partir de 0.</param>
        /// <returns>Cadena con el valor del elemento del array bidimensional</returns>
        public static string GetElementValue(List<List<string>> lista, int indice1, int indice2)
        {
            if (lista == null) return null;

            if (indice1 >= lista.Count) return null;
            if (lista[indice1] == null) return null;

            if (indice2 >= lista[indice1].Count) return null;
            if (lista[indice1][indice2] == null) return null;

            if (string.IsNullOrEmpty(lista[indice1][indice2])) { return null; }
            return lista[indice1][indice2];
        }
    }
}
