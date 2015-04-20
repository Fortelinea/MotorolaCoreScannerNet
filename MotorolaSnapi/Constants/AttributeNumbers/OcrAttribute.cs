using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class OcrAttribute
    {
        internal const ushort Template = 547;
        internal const ushort SecurityLevel = 554;
        internal const ushort OcrAEnable = 680;
        internal const ushort OcrBEnable = 681;
        internal const ushort Micre13BEnable = 682;
        internal const ushort UsCurrencyEnable = 683;
        internal const ushort OcrAVariant = 684;
        internal const ushort OcrBVariant = 685;
        internal const ushort ValidCharacters = 686;
        internal const ushort Orientation = 687;
        internal const ushort CheckDigitMod = 688;
        internal const ushort MinCharacters = 689;
        internal const ushort MaxCharacters = 690;
        internal const ushort Lines = 691;
        internal const ushort CheckDigitValidation = 694;
        internal const ushort QuietZone = 695;
        internal const ushort WhiteLevel = 696;
        internal const ushort Despeckle = 697;
        internal const ushort Thicken = 698;
        internal const ushort LowPassFilter = 699;
        internal const ushort CheckDigitMultiplier = 700;
        internal const ushort EnableIllumination = 701;
        internal const ushort EnableFinder = 702;
        internal const ushort EnableExternalFinder = 707;
        internal static readonly IEnumerable<ushort> All = new []
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
