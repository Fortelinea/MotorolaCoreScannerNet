using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class SymbologySecurityAttribute 
    {
        internal const ushort RedundancyLevel = 78;
        internal const ushort SecurityLevel = 77;
        internal const ushort BidirectionalRedundancy = 67;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               RedundancyLevel,
                                                               SecurityLevel,
                                                               BidirectionalRedundancy
                                                           };
    }
}