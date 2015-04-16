using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    public static class StatusAttribute
    {
        public const ushort InCradleDetect = 25000;
        public const ushort OperationalMode = 25001;
        public const ushort Charging = 25002;

        public static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             InCradleDetect,
                                                             OperationalMode,
                                                             Charging
                                                         };
    }
}
