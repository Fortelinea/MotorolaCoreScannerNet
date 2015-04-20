using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class Code128Attribute
    {
        internal const ushort Code128 = 8;
        internal const ushort UccEan128 = 14;
        internal const ushort Isbt128 = 84;
        internal const ushort Code128Redundancy = 60;
        internal const ushort Ean128Emulation = 123;
        internal const ushort Code128Length1 = 209;
        internal const ushort Code128Length2 = 210;

        internal static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             Code128,
                                                             Code128Length1,
                                                             Code128Length2,
                                                             Code128Redundancy,
                                                             Ean128Emulation,
                                                             Isbt128,
                                                             UccEan128
                                                         };
    }
}