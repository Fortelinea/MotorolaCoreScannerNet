using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class AdfAttribute
    {
        public const ushort ADFRules = 392;
        public const ushort KeyDelay = 110;
        public const ushort PauseDuration = 111;
        public const ushort KeyCategory1 = 98;
        public const ushort KeyCategory2 = 99;
        public const ushort KeyCategory3 = 100;
        public const ushort KeyCategory4 = 101;
        public const ushort KeyCategory5 = 102;
        public const ushort KeyCategory6 = 103;
        public const ushort KeyValue1 = 104;
        public const ushort KeyValue2 = 105;
        public const ushort KeyValue3 = 106;
        public const ushort KeyValue4 = 107;
        public const ushort KeyValue5 = 108;
        public const ushort KeyValue6 = 109;
        public const ushort SimpleDataFormat = 235;

        public static readonly IEnumerable<ushort> All = new[]
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