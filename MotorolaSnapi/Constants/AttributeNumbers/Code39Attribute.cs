using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class Code39Attribute
    {
        internal const ushort Code39 = 0;
        internal const ushort TriopticCode39 = 13;
        internal const ushort ConvertCode39ToCode32 = 86;
        internal const ushort Code32Prefix = 231;
        internal const ushort LengthForCode39Length1 = 18;
        internal const ushort LengthForCode39Length2 = 19;
        internal const ushort Code39CheckDigitVerification = 48;
        internal const ushort TransmitCode39CheckDigit = 43;
        internal const ushort Code39FullAsciiConversion = 17;
        internal const ushort BufferCode39 = 113;

        internal static readonly IEnumerable<ushort> All = new[]
                                                  {
                                                      Code39,
                                                      TriopticCode39,
                                                      ConvertCode39ToCode32,
                                                      Code32Prefix,
                                                      LengthForCode39Length1,
                                                      LengthForCode39Length2,
                                                      Code39CheckDigitVerification,
                                                      TransmitCode39CheckDigit,
                                                      Code39FullAsciiConversion,
                                                      BufferCode39
                                                  };
    }
}
