using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class PostalAttribute
    {
        internal const ushort UsPost1 = 89;
        internal const ushort UsPost2 = 90;
        internal const ushort UkPost = 91;
        internal const ushort CanadaPost = 92;
        internal const ushort UsPostParity = 95;
        internal const ushort UkPostParity = 96;
        internal const ushort JapanPost = 290;
        internal const ushort AusPost = 291;

        internal static readonly IEnumerable<ushort> All = new[]
                                                           {
                                                               UsPost1,
                                                               UsPost2,
                                                               UkPost,
                                                               CanadaPost,
                                                               UsPostParity,
                                                               UkPostParity,
                                                               JapanPost,
                                                               AusPost
                                                           };
    }
}
