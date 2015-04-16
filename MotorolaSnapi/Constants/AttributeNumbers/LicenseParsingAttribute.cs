using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    public static class LicenseParsingAttribute
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