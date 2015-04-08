using System;

namespace Motorola.Snapi.Enums
{
    internal static class DataTypeHelper
    {
        public static DataType Convert(Type t)
        {
            if (t == typeof(Array))
                return DataType.A;
            else if (t == typeof(byte))
                return DataType.B;
            else if (t == typeof(Char))
                return DataType.C;
            else if (t == typeof(UInt32))
                return DataType.D;
            else if (t == typeof(bool))
                return DataType.F;
            else if (t == typeof(Int16))
                return DataType.I;
            else if (t == typeof(Int32))
                return DataType.L;
            else if (t == typeof(String))
                return DataType.S;
            else if (t == typeof(UInt32))
                return DataType.W;

            return DataType.Unknown;
        }
    }
}