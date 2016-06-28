/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.Linq;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    /// <summary>
    ///     Static class containing methods for converting Motorola's xml string data values to their respective .NET data
    ///     types and vice versa.
    /// </summary>
    internal static class ValueConverters
    {

        internal static string ByteArrayToHexString(byte[] value)
        {
            var hex = BitConverter.ToString(value);
            hex = hex.Insert(0, "0x");
            hex = hex.Replace("-", " 0x");
            return hex;
        }

        internal static int HexCharToInt(char c)
        {
            int val = c;
            if (((c >= '0') && (c <= '9')) || ((c >= 'A') && (c <= 'F')) || ((c >= 'a') && (c <= 'f')))
                return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
            throw new ArgumentException("Invalid hex digit: " + c);
        }

        /// <summary>
        ///     Converts a string of hexadecimal bytes to a byte[].
        /// </summary>
        /// <param name="hex">String of hexadecimal digits</param>
        /// <returns></returns>
        internal static byte[] HexStringToByteArray(string hex)
        {
            var hexadecimal = hex.Replace(" ", "").Replace("0x", "");
            if ((hexadecimal.Length%2) == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            var arr = new byte[hexadecimal.Length >> 1];

            for (var i = 0; i < (hexadecimal.Length >> 1); ++i)
                arr[i] = (byte)((HexCharToInt(hexadecimal[i << 1]) << 4) + HexCharToInt(hexadecimal[(i << 1) + 1]));

            return arr;
        }

        /// <summary>
        ///     Converts data strings from scanner to their proper data type.
        /// </summary>
        /// <param name="dataType">Motorola type represented by a byte.</param>
        /// <param name="stringValue">String representation of the data to convert.</param>
        /// <returns>Value with proper .NET type.</returns>
        internal static object StringToActualType(DataType dataType, string stringValue)
        {
            object value = null;
            switch (dataType)
            {
                case DataType.Array:
                {
                    value = HexStringToByteArray(stringValue);
                    var array = (byte[])value;
                    if (array.Length == 1)
                        value = array[0];
                    break;
                }
                case DataType.Byte:
                {
                    value = byte.Parse(stringValue);
                    break;
                }
                case DataType.Char:
                {
                    //Not used;
                    break;
                }
                case DataType.UInt:
                {
                    //Not used;
                    break;
                }
                case DataType.Bool:
                {
                    value = !stringValue.Equals("False");
                    break;
                }
                case DataType.Short:
                {
                    //Not used;
                    break;
                }
                case DataType.Int:
                {
                    //Not used;
                    break;
                }
                case DataType.String:
                {
                    value = stringValue;
                    break;
                }
                case DataType.UShort:
                {
                    value = ushort.Parse(stringValue);
                    break;
                }
            }
            return value;
        }

        internal static DataType TypeToDataType(Type t)
        {
            if (t == typeof(byte[]))
                return DataType.Array;
            if (t == typeof(byte))
                return DataType.Byte;
            if (t == typeof(char))
                return DataType.Char;
            if (t == typeof(uint))
                return DataType.UInt;
            if (t == typeof(bool))
                return DataType.Bool;
            if (t == typeof(short))
                return DataType.Short;
            if (t == typeof(int))
                return DataType.Int;
            if (t == typeof(string))
                return DataType.String;
            if (t == typeof(ushort))
                return DataType.UShort;

            return DataType.Unknown;
        }
    }
}