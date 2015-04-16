using System.ComponentModel;

namespace Motorola.Snapi.Constants
{
    public enum BarcodeType : ushort
    {
        NotSupported = 0,
        [Description("Code 39")]
        Code39 = 1,
        [Description("Codabar")]
        Codabar = 2,
        [Description("Code 128")]
        Code128 = 3,
        [Description("Discrete (Standard) 2 of 5")]
        Discrete2Of5 = 4,
        [Description("IATA")]
        IATA = 5,
        [Description("Interleaved 2 of 5")]
        Interleaved2Of5 = 6,
        [Description("Code 93")]
        Code93 = 7,
        [Description("UPC-A")]
        UPCA = 8,
        [Description("UPC-E0")]
        UPCE0 = 9,
        [Description("EAN-8")]
        EAN8 = 10,
        [Description("EAN-13")]
        EAN13 = 11,
        [Description("Code 11")]
        Code11 = 12,
        [Description("Code 49")]
        Code49 = 13,
        [Description("MSI")]
        MSI = 14,
        [Description("EAN-128")]
        EAN128 = 15,
        [Description("UPC-E1")]
        UPCE1 = 16,
        [Description("PDF-417")]
        PDF417 = 17,
        [Description("Code 16K")]
        Code16K = 18,
        [Description("Code 39 Full ASCII")]
        Code39FullASCII = 19,
        [Description("UPC-D")]
        UPCD = 20,
        [Description("Code 39 Trioptic")]
        Code39Trioptic = 21,
        [Description("Bookland")]
        Bookland = 22,
        [Description("Coupon Code")]
        CouponCode = 23,
        [Description("NW-7")]
        NW7 = 24,
        [Description("ISBT-128")]
        ISBT128 = 25,
        [Description("Micro PDF")]
        MicroPDF = 26,
        [Description("DataMatrix")]
        DataMatrix = 27,
        [Description("QR Code")]
        QRCode = 28,
        [Description("Micro PDF CCA")]
        MicroPDFCCA = 29,
        [Description("PostNet US")]
        PostNetUS = 30,
        [Description("Planet Code")]
        PlanetCode = 31,
        [Description("Code 32")]
        Code32 = 32,
        [Description("ISBT-128 Con")]
        ISBT128Con = 33,
        [Description("Japan Postal")]
        JapanPostal = 34,
        [Description("Australian Postal")]
        AustralianPostal = 35,
        [Description("Dutch Postal")]
        DutchPostal = 36,
        [Description("MaxiCode")]
        MaxiCode = 37,
        [Description("Canadian Postal")]
        CanadianPostal = 38,
        [Description("UK Postal")]
        UKPostal = 39,
        [Description("Macro PDF")]
        MacroPDF = 40,
        [Description("Micro QR code")]
        MicroQRcode = 44,
        [Description("Aztec")]
        Aztec = 45,
        [Description("GS1 Databar (RSS-14)")]
        GS1Databar = 48,
        [Description("RSS Limited")]
        RSSLimited = 49,
        [Description("GS1 Databar Expanded (RSS Expanded)")]
        GS1DatabarExpanded = 50,
        [Description("Scanlet")]
        Scanlet = 55,
        [Description("UPC-A + 2 Supplemental")]
        UPCA_2 = 72,
        [Description("UPC-E0 + 2 Supplemental")]
        UPCEO_2 = 73,
        [Description("EAN-8 + 2 Supplemental")]
        EAN8_2 = 74,
        [Description("EAN-13 + 2 Supplemental")]
        EAN13_2 = 75,
        [Description("UPC-E1 + 2 Supplemental")]
        UPCE1_2 = 80,
        [Description("CCA EAN-128")]
        CCA_EAN128 = 81,
        [Description("CCA EAN-13")]
        CCA_EAN13 = 82,
        [Description("CCA EAN-8")]
        CCA_EAN8 = 83,
        [Description("CCA RSS Expanded")]
        CCA_RSSExpanded = 84,
        [Description("CCA RSS Limited")]
        CCA_RSSLimited = 85,
        [Description("CCA RSS-14")]
        CCA_RSS14 = 86,
        [Description("CCA UPC-A")]
        CCA_UPCA = 87,
        [Description("CCA UPC-E")]
        CCA_UPCE = 88,
        [Description("CCC EAN-128")]
        CCC_EAN128 = 89,
        [Description("TLC-39")]
        TLC39 = 90,
        [Description("CCB EAN-128")]
        CCB_EAN128 = 97,
        [Description("CCB EAN-13")]
        CCB_EAN13 = 98,
        [Description("CCB EAN-8")]
        CCB_EAN8 = 99,
        [Description("CCB RSS Expanded")]
        CCB_RSSExpanded = 100,
        [Description("CCB RSS Limited")]
        CCB_RSSLimited = 101,
        [Description("CCB RSS-14")]
        CCB_RSS14 = 102,
        [Description("CCB UPC-A")]
        CCB_UPCA = 103,
        [Description("CCB UPC-E")]
        CCB_UPCE = 104,
        [Description("Signature Capture")]
        SignatureCapture = 105,
        [Description("Matrix 2 of 5")]
        Matrix2Of5 = 113,
        [Description("Chinese 2 of 5")]
        Chinese2Of5 = 114,
        [Description("UPC-A + 5 Supplemental")]
        UPCA_5 = 136,
        [Description("UPC-E0 + 5 Supplemental")]
        UPCEO_5 = 137,
        [Description("EAN-8 + 5 Supplemental")]
        EAN8_5 = 138,
        [Description("EAN-13 + 5 Supplemental")]
        EAN13_5 = 139,
        [Description("UPC-E1 + 5 Supplemental")]
        UPCE1_5 = 144,
        [Description("Macro Micro PDF")]
        MacroMicroPDF = 154
    }
}
