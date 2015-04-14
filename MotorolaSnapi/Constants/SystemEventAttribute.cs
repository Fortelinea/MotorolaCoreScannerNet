using System.Collections.Generic;

namespace Motorola.Snapi.Constants
{
    public static class SystemEventAttribute
    {
        public const ushort DecodeEvent = 256;
        public const ushort BootupEvent = 258;
        public const ushort ParamEvent = 259;

        public static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             DecodeEvent,
                                                             BootupEvent,
                                                             ParamEvent
                                                         };
    }
}
