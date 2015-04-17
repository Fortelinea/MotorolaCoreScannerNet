using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying UPC and EAN barcode attributes.
    /// </summary>
    public class UpcEan : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a UpcEan object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal UpcEan(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver){}

        /// <summary>
        /// <para>Driver Attribute Name: UPC-A</para>
        /// <para>Description: This parameter enables the decoding of UPC-A.</para>
        /// </summary>
        public bool UpcAEnabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.UPC_A).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UPC_A, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UPC-E</para>
        /// <para>Description: This parameter enables the decoding of UPC-E.</para>
        /// </summary>
        public bool UpcEEnabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.UPC_E).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UPC_E, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UPC-E1</para>
        /// <para>Description: This parameter enables the decoding of UPC-E1.</para>
        /// </summary>
        public bool UpcE1Enabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.UPC_E1).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UPC_E1, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: EAN-8/JAN8</para>
        /// <para>Description: This parameter enables the decoding of EAN-8/JAN 8.</para>
        /// </summary>
        public bool Ean8Jan8Enabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.EAN_8_JAN8).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.EAN_8_JAN8, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: EAN-13/JAN13</para>
        /// <para>Description: This parameter enables the decoding of EAN-13/JAN 13.</para>
        /// </summary>
        public bool Ean13Jan13Enabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.EAN_13_JAN13).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.EAN_13_JAN13, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: BooklandEAN</para>
        /// <para>Description: This parameter enables the decoding of BooklandEAN.</para>
        /// </summary>
        public bool BooklandEanEnabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.BooklandEAN).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.BooklandEAN, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UPC/EAN/JANSupplementals</para>
        /// <para>Description: Decode Supplemental (2 and 5 digits). Supplementals are bar codes appended according to
        /// specific format conventions (e.g., UPC A+2, UPC E+2, EAN13+2).
        /// Six options are available.</para>
        /// </summary>
        public SupplementalMode UpcEanJanSupplementalMode
        {
            get
            {
                return (SupplementalMode)GetAttribute(UpcEanAttribute.UPC_EAN_JANSupplementals).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.BooklandEAN, DataType = DataType.Byte, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UPC/EAN/JANSupplementalsRedundancy</para>
        /// <para>Description: With Auto discriminate UPC/EAN/JAN Supplemental selected, this parameter adjusts
        /// the number of times a symbol without Supplemental is decoded before transmission. The range is from two to thirty
        /// times. Five or above is recommended when decoding a mix of UPC/EAN symbols with and without supplemental,
        /// and the auto discriminate option is selected</para>
        /// <remarks>Values: 2 to 30</remarks>
        /// </summary>
        public ushort UpcEanJanSupplementalRedundancy
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(UpcEanAttribute.UPC_EAN_JANSupplementalRedundancy).Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UPC_EAN_JANSupplementalRedundancy, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: TransmitUPC-ACheckDigit</para>
        /// <para>Description: This parameter enables transmission of UPC-A bar code data with a check digit.</para>
        /// </summary>
        public bool TransmitUpcACheckDigit
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.TransmitUPC_ACheckDigit).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.TransmitUPC_ACheckDigit, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: TransmitUPC-ECheckDigit</para>
        /// <para>Description: This parameter enables transmission of bar UPC-E code data with a check digit.</para>
        /// </summary>
        public bool TransmitUpcECheckDigit
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.TransmitUPC_ECheckDigit).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.TransmitUPC_ECheckDigit, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: TransmitUPC-E1CheckDigit</para>
        /// <para>Description: This parameter enables transmission of bar UPC-E1 code data with a check digit.</para>
        /// </summary>
        public bool TransmitUpcE1CheckDigit
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.TransmitUPC_E1CheckDigit).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.TransmitUPC_E1CheckDigit, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UPCAPreamble</para>
        /// <para>Description: Preamble characters are part of the UPC-A symbol consisting of Country Code and System Character.</para>
        /// <remarks>"No Preamble"(0), "System Character"(1), "System Character & Country Code"(2)</remarks>
        /// </summary>
        public UpcPreamble UpcAPreamble
        {
            get
            {
                return (UpcPreamble)GetAttribute(UpcEanAttribute.UPCAPreamble).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UPCAPreamble, DataType = DataType.Byte, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UPCEPreamble</para>
        /// <para>Description: Preamble characters are part of the UPC-E symbol consisting of Country Code and System Character.</para>
        /// <remarks>"No Preamble"(0), "System Character"(1), "System Character & Country Code"(2)</remarks>
        /// </summary>
        public UpcPreamble UpcEPreamble
        {
            get
            {
                return (UpcPreamble)GetAttribute(UpcEanAttribute.UPCEPreamble).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UPCEPreamble, DataType = DataType.Byte, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UPCE1Preamble</para>
        /// <para>Description: Preamble characters are part of the UPC-E1 symbol consisting of Country Code and System Character.</para>
        /// <remarks>"No Preamble"(0), "System Character"(1), "System Character & Country Code"(2)</remarks>
        /// </summary>
        public UpcPreamble UpcE1Preamble
        {
            get
            {
                return (UpcPreamble)GetAttribute(UpcEanAttribute.UPCE1Preamble).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UPCE1Preamble, DataType = DataType.Byte, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ConvertUPCEtoA</para>
        /// <para>Description: Enable this parameter to convert UPC-E (zero suppressed) decoded data to UPC-A format before transmission. After conversion,
        /// the data follows UPC-A format and is affected by UPC-A programming selections (e.g., Preamble, Check Digit).</para>
        /// </summary>
        public bool ConvertUpcEtoA
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.ConvertUPCEtoA).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.ConvertUPCEtoA, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ConvertUpcE1toA</para>
        /// <para>Description: Enable this parameter to convert UPC-E1 decoded data to UPC-A format before transmission. After conversion,
        /// the data follows UPC-A format and is affected by UPC-A programming selections (e.g., Preamble, Check Digit).</para>
        /// </summary>
        public bool ConvertUpcE1toA
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.ConvertUPCE1toA).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.ConvertUPCE1toA, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: EAN8/JAN8Extend</para>
        /// <para>Description: When enabled, this parameter adds five leading zeros to decoded EAN-8 symbols to
        /// make them compatible in format to EAN-13 symbols.</para>
        /// </summary>
        public bool Ean8Jan8Extend
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.EAN8_JAN8Extend).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.EAN8_JAN8Extend, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UCCCouponExtendedCode</para>
        /// <para>Description: When enabled, this parameter decodes UPCA bar codes starting with digit ‘5’, EAN-13 bar codes starting with digit
        /// ‘99’, and UPCA/EAN-128 Coupon Codes. UPCA, EAN-13 and EAN-128 must be enabled to scan all types of Coupon Codes.</para>
        /// </summary>
        public bool UccCouponExtendedCodeEnabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.UCCCouponExtendedCode).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.UCCCouponExtendedCode, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: TransmitCodeId</para>
        /// <remarks><para>"None"(00), "AIM Code ID"(01), "Symbol Code ID"(02)</para></remarks>
        /// </summary>
        public TransmitCodeId TransmitCodeId
        {
            get
            {
                return (TransmitCodeId)GetAttribute(UpcEanAttribute.TransmitCodeId).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.TransmitCodeId, DataType = DataType.Byte, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Supp2</para>
        /// <para>Enables Supp2 UPC decoding.</para>
        /// </summary>
        public bool Supp2Enabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.Supp2).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.Supp2, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Supp5</para>
        /// <para>Enables Supp5 UPC decoding.</para>
        /// </summary>
        public bool Supp5Enabled
        {
            get
            {
                return (bool)GetAttribute(UpcEanAttribute.Supp5).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = UpcEanAttribute.Supp5, DataType = DataType.Bool, Value = value });
            }
        }
    }
}
