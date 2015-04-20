using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class Discrete2Of5Attribute
    {
        internal const ushort Discrete2Of5 = 5;
        internal const ushort LengthForD2Of5Length1 = 20;
        internal const ushort LengthForD2Of5Length2 = 21;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Discrete2Of5,
                                                               LengthForD2Of5Length1,
                                                               LengthForD2Of5Length2
                                                           };
    }
}
