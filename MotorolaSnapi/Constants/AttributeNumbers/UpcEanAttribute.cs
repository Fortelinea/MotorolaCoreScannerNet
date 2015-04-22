/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal enum UpcEanAttribute : ushort
    {
        UpcA = 1,
        UpcE = 2,
        UpcE1 = 12,
        Ean8Jan8 = 4,
        Ean13Jan13 = 3,
        BooklandEan = 83,
        UpcEanJanSupplementals = 16,
        UpcEanJanSupplementalRedundancy = 80,
        TransmitUpcACheckDigit = 40,
        TransmitUpcECheckDigit = 41,
        TransmitUpcE1CheckDigit = 42,
        UpcAPreamble = 34,
        UpcEPreamble = 35,
        UpcE1Preamble = 36,
        ConvertUpcEtoA = 37,
        ConvertUpce1ToA = 38,
        Ean8Jan8Extend = 39,
        UccCouponExtendedCode = 85,
        TransmitCodeId = 45,
        Supp2 = 207,
        Supp5 = 208,
    }
}
