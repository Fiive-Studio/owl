using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiive.Owl.Core.Exceptions;
using Fiive.Owl.Core.Extensions;

namespace Fiive.Owl.Formats.Output.Auxiliar
{
    public class FieldLength
    {
        #region Properties

        int _integerPart;
        /// <summary>
        /// Obtiene / Establece la longitud de la parte entera
        /// </summary>
        public int IntegerPart
        {
            get { return _integerPart; }
            set
            {
                if (value < -1) { _integerPart = -1; }
                else { _integerPart = value; }
            }
        }

        int _decimalPart;
        /// <summary>
        /// Obtiene / Establece la longitud de la parte decimal
        /// </summary>
        public int DecimalPart
        {
            get { return _decimalPart; }
            set
            {
                if (value < -1) { _decimalPart = -1; }
                else { _decimalPart = value; }
            }
        }

        /// <summary>
        /// Obtiene / Establece si se valida la parte decimal
        /// </summary>
        public bool ValidateDecimalPart { get; set; }

        /// <summary>
        /// Obtiene / Establece la posicion de la alineacion
        /// </summary>
        public AligmentType Aligment { get; set; }

        /// <summary>
        /// Obtiene / Establece la forma de rellenar cuando el valor es vacio
        /// </summary>
        public Padding PaddingWhenIsEmpty { get; set; }

        /// <summary>
        /// Obtiene / Establece el caracter de relleno
        /// </summary>
        public char PaddingChar { get; set; }

        /// <summary>
        /// Obtiene / Establece el caracter de la parte decimal
        /// </summary>
        public char PaddingCharDecimalPart { get; set; }

        #endregion

        #region Enum

        /// <summary>
        /// Posicion de relleno
        /// </summary>
        public enum AligmentType
        {
            /// <summary>
            /// Indica que No Aplica
            /// </summary>
            NotApply = 0,
            /// <summary>
            /// Indica Derecha
            /// </summary>
            Right = 1,
            /// <summary>
            /// Indica Izquierda
            /// </summary>
            Left = 2,
            /// <summary>
            /// Indica Numero con separador
            /// </summary>
            Number = 3,
            /// <summary>
            /// Indica Numero sin separador
            /// </summary>
            NumberWithoutSeparator = 4
        }

        /// <summary>
        /// Indicate how to do the pad
        /// </summary>
        public enum Padding
        {
            Pad = 0,
            NotPad = 1,
            PadWithoutSeparator = 2
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Construye la clase
        /// </summary>
        /// <param name="eval">Expresion a evaluar</param>
        public FieldLength(string eval)
        {
            // "5/Izquierda/ " <-- Expresion a evaluar (Texto)
            // "5,2/Numero-S/ , " <-- Expresion a evaluar (Numero)

            string[] parts = eval.Split(new char[] { '/' }, 4);
            PaddingChar = ' ';

            if (parts.Length == 4)
            {
                if (parts[3] == "Completar") { PaddingWhenIsEmpty = Padding.Pad; }
                else if (parts[3] == "NoCompletar") { PaddingWhenIsEmpty = Padding.NotPad; }
                else if (parts[3] == "Completar-S") { PaddingWhenIsEmpty = Padding.PadWithoutSeparator; }
                else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLPropertyInvalidValue), parts[3], "PaddingWhenIsEmpty")); }
            }

            if (parts.Length >= 3)
            {
                if (parts[2].Length > 0)
                {
                    string[] partsPadding = parts[2].Split(',');
                    if (partsPadding.Length > 2) { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLPropertyInvalidValue), eval, "Length")); }

                    if (partsPadding[0].Length > 0) { PaddingChar = partsPadding[0][0]; }
                    if (partsPadding.Length == 2 && partsPadding[1].Length > 0) { PaddingCharDecimalPart = partsPadding[1][0]; }
                }
            }

            if (parts.Length >= 2)
            {
                if (parts[1] == "Izquierda") { Aligment = AligmentType.Left; }
                else if (parts[1] == "Derecha") { Aligment = AligmentType.Right; }
                else if (parts[1] == "Numero") { Aligment = AligmentType.Number; }
                else if (parts[1] == "Numero-S") { Aligment = AligmentType.NumberWithoutSeparator; }
                else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLPropertyInvalidValue), parts[1], "Aligment")); }
            }
            else { Aligment = AligmentType.NotApply; }

            SetNumbersParts(parts[0]);
        }

        #endregion

        #region Privates

        /// <summary>
        /// Procesa la longitud numerica
        /// </summary>
        /// <param name="eval">Expresion a evaluar</param>
        void SetNumbersParts(string eval)
        {
            // 5,2 <-- Expresion a evaluar
            string[] parts = eval.Split(',');

            if (parts.Length > 2) { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLPropertyInvalidValue), eval, "Length")); }

            #region Parte Decimal

            ValidateDecimalPart = false;
            if (parts.Length == 2)
            {
                if (parts[1] == "*") { _decimalPart = -1; }
                else
                {
                    if (parts[1].IsInt()) { _decimalPart = Convert.ToInt32(parts[1]); }
                    else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLNumericValue), parts[1], "Length")); }
                }

                ValidateDecimalPart = true;
            }

            #endregion

            #region Parte Entera

            if (parts[0] == "*") { _integerPart = -1; }
            else
            {
                if (parts[0].IsInt()) { _integerPart = Convert.ToInt32(parts[0]); }
                else { throw new OwlException(string.Format(ETexts.GT(ErrorType.XPMLNumericValue), parts[0], "Length")); }
            }

            #endregion
        }

        #endregion

        #region Publics

        /// <summary>
        /// Obtiene una cadena que representa la clase
        /// </summary>
        /// <returns>Cadena que representa la clase</returns>
        public override string ToString()
        {
            string numero = _integerPart == -1 ? "*" : _integerPart.ToString();
            if (ValidateDecimalPart) { numero += "," + (_decimalPart == -1 ? "*" : _decimalPart.ToString()); }

            string alineacion = string.Empty;
            if (Aligment == AligmentType.Right) { alineacion = "/Derecha"; }
            else if (Aligment == AligmentType.Left) { alineacion = "/Izquierda"; }
            else if (Aligment == AligmentType.Number) { alineacion = "/Numero"; }
            else if (Aligment == AligmentType.NumberWithoutSeparator) { alineacion = "/Numero-S"; }

            string relleno = string.Empty;
            string padding = string.Empty;
            if (alineacion != string.Empty)
            {
                relleno = "/" + PaddingChar.ToString();
                if(PaddingCharDecimalPart != char.MinValue) { relleno += string.Concat(",", PaddingCharDecimalPart); }

                if (PaddingWhenIsEmpty == Padding.Pad) { padding = "/Completar"; }
                else if (PaddingWhenIsEmpty == Padding.NotPad) { padding = "/NoCompletar"; }
                else if (PaddingWhenIsEmpty == Padding.PadWithoutSeparator) { padding = "/Completar-S"; }
            }

            return string.Concat(numero, alineacion, relleno, padding);
        }

        #endregion
    }

}
