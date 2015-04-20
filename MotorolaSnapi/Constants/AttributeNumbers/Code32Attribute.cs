using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class Code32Attribute
    {
        internal const ushort Code32 = 86;
        internal const ushort Code32Prefix = 231;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Code32,
                                                               Code32Prefix
                                                           };
    }
}
