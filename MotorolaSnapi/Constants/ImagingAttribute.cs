using System.Collections.Generic;

namespace Motorola.Snapi.Constants
{
    public static class ImagingAttribute
    {
        public const ushort CropTop = 315;
        public const ushort CropLeft = 316;
        public const ushort CropBottom = 317;
        public const ushort CropRight = 318;
        public const ushort JPEGFileSizeWord = 561;
        public const ushort Exposure = 567;
        public const ushort SnapshotByMotion = 647;
        public const ushort ContinuousSnapshot = 648;
        public const ushort ImageEdgeSharpen = 664;
        public const ushort ImageRotation = 665;
        public const ushort ContrastEnhancement = 666;
        public const ushort VideoSubsample = 667;
        public const ushort AimBrightness = 668;
        public const ushort IlluminationBrightness = 669;

        public static readonly IEnumerable<ushort> All = new[]
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
