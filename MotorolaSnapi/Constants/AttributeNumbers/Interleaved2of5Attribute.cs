using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class Interleaved2Of5Attribute
    {
        internal const ushort Interleaved2Of5 = 6;
        internal const ushort I2Of5CheckDigitVerification = 49;
        internal const ushort TransmitI2Of5CheckDigit = 44;
        internal const ushort ConvertI2Of5ToEan13 = 82;
        internal const ushort LengthForI2Of5Length1 = 22;
        internal const ushort LengthForI2Of5Length2 = 23;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Interleaved2Of5,
                                                               I2Of5CheckDigitVerification,
                                                               TransmitI2Of5CheckDigit,
                                                               ConvertI2Of5ToEan13,
                                                               LengthForI2Of5Length1,
                                                               LengthForI2Of5Length2
                                                           };
    }
}
