using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class BeeperAttribute
    {
        public const ushort BeeperVolume = 140;
        public const ushort BeeperFrequency = 145;
        public static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             BeeperFrequency,
                                                             BeeperVolume
                                                         };
    }
}