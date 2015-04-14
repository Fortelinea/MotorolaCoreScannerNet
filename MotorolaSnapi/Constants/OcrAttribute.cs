using System.Collections.Generic;

namespace Motorola.Snapi.Constants
{
    public static class OcrAttribute
    {
        public const ushort Template = 547;
        public const ushort SecurityLevel = 554;
        public const ushort OcrAEnable = 680;
        public const ushort OcrBEnable = 681;
        public const ushort Micre13BEnable = 682;
        public const ushort UsCurrencyEnable = 683;
        public const ushort OcrAVariant = 684;
        public const ushort OcrBVariant = 685;
        public const ushort ValidCharacters = 686;
        public const ushort Orientation = 687;
        public const ushort CheckDigitMod = 688;
        public const ushort MinCharacters = 689;
        public const ushort MaxCharacters = 690;
        public const ushort Lines = 691;
        public const ushort CheckDigitValidation = 694;
        public const ushort QuietZone = 695;
        public const ushort WhiteLevel = 696;
        public const ushort Despeckle = 697;
        public const ushort Thicken = 698;
        public const ushort LowPassFilter = 699;
        public const ushort CheckDigitMultiplier = 700;
        public const ushort EnableIllumination = 701;
        public const ushort EnableFinder = 702;
        public const ushort EnableExternalFinder = 707;
        public static readonly IEnumerable<ushort> All = new []
                                                {
                                                    Template,
                                                    SecurityLevel,
                                                    OcrAEnable,
                                                    OcrBEnable,
                                                    Micre13BEnable,
                                                    UsCurrencyEnable,
                                                    OcrAVariant,
                                                    OcrBVariant,
                                                    ValidCharacters,
                                                    Orientation,
                                                    CheckDigitMod,
                                                    MinCharacters,
                                                    MaxCharacters,
                                                    Lines,
                                                    CheckDigitValidation,
                                                    QuietZone,
                                                    WhiteLevel,
                                                    Despeckle,
                                                    Thicken,
                                                    LowPassFilter,
                                                    CheckDigitMultiplier,
                                                    EnableIllumination,
                                                    EnableFinder,
                                                    EnableExternalFinder
                                                };
    }
}
