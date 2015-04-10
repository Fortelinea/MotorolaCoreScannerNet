using System.ComponentModel;

namespace Motorola.Snapi.Enums
{
    public enum DataType
    {
        Array = 'A',

        [Description("UInt32")]
        D,

        [Description("Int32")]
        L,

        [Description("Int16")]
        I,

        [Description("UInt16")]
        W,

        [Description("Bool")]
        F,

        [Description("String")]
        S,

        [Description("Char")]
        C,

        [Description("Byte")]
        B,

        Unknown
    }
}