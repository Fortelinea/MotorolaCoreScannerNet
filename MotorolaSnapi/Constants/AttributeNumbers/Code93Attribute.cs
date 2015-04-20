using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal class Code93Attribute
    {
        internal const ushort Code93 = 9;
        internal const ushort LengthForCode93Length1 = 26;
        internal const ushort LengthForCode93Length2 = 27;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Code93,
                                                               LengthForCode93Length1,
                                                               LengthForCode93Length2,
                                                           };
    }
}
