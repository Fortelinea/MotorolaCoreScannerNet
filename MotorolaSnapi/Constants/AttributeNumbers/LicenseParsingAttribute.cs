using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class LicenseParsingAttribute
    {
        internal const ushort DLParseMode = 645;
        internal const ushort DLParseBuffer = 646;

        internal static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             DLParseMode,
                                                             DLParseBuffer
                                                         };
    }
}