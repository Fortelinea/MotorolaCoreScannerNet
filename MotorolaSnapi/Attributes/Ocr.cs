using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying scanner OCR attributes.
    /// </summary>
    public class Ocr : MotorolaAttributeSet
    {
        /// <summary>
        /// Initializes an Ocr object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Ocr(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: OCRCheckDigitMod</para>
        /// <para>OCR module check calculation.</para>
        /// <remarks><para>Values: 1..99</para>
        /// </summary>
        public ushort CheckDigitMod
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.CheckDigitMod)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute {Id = (ushort)OcrAttribute.CheckDigitMod, DataType = DataType.UShort, Value = value});
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRCheckDigitMulti</para>
        /// <para>OCR check digit multiplier string.</para>
        /// <remarks><para>Values: 1212121212</para>
        /// </summary>
        public string CheckDigitMultiplier
        {
            get
            {
                return (string)GetAttribute((ushort)OcrAttribute.CheckDigitMultiplier)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute {Id = (ushort)OcrAttribute.CheckDigitMultiplier, DataType = DataType.String, Value = value});
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRCheckDigitValid</para>
        /// <para>Set one of OCR check digit validations.</para>
        /// <remarks><para>Values: 0..9</para></remarks>
        /// </summary>
        public ushort CheckDigitValidation
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.CheckDigitValidation)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute{Id = (ushort)OcrAttribute.CheckDigitValidation, DataType = DataType.Byte, Value = value});
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRDespeckle</para>
        /// <para>OCR Despeckle Level.</para>
        /// <remarks><para>Values: 0..99</para></remarks>
        /// </summary>
        public ushort Despeckle
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.Despeckle)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.Despeckle, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRFinderExternal</para>
        /// <para>Enabled external OCR finder.</para>
        /// <remarks><para>Values: "Enable"(true) "Disable"(false)</para></remarks>
        /// </summary>
        public bool EnableExternalFinder
        {
            get
            {
                return (bool)GetAttribute((ushort)OcrAttribute.EnableExternalFinder)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.EnableExternalFinder, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRFinderEnable</para>
        /// <para>Enables OCR finder.</para>
        /// <remarks><para>Values: "Enable"(true) "Disable"(false)</para></remarks>
        /// </summary>
        public bool EnableFinder
        {
            get
            {
                return (bool)GetAttribute((ushort)OcrAttribute.EnableFinder)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.EnableFinder, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBrightIllum</para>
        /// <para>Enable brightness for long OCR strings.</para>
        /// <remarks><para>Values: "Enable"(true) "Disable"(false)</para></remarks>
        /// </summary>
        public bool EnableIllumination
        {
            get
            {
                return (bool)GetAttribute((ushort)OcrAttribute.EnableIllumination)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.EnableIllumination, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: MICRE13BEnable</para>
        /// <para>Enable/Disable MICR E13B.</para>
        /// <remarks><para>Values: "Enable"(true) "Disable"(false)</para></remarks>
        /// </summary>
        public bool EnableMicre13B
        {
            get
            {
                return (bool)GetAttribute((ushort)OcrAttribute.Micre13BEnable)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.Micre13BEnable, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRAEnable</para>
        /// <para>OCR-A Enable/Disable.</para>
        /// <remarks><para>Values: "Enable"(true) "Disable"(false)</para></remarks>
        /// </summary>
        public bool EnableOcrA
        {
            get
            {
                return (bool)GetAttribute((ushort)OcrAttribute.OcrAEnable)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.OcrAEnable, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBEnable</para>
        /// <para>OCR-B Enable/Disable.</para>
        /// <remarks><para>Values: "Enable"(true) "Disable"(false)</para></remarks>
        /// </summary>
        public bool EnableOcrB
        {
            get
            {
                return (bool)GetAttribute((ushort)OcrAttribute.OcrBEnable)
                               .Value; 
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.OcrBEnable, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: USCurrencyEnable</para>
        /// <para>Enable/Disable US Currency Serial Number.</para>
        /// <remarks><para>Values: "Enable"(true) "Disable"(false)</para></remarks>
        /// </summary>
        public bool EnableUSCurrency
        {
            get
            {
                return (bool)GetAttribute((ushort)OcrAttribute.UsCurrencyEnable)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.UsCurrencyEnable, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRLines</para>
        /// <para>Set number of lines of OCR to be read.</para>
        /// <remarks><para>Values: 1, 2, 3</para></remarks>
        /// </summary>
        public ushort Lines
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.Lines)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.Lines, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRLowPassFilter</para>
        /// <para>OCR Low Pass Filter.</para>
        /// <remarks><para>Values: 0..20</para></remarks>
        /// </summary>
        public ushort LowPassFilter
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.LowPassFilter)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.LowPassFilter, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRMaxChar</para>
        /// <para>Set maximum number of OCR characters per line to decode.</para>
        /// <remarks><para>Values: 3..100</para></remarks>
        /// </summary>
        public ushort MaxCharacters
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.MaxCharacters)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.MaxCharacters, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRMinChar</para>
        /// <para>Set minimum number of OCR characters per line to decode.</para>
        /// <remarks><para>Values: 3..100</para></remarks>
        /// </summary>
        public ushort MinCharacters
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.MinCharacters)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.MinCharacters, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRAVariant</para>
        /// <para>Set one of OCR-A variants.</para>
        /// <remarks><para>Values: 0, 1, 2, 3</para></remarks>
        /// </summary>
        public ushort OcrAVariant
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.OcrAVariant)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.OcrAVariant, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBVariant</para>
        /// <para>Set one of OCR-B variants.</para>
        /// <remarks><para>Values: 0..10</para></remarks>
        /// </summary>
        public ushort OcrBVariant
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.OcrBVariant)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.OcrBVariant, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCROrientation</para>
        /// <para>Set the orientation of an OCR string to be read to the camera.</para>
        /// <remarks><para>Values: 0, 1, 2, 3</para></remarks>
        /// </summary>
        public BarcodeOrientation Orientation
        {
            get
            {
                return (BarcodeOrientation)GetAttribute((ushort)OcrAttribute.Orientation)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.Orientation, DataType = DataType.Byte, Value = (int)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRQuietZone</para>
        /// <para>Set OCR quiet zone.</para>
        /// <remarks><para>Values: 20..99</para></remarks>
        /// </summary>
        public ushort QuietZone
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.QuietZone)
                                            .Value);
            }
            set
            {
                 SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.QuietZone, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRSecurityLevel</para>
        /// <para>OCR security / confidence level.</para>
        /// <remarks><para>Values: 10..99</para></remarks>
        /// </summary>
        public ushort SecurityLevel
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.SecurityLevel)
                          .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.SecurityLevel, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRTemplate1</para>
        /// <para>Description:Set OCR template that matches an OCR string to be read.</para>
        /// <remarks><para>"9" (Required digit), "A" (Required alpha), "1" (Optional Alphanumberic), "2" (Optional Alpha), "3" (Alpha or digit),
        ///  "4" (Any including space & reject), "5" (Any except space & reject), "7" (optional digit), "8" (digit or fill), "F" (alpha or fill),
        /// " " (optional space), "." (optional small special), "E" (new line), "C" (string extract "CbPe" b = begin, P = category, e = end),
        ///  """ or "+" delimit literal strings, "D" (End of Field), </para></remarks>
        /// </summary>
        public string Template
        {
            get
            {
                return (string)GetAttribute((ushort)OcrAttribute.Template)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.Template, DataType = DataType.String, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRThicken</para>
        /// <para>OCR Thickening.</para>
        /// <remarks><para>Values: 0..16</para></remarks>
        /// </summary>
        public ushort Thicken
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.Thicken)
                          .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.Thicken, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRSubset</para>
        /// <para>Set OCR character subset for an OCR string to be read.</para>
        /// <remarks><para>Values: ABCD1234 etc.</para></remarks>
        /// </summary>
        public string ValidCharacters
        {
            get
            {
                return (string)GetAttribute((ushort)OcrAttribute.ValidCharacters)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.ValidCharacters, DataType = DataType.String, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBWLevel</para>
        /// <para>Sets OCR White Level.</para>
        /// <remarks><para>Values: 0..99</para></remarks>
        /// </summary>
        public ushort WhiteLevel
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)OcrAttribute.WhiteLevel)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)OcrAttribute.WhiteLevel, DataType = DataType.Byte, Value = value });
            }
        }
    }
}