using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class PdfAttribute
    {
        internal const ushort Pdf = 15;
        internal const ushort MicroPdf = 227;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Pdf,
                                                               MicroPdf
                                                           };
    }
}