using System;
using CoreScanner;
using System.Collections.Generic;
using System.Linq;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Handles all OCR barcode attributes.
    /// </summary>
    public class Ocr : MotorolaAttributeSet
    {
        private ushort _checkDigitMod;
        private string _checkDigitMultiplier;
        private ushort _despeckle;
        private bool _enableExternalFinder;
        private bool _enableFinder;
        private bool _enableUsCurrency;
        private bool _isIlluminationEnabled;
        private bool _isMicre13BEnabled;
        private bool _isOcrAEnabled;
        private bool _isOcrBEnabled;
        private ushort _lines;
        private ushort _lowPassFilter;
        private ushort _maxCharacters;
        private ushort _minCharacters;
        private ushort _ocrAVariant;
        private ushort _ocrBVariant;
        private BarcodeOrientation _orientation;
        private ushort _quietZone;
        private ushort _securityLevel;
        private string _template;
        private ushort _thicken;
        private string _validCharacters;
        private ushort _whiteLevel;

        internal Ocr(int scannerId, ICoreScanner scannerDriver)
            : base(scannerId, scannerDriver)
        {
            var attr = new List<ushort>();
            attr.AddRange(Enum.GetValues(typeof(OcrAttribute)).Cast<ushort>());
            var attributes = GetAttributes(attr);
            _isOcrBEnabled = (bool)attributes[OcrAttribute.OcrBEnable].Value;
            _isOcrAEnabled = (bool)attributes[OcrAttribute.OcrAEnable].Value;
            _checkDigitMod = Convert.ToUInt16(attributes[OcrAttribute.CheckDigitMod].Value);
            _checkDigitMultiplier = (string)attributes[OcrAttribute.CheckDigitMultiplier].Value;
            _despeckle = Convert.ToUInt16(attributes[OcrAttribute.Despeckle].Value);
            _enableExternalFinder = (bool)attributes[OcrAttribute.EnableExternalFinder].Value;
            _enableFinder = (bool)attributes[OcrAttribute.EnableFinder].Value;
            _enableUsCurrency = (bool)attributes[OcrAttribute.UsCurrencyEnable].Value;
            _isIlluminationEnabled = (bool)attributes[OcrAttribute.EnableIllumination].Value;
            _isMicre13BEnabled = (bool)attributes[OcrAttribute.Micre13BEnable].Value;
            _lines = Convert.ToUInt16(attributes[OcrAttribute.Lines].Value);
            _lowPassFilter = Convert.ToUInt16(attributes[OcrAttribute.LowPassFilter].Value);
            _maxCharacters = Convert.ToUInt16(attributes[OcrAttribute.MaxCharacters].Value);
            _minCharacters = Convert.ToUInt16(attributes[OcrAttribute.MinCharacters].Value);
            _ocrAVariant = Convert.ToUInt16(attributes[OcrAttribute.OcrAVariant].Value);
            _ocrBVariant = Convert.ToUInt16(attributes[OcrAttribute.OcrBVariant].Value);
            _orientation = (BarcodeOrientation)attributes[OcrAttribute.Orientation].Value;
            _quietZone = Convert.ToUInt16(attributes[OcrAttribute.QuietZone].Value);
            _securityLevel = Convert.ToUInt16(attributes[OcrAttribute.SecurityLevel].Value);
            _template = (string)attributes[OcrAttribute.Template].Value;
            _thicken = Convert.ToUInt16(attributes[OcrAttribute.Thicken].Value);
            _validCharacters = (string)attributes[OcrAttribute.ValidCharacters].Value;
            _whiteLevel = Convert.ToUInt16(attributes[OcrAttribute.WhiteLevel].Value);
        }

        /// <summary>
        /// Driver Attribute Name: OCRCheckDigitMod
        /// Description: OCR module check calculation.
        /// Values: 1..99
        /// </summary>
        public ushort CheckDigitMod
        {
            get { return _checkDigitMod; }
            set
            {
                _checkDigitMod = value;

                SetAttribute(new ScannerAttribute {Id = 688, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value});
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRCheckDigitMulti
        /// Description: OCR check digit multiplier string.
        /// Values: 1212121212
        /// </summary>
        public string CheckDigitMultiplier
        {
            get { return _checkDigitMultiplier; }
            set
            {
                _checkDigitMultiplier = value;

                SetAttribute(new ScannerAttribute {Id = 700, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value});
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRCheckDigitValid
        /// Description: Set one of OCR check digit validations.
        /// Values: 0..9
        /// </summary>
        public ushort CheckDigitValidation
        {
            get { return _quietZone; }
            set
            {
                _quietZone = value;

                SetAttribute(new ScannerAttribute{Id = 694, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value});
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRDespeckle
        /// Description: OCR Despeckle Level.
        /// Values: 0..99
        /// </summary>
        public ushort Despeckle
        {
            get { return _despeckle; }
            set
            {
                _despeckle = value;

                SetAttribute(new ScannerAttribute { Id = 697, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRFinderExternal
        /// Description: Enabled external OCR finder.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableExternalFinder
        {
            get { return _enableExternalFinder; }
            set
            {
                _enableExternalFinder = value;

                SetAttribute(new ScannerAttribute { Id = 707, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRFinderEnable
        /// Description: Enables OCR finder.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableFinder
        {
            get { return _enableFinder; }
            set
            {
                _enableFinder = value;

                SetAttribute(new ScannerAttribute { Id = 702, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBrightIllum
        /// Description: Enable brightness for long OCR strings.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableIllumination
        {
            get { return _isIlluminationEnabled; }
            set
            {
                _isIlluminationEnabled = value;

                SetAttribute(new ScannerAttribute { Id = 701, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: MICRE13BEnable
        /// Description: Enable/Disable MICR E13B.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableMicre13B
        {
            get { return _isMicre13BEnabled; }
            set
            {
                _isMicre13BEnabled = value;

                SetAttribute(new ScannerAttribute { Id = 682, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRAEnable
        /// Description: OCR-A Enable/Disable.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableOcrA
        {
            get { return _isOcrAEnabled; }
            set
            {
                _isOcrAEnabled = value;

                SetAttribute(new ScannerAttribute { Id = 680, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBEnable
        /// Description: OCR-B Enable/Disable.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableOcrB
        {
            get { return _isOcrBEnabled; }
            set
            {
                _isOcrBEnabled = value;

                SetAttribute(new ScannerAttribute { Id = 681, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: USCurrencyEnable
        /// Description: Enable/Disable US Currency Serial Number.
        /// Values: "Enable"(1) "Disable"(0)
        /// </summary>
        public bool EnableUSCurrency
        {
            get { return _enableUsCurrency; }
            set
            {
                _enableUsCurrency = value;

                SetAttribute(new ScannerAttribute { Id = 683, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRLines
        /// Description: Set number of lines of OCR to be read.
        /// Values: 1, 2, 3
        /// </summary>
        public ushort Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;

                SetAttribute(new ScannerAttribute { Id = 691, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRLowPassFilter
        /// Description: OCR Low Pass Filter.
        /// Values: 0..20
        /// </summary>
        public ushort LowPassFilter
        {
            get { return _lowPassFilter; }
            set
            {
                _lowPassFilter = value;

                SetAttribute(new ScannerAttribute { Id = 699, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRMaxChar
        /// Description: Set maximum number of OCR characters per line to decode.
        /// Values: 3..100
        /// </summary>
        public ushort MaxCharacters
        {
            get { return _maxCharacters; }
            set
            {
                _maxCharacters = value;

                SetAttribute(new ScannerAttribute { Id = 690, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRMinChar
        /// Description: Set minimum number of OCR characters per line to decode.
        /// Values: 3..100
        /// </summary>
        public ushort MinCharacters
        {
            get { return _minCharacters; }
            set
            {
                _minCharacters = value;

                SetAttribute(new ScannerAttribute { Id = 689, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRAVariant
        /// Description: Set one of OCR-A variants.
        /// Values: 0, 1, 2, 3
        /// </summary>
        public ushort OcrAVariant
        {
            get { return _ocrAVariant; }
            set
            {
                _ocrAVariant = value;

                SetAttribute(new ScannerAttribute { Id = 684, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBVariant
        /// Description: Set one of OCR-B variants.
        /// Values: 0..10
        /// </summary>
        public ushort OcrBVariant
        {
            get { return _ocrBVariant; }
            set
            {
                _ocrBVariant = value;

                SetAttribute(new ScannerAttribute { Id = 685, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCROrientation
        /// Description: Set the orientation of an OCR string to be read to the camera.
        /// Values: 0, 1, 2, 3
        /// </summary>
        public BarcodeOrientation Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;

                SetAttribute(new ScannerAttribute { Id = 687, DataType = ValueConverters.ActualTypeToDataType(typeof(byte)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRQuietZone
        /// Description: Set OCR quiet zone.
        /// Values: 20..99
        /// </summary>
        public ushort QuietZone
        {
            get { return _quietZone; }
            set
            {
                _quietZone = value;

                SetAttribute(new ScannerAttribute { Id = 695, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRSecurityLevel
        /// Description: OCR security / confidence level.
        /// Values: 10..99
        /// </summary>
        public ushort SecurityLevel
        {
            get { return _securityLevel; }
            set
            {
                _securityLevel = value;

                SetAttribute(new ScannerAttribute { Id = 554, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRTemplate1
        /// Description:Set OCR template that matches an OCR string to be read.
        /// Values: Variable
        /// </summary>
        public string Template
        {
            get { return _template; }
            set
            {
                _template = value;

                SetAttribute(new ScannerAttribute { Id = 547, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRThicken
        /// Description: OCR Thickening.
        /// Values: 0..16
        /// </summary>
        public ushort Thicken
        {
            get { return _thicken; }
            set
            {
                _thicken = value;

                SetAttribute(new ScannerAttribute { Id = 698, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRSubset
        /// Description: Set OCR character subset for an OCR string to be read.
        /// Values: 0000000000000000000000000000000000000000000000000000000000000000
        /// </summary>
        public string ValidCharacters
        {
            get { return _validCharacters; }
            set
            {
                _validCharacters = value;

                SetAttribute(new ScannerAttribute { Id = 686, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: OCRBWLevel
        /// Description: Sets OCR White Level.
        /// Values: 0..99
        /// </summary>
        public ushort WhiteLevel
        {
            get { return _whiteLevel; }
            set
            {
                _whiteLevel = value;

                SetAttribute(new ScannerAttribute { Id = 696, DataType = ValueConverters.ActualTypeToDataType(typeof(ushort)), Value = value });
            }
        }
    }
}