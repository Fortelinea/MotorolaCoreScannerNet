using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal class RssGs1DatabarAttribute
    {
        internal const ushort Gs1DataBar14 = 338;
        internal const ushort Gs1DataBarLimited = 339;
        internal const ushort Gs1DataBarExpanded = 340;
        internal const ushort ConvertGs1DataBarToUpcean = 397;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Gs1DataBar14,
                                                               Gs1DataBarLimited,
                                                               Gs1DataBarExpanded,
                                                               ConvertGs1DataBarToUpcean
                                                           };
    }
}