using CoreScanner;
using Motorola.Snapi.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Motorola.Snapi.Attributes
{
    public class Ocr : MotorolaAttributeSet
    {
        private ushort _checkDigitMod;
        private string _checkDigitMultiplier;
        private ushort _despeckle;
        private bool _enableExternalFinder;
        private bool _enableFinder;
        private bool _enableUSCurrency;
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

        internal Ocr(int scannerId, CCoreScannerClass scannerDriver)
            : base(scannerId, scannerDriver)
        {
            var attr = new List<ushort>();
            attr.AddRange(Enumerable.Range(680, 22).Select(i => (ushort)i));
            attr.Add(707);
            attr.Add(554);
            attr.Add(547);
            GetAttributes(attr); // Needs to be finished
            //_isOcrBEnabled = ;
        }

        /// <summary>
        /// 1..99
        /// </summary>
        public ushort CheckDigitMod
        {
            get { return _checkDigitMod; }
            set
            {
                _checkDigitMod = value;

                SetAttribute(688, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        public string CheckDigitMultiplier
        {
            get { return _checkDigitMultiplier; }
            set
            {
                _checkDigitMultiplier = value;

                SetAttribute(700, DataTypeHelper.Convert(typeof(string)), value);
            }
        }

        /// <summary>
        /// 0..9
        /// </summary>
        public ushort CheckDigitValidation
        {
            get { return _quietZone; }
            set
            {
                _quietZone = value;

                SetAttribute(694, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        /// <summary>
        /// 0..99
        /// </summary>
        public ushort Despeckle
        {
            get { return _despeckle; }
            set
            {
                _despeckle = value;

                SetAttribute(697, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        public bool EnableExternalFinder
        {
            get { return _enableExternalFinder; }
            set
            {
                _enableExternalFinder = value;

                SetAttribute(707, DataTypeHelper.Convert(typeof(bool)), value);
            }
        }

        public bool EnableFinder
        {
            get { return _enableFinder; }
            set
            {
                _enableFinder = value;

                SetAttribute(702, DataTypeHelper.Convert(typeof(bool)), value);
            }
        }

        public bool EnableIllumination
        {
            get { return _isIlluminationEnabled; }
            set
            {
                _isIlluminationEnabled = value;

                SetAttribute(701, DataTypeHelper.Convert(typeof(bool)), value);
            }
        }

        public bool EnableMicre13B
        {
            get { return _isMicre13BEnabled; }
            set
            {
                _isMicre13BEnabled = value;

                SetAttribute(682, DataTypeHelper.Convert(typeof(bool)), value);
            }
        }

        public bool EnableOcrA
        {
            get { return _isOcrAEnabled; }
            set
            {
                _isOcrAEnabled = value;

                SetAttribute(680, DataTypeHelper.Convert(typeof(bool)), value);
            }
        }

        public bool EnableOcrB
        {
            get { return _isOcrBEnabled; }
            set
            {
                _isOcrBEnabled = value;

                SetAttribute(681, DataTypeHelper.Convert(typeof(bool)), value);
            }
        }

        public bool EnableUSCurrency
        {
            get { return _enableUSCurrency; }
            set
            {
                _enableUSCurrency = value;

                SetAttribute(683, DataTypeHelper.Convert(typeof(bool)), value);
            }
        }

        public ushort Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;

                SetAttribute(691, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        /// <summary>
        /// 0..20
        /// </summary>
        public ushort LowPassFilter
        {
            get { return _lowPassFilter; }
            set
            {
                _lowPassFilter = value;

                SetAttribute(699, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        public ushort MaxCharacters
        {
            get { return _maxCharacters; }
            set
            {
                _maxCharacters = value;

                SetAttribute(690, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        public ushort MinCharacters
        {
            get { return _minCharacters; }
            set
            {
                _minCharacters = value;

                SetAttribute(689, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        /// <summary>
        /// 0, 1, 2, 3
        /// </summary>
        public ushort OcrAVariant
        {
            get { return _ocrAVariant; }
            set
            {
                _ocrAVariant = value;

                SetAttribute(684, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        /// <summary>
        /// 0..10
        /// </summary>
        public ushort OcrBVariant
        {
            get { return _ocrBVariant; }
            set
            {
                _ocrBVariant = value;

                SetAttribute(685, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        public BarcodeOrientation Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;

                SetAttribute(687, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        /// <summary>
        /// 20..99
        /// </summary>
        public ushort QuietZone
        {
            get { return _quietZone; }
            set
            {
                _quietZone = value;

                SetAttribute(695, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        /// <summary>
        /// Sets the secrurity Level between 10 and 90
        /// </summary>
        public ushort SecurityLevel
        {
            get { return _securityLevel; }
            set
            {
                _securityLevel = value;

                SetAttribute(554, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        public string Template
        {
            get { return _template; }
            set
            {
                _template = value;

                SetAttribute(547, DataTypeHelper.Convert(typeof(string)), value);
            }
        }

        /// <summary>
        /// 0..16
        /// </summary>
        public ushort Thicken
        {
            get { return _thicken; }
            set
            {
                _thicken = value;

                SetAttribute(698, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }

        public string ValidCharacters
        {
            get { return _validCharacters; }
            set
            {
                _validCharacters = value;

                SetAttribute(686, DataTypeHelper.Convert(typeof(string)), value);
            }
        }

        /// <summary>
        /// 0..99
        /// </summary>
        public ushort WhiteLevel
        {
            get { return _whiteLevel; }
            set
            {
                _whiteLevel = value;

                SetAttribute(696, DataTypeHelper.Convert(typeof(byte)), value);
            }
        }
    }
}