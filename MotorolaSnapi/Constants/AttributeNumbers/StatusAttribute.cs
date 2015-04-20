using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class StatusAttribute
    {
        internal const ushort InCradleDetect = 25000;
        internal const ushort OperationalMode = 25001;
        internal const ushort Charging = 25002;

        internal static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             InCradleDetect,
                                                             OperationalMode,
                                                             Charging
                                                         };
    }
}
