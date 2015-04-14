using System.Collections.Generic;
using CoreScanner;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying SystemEvents attributes.
    /// These apply only to  SSI RS232 mode.
    /// </summary>
    public class SystemEvents : MotorolaAttributeSet
    {
        private bool _decodeEventEnabled;
        private bool _bootupEventEnabled;
        private bool _paramEventEnabled;
        /// <summary>
        /// Initializes a SystemEvents object containing the current values of all System Event attributes for a given scanner.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal SystemEvents(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver)
        {
            var attr = new List<ushort>();
            attr.AddRange(SystemEventAttribute.All);
            var attributes = GetAttributes(attr);
            _decodeEventEnabled = (bool)attributes[SystemEventAttribute.DecodeEvent].Value;
            _bootupEventEnabled = (bool)attributes[SystemEventAttribute.BootupEvent].Value;
            _paramEventEnabled = (bool)attributes[SystemEventAttribute.ParamEvent].Value;
        }

        public bool DecodeEventEnabled
        {
            get { return _decodeEventEnabled; }
            set
            {
                _decodeEventEnabled = value;

                SetAttribute(new ScannerAttribute { Id = SystemEventAttribute.DecodeEvent, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        public bool BootupEventEnabled
        {
            get { return _bootupEventEnabled; }
            set
            {
                _bootupEventEnabled = value;
                SetAttribute(new ScannerAttribute { Id = SystemEventAttribute.BootupEvent, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }

        public bool ParamEventEnabled
        {
            get { return _paramEventEnabled; }
            set
            {
                _paramEventEnabled = value;
                SetAttribute(new ScannerAttribute { Id = SystemEventAttribute.ParamEvent, DataType = ValueConverters.ActualTypeToDataType(typeof(bool)), Value = value });
            }
        }
    }
}