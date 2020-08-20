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
                Texts[ErrorType.IFormatInputIsNull] = "Input structure was not assigned";
                Texts[ErrorType.OwlSettingsIsNull] = "Settings property was not assigned in OwlHandler";
                Texts[ErrorType.ConfigMapNotFound] = "The file: '{0}' configured in PathConfig does not exist";
                Texts[ErrorType.PathConfigMapIsEmpty] = "You must to define PathConfig or XmlConfig";
                Texts[ErrorType.OwlVarUndefined] = "The Variable: '{0}' is not defined";
                Texts[ErrorType.KeywordPropertyUndefined] = "You must to assign the property(es): '{0}'";
                Texts[ErrorType.ErrorOutputElement] = "Error processing output element";
                Texts[ErrorType.XOMLEnumInvalid] = "The property: '{0}' is not valid";
                Texts[ErrorType.XOMLPropertyInvalidValue] = "The value: '{0}' is not valid for the property: '{1}'";
                Texts[ErrorType.ReferenceValuesAndFieldsNotEquals] = "You must configure the same quantity in the properties fields-seek y values-seek";
                Texts[ErrorType.ReferenceTableDontExist] = "The table: '{0}' does not exist in the References DataSet";
                Texts[ErrorType.ReferenceColumnDontExist] = "The column(s): '{0}' do not exist(s) in the References DataSet";
                Texts[ErrorType.ReferenceDataSetNull] = "The References DataSet is null";
                Texts[ErrorType.IfNonNumericValue] = "The operator: '{0}' configured in the property: '{1}' require than the value: '{2}' in the property: '{3}' be numeric";
                Texts[ErrorType.XOMLNumericValue] = "The value: '{0}' in the property: '{1}' must be numeric";
                Texts[ErrorType.TagsDoesNotExists] = "It require the tags value-1 y value-2 in the parent tag: '{0}'";
                Texts[ErrorType.TagInvalid] = "The tag: '{0}' is not valid in the block: '{1}'";
                Texts[ErrorType.InvalidSegment] = "The segment: '{0}' is not valid";
                Texts[ErrorType.ErrorLoadInputFile] = "Error loading the file: '{0}' in the input structure";
                Texts[ErrorType.ErrorExecuteExpression] = "Error executing the expression: '{0}'";
                Texts[ErrorType.ErrorConfigChildPathBase] = "The path in the base configuration: '{0}' is not correctly configured";
                Texts[ErrorType.ErrorLoadConfigMap] = "Error loading the Config Xml file";
                Texts[ErrorType.ErrorLoadConfigMapBase] = "Error loading Config Xml Base file";
                Texts[ErrorType.ErrorConfigBaseDoesNotExist] = "The Xml Config Base with id: '{0}' does not exist in the file";
                Texts[ErrorType.XOMLPropertyDoesNotExist] = "The property: '{0}' is mandatory";
                Texts[ErrorType.FormatNotValid] = "The Format Configuration: '{0}' is not valid";
                Texts[ErrorType.FormatIsForNumbers] = "The field has the value: '{0}' and the format: '{1}' only is allowed in numeric values";
                Texts[ErrorType.LengthIsForNumbers] = "The field has the value: '{0}' and the element has data type or numeric length";
                Texts[ErrorType.CounterCountParametersNotValid] = "The Counter: '{0}' has: '{1}' parameters and it must have 2";
                Texts[ErrorType.CounterEmptyParameter] = "The parameter: '{0}' in the Counter: '{1}' is empty and his value is mandatory";
                Texts[ErrorType.CounterParameterIsForNumbers] = "The parameter: '{0}' in the Counter: '{1}' has the value: '{2}' and his value must be numeric";
                Texts[ErrorType.CounterVariableModified] = "The Variable: '{0}' was modified with the alphanumeric value: '{1}' but it is being used by the Counter: '{2}'";
                Texts[ErrorType.ReservadaWordDoesNotSupport] = "The Key: '{0}' is not supported by the output structure";
                Texts[ErrorType.ErrorOutputSection] = "Error processing the output section";
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
        CounterCountParametersNotValid = 28,
        CounterEmptyParameter = 29,
        CounterParameterIsForNumbers = 30,
        CounterVariableModified = 31,
        ReservadaWordDoesNotSupport = 32,
        ErrorOutputSection = 33,
        ErrorLoadConfigMapBase = 34,
    }

    #endregion
}
