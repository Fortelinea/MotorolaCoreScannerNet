using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class LicenseParsingAttribute
    {
        public const ushort DLParseMode = 645;
        public const ushort DLParseBuffer = 646;

        public static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             DLParseMode,
                                                             DLParseBuffer
                                                         };
    }
}