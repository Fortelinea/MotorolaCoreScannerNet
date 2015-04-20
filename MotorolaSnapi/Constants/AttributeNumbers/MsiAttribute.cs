using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class MsiAttribute
    {
        internal const ushort Msi = 11;
        internal const ushort MsiCheckDigits = 50;
        internal const ushort TransmitMsiCheckDigit = 46;
        internal const ushort MsiCheckDigitAlgorithm = 51;
        internal const ushort LengthForMsiLength1 = 30;
        internal const ushort LengthForMsiLength2 = 30;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Msi,
                                                               MsiCheckDigits,
                                                               TransmitMsiCheckDigit,
                                                               MsiCheckDigitAlgorithm,
                                                               LengthForMsiLength1,
                                                               LengthForMsiLength2
                                                           };
    }
}