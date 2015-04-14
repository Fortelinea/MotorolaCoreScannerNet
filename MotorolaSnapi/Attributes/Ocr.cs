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
        /// Driver Attribute Name: OCRCheckDigitMod
        /// Description: OCR module check calculation.
        /// Values: 1..99
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
                SetAttribute(new ScannerAttribute {Id = OcrAttribute.CheckDigitMod, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value});
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRCheckDigitMulti
        /// Description: OCR check digit multiplier string.
        /// Values: 1212121212
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
                SetAttribute(new ScannerAttribute {Id = OcrAttribute.CheckDigitMultiplier, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value});
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRCheckDigitValid
        /// Description: Set one of OCR check digit validations.
        /// Values: 0..9
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
                SetAttribute(new ScannerAttribute{Id = OcrAttribute.CheckDigitValidation, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value});
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRDespeckle
        /// Description: OCR Despeckle Level.
        /// Values: 0..99
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Despeckle, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRFinderExternal
        /// Description: Enabled external OCR finder.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableExternalFinder
        {
            get
            {
                return (bool)GetAttribute(OcrAttribute.CheckDigitMultiplier)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.CheckDigitMultiplier, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRFinderEnable
        /// Description: Enables OCR finder.
        /// Values: "Enable"(1) "Disable"(0)
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.EnableFinder, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBrightIllum
        /// Description: Enable brightness for long OCR strings.
        /// Values: "Enable"(1) "Disable"(0)
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.EnableIllumination, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: MICRE13BEnable
        /// Description: Enable/Disable MICR E13B.
        /// Values: "Enable"(1) "Disable"(0)
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Micre13BEnable, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRAEnable
        /// Description: OCR-A Enable/Disable.
        /// Values: "Enable"(1) "Disable"(0)
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrAEnable, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBEnable
        /// Description: OCR-B Enable/Disable.
        /// Values: "Enable"(1) "Disable"(0)
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrBEnable, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: USCurrencyEnable
        /// Description: Enable/Disable US Currency Serial Number.
        /// Values: "Enable"(1) "Disable"(0)
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.UsCurrencyEnable, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRLines
        /// Description: Set number of lines of OCR to be read.
        /// Values: 1, 2, 3
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Lines, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRLowPassFilter
        /// Description: OCR Low Pass Filter.
        /// Values: 0..20
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.LowPassFilter, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRMaxChar
        /// Description: Set maximum number of OCR characters per line to decode.
        /// Values: 3..100
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.MaxCharacters, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRMinChar
        /// Description: Set minimum number of OCR characters per line to decode.
        /// Values: 3..100
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.MinCharacters, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRAVariant
        /// Description: Set one of OCR-A variants.
        /// Values: 0, 1, 2, 3
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrAVariant, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBVariant
        /// Description: Set one of OCR-B variants.
        /// Values: 0..10
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.OcrBVariant, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCROrientation
        /// Description: Set the orientation of an OCR string to be read to the camera.
        /// Values: 0, 1, 2, 3
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Orientation, DataType = ValueConverters.ActualTypeToDataType(typeof(byte)), Value = (int)value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRQuietZone
        /// Description: Set OCR quiet zone.
        /// Values: 20..99
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
                 SetAttribute(new ScannerAttribute { Id = OcrAttribute.QuietZone, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRSecurityLevel
        /// Description: OCR security / confidence level.
        /// Values: 10..99
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.SecurityLevel, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRTemplate1
        /// Description:Set OCR template that matches an OCR string to be read.
        /// Values: Variable
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Template, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRThicken
        /// Description: OCR Thickening.
        /// Values: 0..16
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.Thicken, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRSubset
        /// Description: Set OCR character subset for an OCR string to be read.
        /// Values: 0000000000000000000000000000000000000000000000000000000000000000
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.ValidCharacters, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBWLevel
        /// Description: Sets OCR White Level.
        /// Values: 0..99
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
                SetAttribute(new ScannerAttribute { Id = OcrAttribute.WhiteLevel, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }
    }
}