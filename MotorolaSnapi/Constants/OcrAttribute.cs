using System.Collections.Generic;

namespace Motorola.Snapi.Constants
{
    public static class OcrAttribute
    {
        public static ushort Template = 547;
        public static ushort SecurityLevel = 554;
        public static ushort OcrAEnable = 680;
        public static ushort OcrBEnable = 681;
        public static ushort Micre13BEnable = 682;
        public static ushort UsCurrencyEnable = 683;
        public static ushort OcrAVariant = 684;
        public static ushort OcrBVariant = 685;
        public static ushort ValidCharacters = 686;
        public static ushort Orientation = 687;
        public static ushort CheckDigitMod = 688;
        public static ushort MinCharacters = 689;
        public static ushort MaxCharacters = 690;
        public static ushort Lines = 691;
        public static ushort CheckDigitValidation = 694;
        public static ushort QuietZone = 695;
        public static ushort WhiteLevel = 696;
        public static ushort Despeckle = 697;
        public static ushort Thicken = 698;
        public static ushort LowPassFilter = 699;
        public static ushort CheckDigitMultiplier = 700;
        public static ushort EnableIllumination = 701;
        public static ushort EnableFinder = 702;
        public static ushort EnableExternalFinder = 707;
        public static IEnumerable<ushort> All = new ushort[]
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
