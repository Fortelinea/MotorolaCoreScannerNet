using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class Code128Attribute
    {
        public const ushort Code128 = 8;
        public const ushort UccEan128 = 14;
        public const ushort Isbt128 = 84;
        public const ushort Code128Redundancy = 60;
        public const ushort Ean128Emulation = 123;
        public const ushort Code128Length1 = 209;
        public const ushort Code128Length2 = 210;

        public static readonly IEnumerable<ushort> All = new[]
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