using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class ImagingAttribute
    {
        internal const ushort CropTop = 315;
        internal const ushort CropLeft = 316;
        internal const ushort CropBottom = 317;
        internal const ushort CropRight = 318;
        internal const ushort JPEGFileSizeWord = 561;
        internal const ushort Exposure = 567;
        internal const ushort SnapshotByMotion = 647;
        internal const ushort ContinuousSnapshot = 648;
        internal const ushort ImageEdgeSharpen = 664;
        internal const ushort ImageRotation = 665;
        internal const ushort ContrastEnhancement = 666;
        internal const ushort VideoSubsample = 667;
        internal const ushort AimBrightness = 668;
        internal const ushort IlluminationBrightness = 669;

        internal static readonly IEnumerable<ushort> All = new[]
                                                         {
                                                             CropTop,
                                                             CropBottom,
                                                             CropLeft,
                                                             CropRight,
                                                             JPEGFileSizeWord,
                                                             Exposure,
                                                             SnapshotByMotion,
                                                             ContinuousSnapshot,
                                                             ImageEdgeSharpen,
                                                             ImageRotation,
                                                             ContrastEnhancement,
                                                             VideoSubsample,
                                                             AimBrightness,
                                                             IlluminationBrightness
                                                         };
    }
}
