using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class AdfAttribute
    {
        internal const ushort ADFRules = 392;
        internal const ushort KeyDelay = 110;
        internal const ushort PauseDuration = 111;
        internal const ushort KeyCategory1 = 98;
        internal const ushort KeyCategory2 = 99;
        internal const ushort KeyCategory3 = 100;
        internal const ushort KeyCategory4 = 101;
        internal const ushort KeyCategory5 = 102;
        internal const ushort KeyCategory6 = 103;
        internal const ushort KeyValue1 = 104;
        internal const ushort KeyValue2 = 105;
        internal const ushort KeyValue3 = 106;
        internal const ushort KeyValue4 = 107;
        internal const ushort KeyValue5 = 108;
        internal const ushort KeyValue6 = 109;
        internal const ushort SimpleDataFormat = 235;

        internal static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             ADFRules,
                                                             KeyCategory1,
                                                             KeyCategory2,
                                                             KeyCategory3,
                                                             KeyCategory4,
                                                             KeyCategory5,
                                                             KeyCategory6,
                                                             KeyDelay,
                                                             KeyValue1,
                                                             KeyValue2,
                                                             KeyValue3,
                                                             KeyValue4,
                                                             KeyValue5,
                                                             KeyValue6,
                                                             PauseDuration,
                                                             SimpleDataFormat
                                                         };
    }
}