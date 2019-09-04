using System;
using System.Collections.Generic;
using System.Text;

namespace Owl.Core.Extensions
{
    /// <summary>
    /// Provide String extensions methods
    /// </summary>
    public static class StringExtension
    {
        #region Validations

        /// <summary>
        /// Validate if the string represent an Int value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Validation result</returns>
        public static bool IsInt(this string value) { return int.TryParse(value, out _); }

        /// <summary>
        /// Validate if the string represent an Decimal value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Validation result</returns>
        public static bool IsDecimal(this string value) { return decimal.TryParse(value, out _); }

        #endregion

        #region Substring

        /// <summary>
        /// Retrieves a substring from this instance
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance</param>
        /// <returns>A string that is equivalent to the substring, when the position does not exist String.Empty</returns>
        public static string GetSafeSubstring(this string value, int startIndex)
        {
            if (value == null) { return string.Empty; }
            return value.GetSafeSubstring(startIndex, value.Length, false);
        }

        /// <summary>
        /// Retrieves a substring from this instance
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance</param>
        /// <param name="length">The number of characters in the substring</param>
        /// <returns>A string that is equivalent to the substring, when the position does not exist String.Empty</returns>
        public static string GetSafeSubstring(this string value, int startIndex, int length)
        {
            if (value == null) { return string.Empty; }
            return value.GetSafeSubstring(startIndex, length, false);
        }

        /// <summary>
        /// Retrieves a substring from this instance
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance</param>
        /// <param name="trim">When the value is true, return value remove whitespaces in the start and end</param>
        /// <returns>A string that is equivalent to the substring, when the position does not exist String.Empty</returns>
        public static string GetSafeSubstring(this string value, int startIndex, bool trim)
        {
            if (value == null) { return string.Empty; }
            return value.GetSafeSubstring(startIndex, value.Length, trim);
        }

        /// <summary>
        /// Retrieves a substring from this instance
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance</param>
        /// <param name="length">The number of characters in the substring</param>
        /// <param name="trim">When the value is true, return value remove whitespaces in the start and end</param>
        /// <returns>A string that is equivalent to the substring, when the position does not exist String.Empty</returns>
        public static string GetSafeSubstring(this string value, int startIndex, int length, bool trim)
        {
            if (value == null) { return string.Empty; }
            return value.GetSafeSubstring(startIndex, length, trim, true);
        }

        /// <summary>
        /// Retrieves a substring from this instance
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance</param>
        /// <param name="length">The number of characters in the substring</param>
        /// <param name="trim">When the value is true, return value remove whitespaces in the start and end</param>
        /// <param name="allowNull">true si en caso de ser null el valor de entrada se devuelve String.Empty, false si en caso de ser null el valor de entrada se devuelve null</param>
        /// <returns>>A string that is equivalent to the substring, when the position does not exist, if allowNull is true String.Empty otherwise null</returns>
        public static string GetSafeSubstring(this string value, int startIndex, int length, bool trim, bool allowNull)
        {
            string stringReturn = string.Empty;

            if (value == null)
            {
                if (!allowNull) { return null; }
                return stringReturn;
            }

            if (startIndex < 0) { startIndex = 0; }
            if (length < 0) { length = 0; }

            if ((value.Length < (startIndex + length)) && value.Length > startIndex)
            {
                stringReturn = value.Substring(startIndex);
            }
            else if (value.Length >= (startIndex + length))
            {
                stringReturn = value.Substring(startIndex, length);
            }

            if (trim) { stringReturn = stringReturn.Trim(); }
            return stringReturn;
        }

        #endregion
    }
}
