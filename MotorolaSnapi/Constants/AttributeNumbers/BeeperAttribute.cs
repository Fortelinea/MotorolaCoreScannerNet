using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class BeeperAttribute
    {
        internal const ushort BeeperVolume = 140;
        internal const ushort BeeperFrequency = 145;
        internal static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             BeeperFrequency,
                                                             BeeperVolume
                                                         };
    }
}