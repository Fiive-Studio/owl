using System;
using System.Text;

namespace Fiive.Owl.Core.Extensions
{
    /// <summary>
    /// Provide StringBuilder extensions methods
    /// </summary>
    public static class StringBuilderExtension
    {
        /// <summary>
        /// Get a substring
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="startIndex">Start position</param>
        /// <param name="length">Length</param>
        /// <returns>Substring</returns>
        public static string Substring(this StringBuilder sb, int startIndex, int length)
        {
            return sb.ToString(startIndex, length);
        }

        /// <summary>
        /// Remove a character
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="ch">Character</param>
        /// <returns>Processed object</returns>
        public static StringBuilder Remove(this StringBuilder sb, char ch)
        {
            if (sb.Length != 0)
            {
                for (int i = 0; i < sb.Length;)
                {
                    if (sb[i] == ch) { sb.Remove(i, 1); }
                    else { i++; }
                }
            }
            return sb;
        }

        /// <summary>
        /// Remove end characters
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="num">Number of characters to remove</param>
        /// <returns>Processed object</returns>
        public static StringBuilder RemoveFromEnd(this StringBuilder sb, int num)
        {
            return sb.Remove(sb.Length - num, num);
        }

        /// <summary>
        /// Clean the object
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        public static void Clear(this StringBuilder sb)
        {
            sb.Length = 0;
        }

        /// <summary>
        /// Trim left
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <returns>Processed object</returns>
        public static StringBuilder LTrim(this StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                int length = 0;
                int num2 = sb.Length;
                while ((sb[length] == ' ') && (length < num2))
                {
                    length++;
                }
                if (length > 0)
                {
                    sb.Remove(0, length);
                }
            }
            return sb;
        }

        /// <summary>
        /// Trim right
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <returns>Processed object</returns>
        public static StringBuilder RTrim(this StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                int length = sb.Length;
                int num2 = length - 1;
                while ((sb[num2] == ' ') && (num2 > -1))
                {
                    num2--;
                }
                if (num2 < (length - 1))
                {
                    sb.Remove(num2 + 1, (length - num2) - 1);
                }
            }
            return sb;
        }

        /// <summary>
        /// Trim
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <returns>Processed object</returns>
        public static StringBuilder Trim(this StringBuilder sb)
        {
            if (sb.Length != 0)
            {
                int length = 0;
                int num2 = sb.Length;
                while ((sb[length] == ' ') && (length < num2))
                {
                    length++;
                }
                if (length > 0)
                {
                    sb.Remove(0, length);
                    num2 = sb.Length;
                }
                length = num2 - 1;
                while ((sb[length] == ' ') && (length > -1))
                {
                    length--;
                }
                if (length < (num2 - 1))
                {
                    sb.Remove(length + 1, (num2 - length) - 1);
                }
            }
            return sb;
        }

        /// <summary>
        /// Get a character position
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="c">Character to search</param>
        /// <returns>Position number when exist otherwise -1</returns>
        public static int IndexOf(this StringBuilder sb, char value)
        {
            return IndexOf(sb, value, 0);
        }

        /// <summary>
        /// Get a character position
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="c">Character to search</param>
        /// <param name="startIndex">Position where search start</param>
        /// <returns>Position number when exist otherwise -1</returns>
        public static int IndexOf(this StringBuilder sb, char value, int startIndex)
        {
            if (sb.Length == 0) { return -1; }

            for (int i = startIndex; i < sb.Length; i++)
            {
                if (sb[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Get a string position
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="text">Value</param>
        /// <returns>Position number when exist otherwise -1</returns>
        public static int IndexOf(this StringBuilder sb, string value)
        {
            return IndexOf(sb, value, 0, false);
        }

        /// <summary>
        /// Get a string position
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="text">Value</param>
        /// <param name="startIndex">Position where search start</param>
        /// <returns>Position number when exist otherwise -1</returns>
        public static int IndexOf(this StringBuilder sb, string value, int startIndex)
        {
            return IndexOf(sb, value, startIndex, false);
        }

        /// <summary>
        /// Get a string position
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="text">Value</param>
        /// <param name="ignoreCase">Case sensitive</param>
        /// <returns>Position number when exist otherwise -1</returns>
        public static int IndexOf(this StringBuilder sb, string value, bool ignoreCase)
        {
            return IndexOf(sb, value, 0, ignoreCase);
        }

        /// <summary>
        /// Get a string position
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="text">Value</param>
        /// <param name="startIndex">Position where search start</param>
        /// <param name="ignoreCase">Case sensitive</param>
        /// <returns>Position number when exist otherwise -1</returns>
        public static int IndexOf(this StringBuilder sb, string value, int startIndex, bool ignoreCase)
        {
            if (sb.Length == 0) { return -1; }

            int num3;
            int length = value.Length;
            int num2 = (sb.Length - length) + 1;
            if (ignoreCase == false)
            {
                for (int i = startIndex; i < num2; i++)
                {
                    if (sb[i] == value[0])
                    {
                        num3 = 1;
                        while ((num3 < length) && (sb[i + num3] == value[num3]))
                        {
                            num3++;
                        }
                        if (num3 == length)
                        {
                            return i;
                        }
                    }
                }
            }
            else
            {
                for (int j = startIndex; j < num2; j++)
                {
                    if (char.ToLower(sb[j]) == char.ToLower(value[0]))
                    {
                        num3 = 1;
                        while ((num3 < length) && (char.ToLower(sb[j + num3]) == char.ToLower(value[num3])))
                        {
                            num3++;
                        }
                        if (num3 == length)
                        {
                            return j;
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Validate if the value start with the string
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="value">Value</param>
        /// <returns>true when start with the string, otherwise false</returns>
        public static bool StartsWith(this StringBuilder sb, string value)
        {
            return StartsWith(sb, value, 0, false);
        }

        /// <summary>
        /// Validate if the value start with the string
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="value">Value</param>
        /// <param name="ignoreCase">Case sensitive</param>
        /// <returns>true when start with the string, otherwise false</returns>
        public static bool StartsWith(this StringBuilder sb, string value, bool ignoreCase)
        {
            return StartsWith(sb, value, 0, ignoreCase);
        }

        /// <summary>
        /// Validate if the value start with the string
        /// </summary>
        /// <param name="sb">StringBuilder Instance</param>
        /// <param name="value">Value</param>
        /// <param name="startIndex">Position where search start</param>
        /// <param name="ignoreCase">Case sensitive</param>
        /// <returns>true when start with the string, otherwise false</returns>
        public static bool StartsWith(this StringBuilder sb, string value, int startIndex, bool ignoreCase)
        {
            if (sb.Length == 0) { return false; }

            int length = value.Length;
            int num2 = startIndex + length;
            if (ignoreCase == false)
            {
                for (int i = startIndex; i < num2; i++)
                {
                    if (sb[i] != value[i - startIndex])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = startIndex; j < num2; j++)
                {
                    if (char.ToLower(sb[j]) != char.ToLower(value[j - startIndex]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
