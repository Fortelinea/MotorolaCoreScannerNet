using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class SystemEventAttribute
    {
        internal const ushort DecodeEvent = 256;
        internal const ushort BootupEvent = 258;
        internal const ushort ParamEvent = 259;

        internal static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             DecodeEvent,
                                                             BootupEvent,
                                                             ParamEvent
                                                         };
    }
}
