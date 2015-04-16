using System;
using CoreScanner;
using Motorola.Snapi.Constants;

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
        /// <para>Description: OCR module check calculation.</para>
        /// <para>Values: 1..99</para>
        /// </summary>
        public ushort CheckDigitMod
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.CheckDigitMod)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute {Id = OcrAttribute.CheckDigitMod, DataType = ValueConverters.TypeToDataType(typeof(ushort)), Value = value});
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRCheckDigitMulti</para>
        /// <para>Description: OCR check digit multiplier string.</para>
        /// <para>Values: 1212121212</para>
        /// </summary>
        public string CheckDigitMultiplier
        {
            get
            {
                return (string)GetAttribute(OcrAttribute.CheckDigitMultiplier)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute {Id = OcrAttribute.CheckDigitMultiplier, DataType = ValueConverters.TypeToDataType(typeof(string)), Value = value});
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRCheckDigitValid</para>
        /// <para>Description: Set one of OCR check digit validations.</para>
        /// <para>Values: 0..9</para>
        /// </summary>
        public ushort CheckDigitValidation
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.CheckDigitValidation)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute{Id = OcrAttribute.CheckDigitValidation, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value});
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRDespeckle</para>
        /// <para>Description: OCR Despeckle Level.</para>
        /// <para>Values: 0..99</para>
        /// </summary>
        public ushort Despeckle
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.Despeckle)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Despeckle, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRFinderExternal</para>
        /// <para>Description: Enabled external OCR finder.</para>
        /// <para>Values: "Enable"(true) "Disable"(false)</para>
        /// </summary>
        public bool EnableExternalFinder
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.EnableExternalFinder)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.EnableExternalFinder, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRFinderEnable</para>
        /// <para>Description: Enables OCR finder.</para>
        /// <para>Values: "Enable"(true) "Disable"(false)</para>
        /// </summary>
        public bool EnableFinder
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.EnableFinder)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.EnableFinder, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBrightIllum</para>
        /// <para>Description: Enable brightness for long OCR strings.</para>
        /// <para>Values: "Enable"(true) "Disable"(false)</para>
        /// </summary>
        public bool EnableIllumination
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.EnableIllumination)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.EnableIllumination, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: MICRE13BEnable</para>
        /// <para>Description: Enable/Disable MICR E13B.</para>
        /// <para>Values: "Enable"(true) "Disable"(false)</para>
        /// </summary>
        public bool EnableMicre13B
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.Micre13BEnable)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Micre13BEnable, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRAEnable</para>
        /// <para>Description: OCR-A Enable/Disable.</para>
        /// <para>Values: "Enable"(true) "Disable"(false)</para>
        /// </summary>
        public bool EnableOcrA
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.OcrAEnable)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrAEnable, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBEnable</para>
        /// <para>Description: OCR-B Enable/Disable.</para>
        /// <para>Values: "Enable"(true) "Disable"(false)</para>
        /// </summary>
        public bool EnableOcrB
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.OcrBEnable)
                               .Value; 
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrBEnable, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: USCurrencyEnable</para>
        /// <para>Description: Enable/Disable US Currency Serial Number.</para>
        /// <para>Values: "Enable"(true) "Disable"(false)</para>
        /// </summary>
        public bool EnableUSCurrency
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.UsCurrencyEnable)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.UsCurrencyEnable, DataType = ValueConverters.TypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRLines</para>
        /// <para>Description: Set number of lines of OCR to be read.</para>
        /// <para>Values: 1, 2, 3</para>
        /// </summary>
        public ushort Lines
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.Lines)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Lines, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRLowPassFilter</para>
        /// <para>Description: OCR Low Pass Filter.</para>
        /// <para>Values: 0..20</para>
        /// </summary>
        public ushort LowPassFilter
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.LowPassFilter)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.LowPassFilter, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRMaxChar</para>
        /// <para>Description: Set maximum number of OCR characters per line to decode.</para>
        /// <para>Values: 3..100</para>
        /// </summary>
        public ushort MaxCharacters
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.MaxCharacters)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.MaxCharacters, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRMinChar</para>
        /// <para>Description: Set minimum number of OCR characters per line to decode.</para>
        /// <para>Values: 3..100</para>
        /// </summary>
        public ushort MinCharacters
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.MinCharacters)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.MinCharacters, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRAVariant</para>
        /// <para>Description: Set one of OCR-A variants.</para>
        /// <para>Values: 0, 1, 2, 3</para>
        /// </summary>
        public ushort OcrAVariant
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.OcrAVariant)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrAVariant, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBVariant</para>
        /// <para>Description: Set one of OCR-B variants.</para>
        /// <para>Values: 0..10</para>
        /// </summary>
        public ushort OcrBVariant
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.OcrBVariant)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrBVariant, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCROrientation</para>
        /// <para>Description: Set the orientation of an OCR string to be read to the camera.</para>
        /// <para>Values: 0, 1, 2, 3</para>
        /// </summary>
        public BarcodeOrientation Orientation
        {
            get
            {
                return (BarcodeOrientation)GetAttribute(OcrAttribute.Orientation)
                               .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Orientation, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = (int)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRQuietZone</para>
        /// <para>Description: Set OCR quiet zone.</para>
        /// <para>Values: 20..99</para>
        /// </summary>
        public ushort QuietZone
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.QuietZone)
                                            .Value);
            }
            set
            {
                 SetAttribute(new ScannerAttribute { Id = OcrAttribute.QuietZone, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRSecurityLevel</para>
        /// <para>Description: OCR security / confidence level.</para>
        /// <para>Values: 10..99</para>
        /// </summary>
        public ushort SecurityLevel
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.SecurityLevel)
                          .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.SecurityLevel, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRTemplate1</para>
        /// <para>Description:Set OCR template that matches an OCR string to be read.</para>
        /// <para>Values: Variable</para>
        /// </summary>
        public string Template
        {
            get
            {
                return (string)GetAttribute(OcrAttribute.Template)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Template, DataType = ValueConverters.TypeToDataType(typeof(string)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRThicken</para>
        /// <para>Description: OCR Thickening.</para>
        /// <para>Values: 0..16</para>
        /// </summary>
        public ushort Thicken
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.Thicken)
                          .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Thicken, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRSubset</para>
        /// <para>Description: Set OCR character subset for an OCR string to be read.</para>
        /// <para>Values: 0000000000000000000000000000000000000000000000000000000000000000</para>
        /// </summary>
        public string ValidCharacters
        {
            get
            {
                return (string)GetAttribute(OcrAttribute.ValidCharacters)
                                   .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.ValidCharacters, DataType = ValueConverters.TypeToDataType(typeof(string)), Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OCRBWLevel</para>
        /// <para>Description: Sets OCR White Level.</para>
        /// <para>Values: 0..99</para>
        /// </summary>
        public ushort WhiteLevel
        {
            get
            {
                return Convert.ToUInt16(GetAttribute(OcrAttribute.WhiteLevel)
                                            .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.WhiteLevel, DataType = ValueConverters.TypeToDataType(typeof(byte)), Value = value });
            }
        }
    }
}