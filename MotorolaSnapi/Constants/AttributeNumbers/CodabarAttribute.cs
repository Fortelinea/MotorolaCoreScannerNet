using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class CodabarAttribute
    {
        internal const ushort Codabar = 7;
        internal const ushort ClsiEditing = 54;
        internal const ushort NotisEditing = 55;
        internal const ushort LengthForCodabarLength1 = 24;
        internal const ushort LengthForCodabarLength2 = 25;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               Codabar,
                                                               ClsiEditing,
                                                               NotisEditing,
                                                               LengthForCodabarLength1,
                                                               LengthForCodabarLength2
                                                           };
    }
}