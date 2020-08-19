using System;
using System.Collections.Generic;
using System.Text;

namespace Fiive.Owl.Core.Exceptions
{
    public static class ETexts
    {
        static Dictionary<ErrorType, string> Texts = new Dictionary<ErrorType, string>();

        /// <summary>
        /// Load texts
        /// </summary>
        public static void LoadTexts()
        {
            lock (Texts)
            {
                if (Texts.Count != 0) { return; }
                Texts[ErrorType.IFormatInputIsNull] = "No se asigno estructura de entrada";
                Texts[ErrorType.OwlSettingsIsNull] = "No se asigno la propiedad Settings en OwlHandler";
                Texts[ErrorType.ConfigMapNotFound] = "El archivo: '{0}' que se definio en PathConfig no existe";
                Texts[ErrorType.PathConfigMapIsEmpty] = "No se definio el PathConfig o XmlConfig";
                Texts[ErrorType.OwlVarUndefined] = "La Variable: '{0}' no esta definida";
                Texts[ErrorType.KeywordPropertyUndefined] = "Se deben asignar las propiedad(es): '{0}'";
                Texts[ErrorType.ErrorOutputElement] = "Error al procesar el elemento de salida";
                Texts[ErrorType.XOMLEnumInvalid] = "La propiedad: '{0}' no es valida";
                Texts[ErrorType.XOMLPropertyInvalidValue] = "El valor: '{0}' no es valido para la propiedad: '{1}'";
                Texts[ErrorType.ReferenceValuesAndFieldsNotEquals] = "Se debe configurar la misma cantidad de valores en las propiedades CamposBuscar y ValoresBuscar";
                Texts[ErrorType.ReferenceTableDontExist] = "La tabla: '{0}' no existe en el DataSet de referencias";
                Texts[ErrorType.ReferenceColumnDontExist] = "La(s) columna(s): '{0}' no existe(n) en el DataSet de referencias";
                Texts[ErrorType.ReferenceDataSetNull] = "El DataSet de referencia esta nulo";
                Texts[ErrorType.IfNonNumericValue] = "El operador: '{0}' configurado en la propiedad: '{1}' requiere que el valor: '{2}' en la propiedad: '{3}' sea numerico";
                Texts[ErrorType.XOMLNumericValue] = "El valor : '{0}' de la propiedad: '{1}' debe ser numerico";
                Texts[ErrorType.TagsDoesNotExists] = "Se requieren las etiquetas Valor1 y Valor2 en la etiqueta padre: '{0}'";
                Texts[ErrorType.TagInvalid] = "La etiqueta: '{0}' no es valida en el bloque: '{1}'";
                Texts[ErrorType.InvalidSegment] = "El segmento: '{0}' no es valido";
                Texts[ErrorType.ErrorLoadInputFile] = "Error al cargar el archivo: '{0}' en la estructura de entrada";
                Texts[ErrorType.ErrorExecuteExpression] = "Error al ejecutar la expresion: '{0}'";
                Texts[ErrorType.ErrorConfigChildPathBase] = "La ruta de la configuracion base: '{0}' no esta correctamente configurada";
                Texts[ErrorType.ErrorLoadConfigMap] = "Error al cargar el archivo de Configuracion Xml";
                Texts[ErrorType.ErrorLoadConfigMapBase] = "Error al cargar el archivo de Configuracion Xml Base";
                Texts[ErrorType.ErrorConfigBaseDoesNotExist] = "La configuracion Base con Id: '{0}' no existe en el archivo de Configuracion Xml Base";
                Texts[ErrorType.XOMLPropertyDoesNotExist] = "La propiedad: '{0}' es obligatoria";
                Texts[ErrorType.FormatNotValid] = "La configuración: '{0}' de Formato no es valida";
                Texts[ErrorType.FormatIsForNumbers] = "El campo tiene el valor: '{0}' y el Formato: '{1}' solo es para valores numéricos";
                Texts[ErrorType.LengthIsForNumbers] = "El campo tiene el valor: '{0}' y el Elemento tiene Tipo Dato o Longitud Numerica";
                Texts[ErrorType.ContadorCountParametersNotValid] = "La configuración del Contador: '{0}' tiene: '{1}' parámetros y debe tener 2";
                Texts[ErrorType.ContadorEmptyParameter] = "El Parametro: '{0}' del Contador: '{1}' esta vacio y su valor es obligatorio";
                Texts[ErrorType.ContadorParameterIsForNumbers] = "El Parametro: '{0}' del Contador: '{1}' tiene el valor: '{2}' y su valor debe ser numérico";
                Texts[ErrorType.ContadorVariableModified] = "La Variable: '{0}' fue modificada por el valor: '{1}' el cual es alfanumérico y esta siendo usada por el Contador: '{2}'";
                Texts[ErrorType.ReservadaWordDoesNotSupport] = "La palabra Reservada: '{0}' no es soportada por la estructura de salida usada";
                Texts[ErrorType.ErrorOutputSection] = "Error al procesar la seccion de salida";
            }
        }

        /// <summary>
        /// Get text
        /// </summary>
        public static string GT(ErrorType key)
        {
            if (Texts.Count == 0) { LoadTexts(); }
            if (Texts.ContainsKey(key)) { return Texts[key]; }
            return string.Empty;
        }
    }

    #region Enum

    /// <summary>
    /// Define tipos de errores para las excepciones
    /// </summary>
    public enum ErrorType
    {
        OwlSettingsIsNull = 1,
        ConfigMapNotFound = 2,
        PathConfigMapIsEmpty = 3,
        OwlVarUndefined = 4,
        KeywordPropertyUndefined = 5,
        ErrorOutputElement = 6,
        XOMLEnumInvalid = 7,
        XOMLPropertyInvalidValue = 8,
        ReferenceValuesAndFieldsNotEquals = 9,
        ReferenceTableDontExist = 10,
        ReferenceColumnDontExist = 11,
        ReferenceDataSetNull = 12,
        IfNonNumericValue = 13,
        XOMLNumericValue = 14,
        TagsDoesNotExists = 15,
        TagInvalid = 16,
        InvalidSegment = 17,
        ErrorLoadInputFile = 18,
        ErrorExecuteExpression = 19,
        ErrorConfigChildPathBase = 20,
        ErrorLoadConfigMap = 21,
        ErrorConfigBaseDoesNotExist = 22,
        IFormatInputIsNull = 23,
        XOMLPropertyDoesNotExist = 24,
        FormatNotValid = 25,
        FormatIsForNumbers = 26,
        LengthIsForNumbers = 27,
        ContadorCountParametersNotValid = 28,
        ContadorEmptyParameter = 29,
        ContadorParameterIsForNumbers = 30,
        ContadorVariableModified = 31,
        ReservadaWordDoesNotSupport = 32,
        ErrorOutputSection = 33,
        ErrorLoadConfigMapBase = 34,
    }

    #endregion
}
