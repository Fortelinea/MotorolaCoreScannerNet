using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal class Code11Attribute 
    {
        internal const ushort Code11 = 10;
        internal const ushort Code11CheckDigitVerification = 52;
        internal const ushort TransmitCode11CheckDigit = 47;
        internal const ushort LengthForCode11Length1 = 28;
        internal const ushort LengthForCode11Length2 = 29;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Code11,
                                                               Code11CheckDigitVerification,
                                                               TransmitCode11CheckDigit,
                                                               LengthForCode11Length1,
                                                               LengthForCode11Length2
                                                           };
    }
}