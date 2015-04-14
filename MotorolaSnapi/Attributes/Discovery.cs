using System;
using System.Collections.Generic;
using System.Linq;
using CoreScanner;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying scanner discovery attributes.
    /// </summary>
    public class Discovery : MotorolaAttributeSet
    {
        private readonly string _modelNumber;
        private readonly string _serialNumber;
        private readonly byte[] _bluetoothAddress;
        private readonly string _deviceClass;
        private readonly DateTime _dateOfManufacture;
        private readonly DateTime _lastServiceDate;
        private readonly string _scannerFirmwareVersion;
        private readonly string _scankitVersion;
        private readonly string _imagekitVersion;
        private readonly string _combinedFirmwareVersion;
        private readonly string _rsmVersion;
        private DateTime _dateOfFirstProgramming;
        private string _configurationFilename;

        /// <summary>
        /// Initializes a Discovery object containing the current values of all discovery attributes for a given scanner.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Discovery(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver)
        {
            var attr = new List<ushort>();
            attr.AddRange(DiscoveryAttribute.All);
            var attributes = GetAttributes(attr);
            _modelNumber = (string)attributes[DiscoveryAttribute.ModelNumber].Value;
            _serialNumber = (string)attributes[DiscoveryAttribute.SerialNumber].Value;
            //If the scanner is not a bluetooth device, no attribute will be returned;
            var btAddrKey = DiscoveryAttribute.BluetoothAddress;
            _bluetoothAddress = attributes.ContainsKey(btAddrKey) ? ValueConverters.StringToByteArray((string)attributes[btAddrKey].Value) : null;
            _deviceClass = (string)attributes[DiscoveryAttribute.DeviceClass].Value;
            _dateOfManufacture = DateTime.Parse((string)attributes[DiscoveryAttribute.DateOfManufacture].Value);
            //If value is "0000000" device has never been serviced.
            var lastServiceDate = (string)attributes[DiscoveryAttribute.LastServiceDate].Value;
            _lastServiceDate = !lastServiceDate.Equals("0000000") ? DateTime.Parse(lastServiceDate) : DateTime.MinValue;
            _scannerFirmwareVersion = (string)attributes[DiscoveryAttribute.ScannerFirmwareVersion].Value;
            _scankitVersion = (string)attributes[DiscoveryAttribute.ScankitVersion].Value;
            _imagekitVersion = (string)attributes[DiscoveryAttribute.ImagekitVersion].Value;
            _combinedFirmwareVersion = (string) attributes[DiscoveryAttribute.CombinedFirmwareVersion].Value;
            _rsmVersion = (string)attributes[DiscoveryAttribute.RSMVersion].Value;
            //If value is "DDMMMYY" value has never been set.
            var dateOfFirstProgramming = (string)attributes[DiscoveryAttribute.DateOfFirstProgramming].Value;
            if (!dateOfFirstProgramming.Equals("DDMMMYY"))
                _dateOfFirstProgramming = DateTime.Parse(dateOfFirstProgramming);
            else _dateOfFirstProgramming = DateTime.MinValue;
            _configurationFilename = (string)attributes[DiscoveryAttribute.ConfigurationFilename].Value;
        }

        /// <summary>
        /// Driver Attribute Name: ModelNumber
        /// Description: Model number of the scanner which matches the label of the device.
        /// For example:"LS4208-SR20001ZZ"
        /// </summary>
        public string ModelNumber
        {
            get { return _modelNumber; }
        }

        /// <summary>
        /// Driver Attribute Name: SerialNumber
        /// Description: Unique serial number assigned at time of manufacture.
        /// For example:"M1J26F45V"
        /// </summary>
        public string SerialNumber
        {
            get { return _serialNumber; }
        }

        /// <summary>
        /// Driver Attribute Name: BluetoothAddress
        /// Description: Unique Bluetooth Address of the device, assigned at time of manufacture.
        /// For example: {05, 27, 33, 89, 13, 75}
        /// </summary>
        public byte[] BluetoothAddress
        {
            get { return _bluetoothAddress; }
        }

        /// <summary>
        /// Driver Attribute Name: DeviceClass
        /// Description: Description of the device’s hardware.
        /// For example: "1D Laser", "2D Laser", "Imager",
        /// "Cordless 1D Laser", "Cordless 2D Laser",
        /// "Cordless Imager", "Cordless Base Station"
        /// </summary>
        public string DeviceClass
        {
            get { return _deviceClass; }
        }

        /// <summary>
        /// Driver Attribute Name: DateofManufacture
        /// Description: Date of Device Manufacture.
        /// For example: "15APR05"
        /// </summary>
        public DateTime DateOfManufacture
        {
            get { return _dateOfManufacture; }
        }

        /// <summary>
        /// Driver Attribute Name: LastServiceDate
        /// Description: Date of last repair within a Motorola Authorized repair facility.
        /// For example: "15APR05"
        /// </summary>
        public DateTime LastServiceDate
        {
            get { return _lastServiceDate; }
        }

        /// <summary>
        /// Driver Attribute Name: ScannerFirmwareVersion
        /// Description: Internal Symbol tracking code for the scanner’s operating system version.
        /// For example: "NBRFMAAC" or "PAAAACS00-001-N01S0"
        /// </summary>
        public string ScannerFirmwareVersion
        {
            get { return _scannerFirmwareVersion; }
        }

        /// <summary>
        /// Driver Attribute Name: ScankitVersion
        /// Description: Identifies the 1D decode package that is resident in the device.
        /// For example: "SKIT4.33T02"
        /// </summary>
        public string ScankitVersion
        {
            get { return _scankitVersion; }
        }

        /// <summary>
        /// Driver Attribute Name: ImagekitVersion
        /// Description: Identifies the 2D decode package that is resident in the device.
        /// For example: "IMGKIT_4.04T02"
        /// </summary>
        public string ImagekitVersion
        {
            get { return _imagekitVersion; }
        }

        /// <summary>
        /// Driver Attribute Name: CombinedFirmwareVersion
        /// Description: Reports firmware versions of the multiple CPU’s on
        /// a single product with space delimiters.
        /// For example: "NBRPUAAA NBRPUDAA"
        /// </summary>
        public string CombinedFirmwareVersion
        {
            get { return _combinedFirmwareVersion; }
        }

        /// <summary>
        /// Driver Attribute Name: RSMVersion
        /// Description: Identifies the RSM version resident in the device.
        /// For example: "2.0"
        /// </summary>
        public string RsmVersion
        {
            get { return _rsmVersion; }
        }

        /// <summary>
        /// Driver Attribute Name: DateofFirstProgramming
        /// Description: Date of first electronic programming.
        /// For example: "15APR05"
        /// </summary>
        public DateTime DateOfFirstProgramming
        {
            get { return _dateOfFirstProgramming; }
            set
            {
                _dateOfFirstProgramming = value;
                SetAttribute(new ScannerAttribute { Id = (ushort)DiscoveryAttribute.DateOfFirstProgramming, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }

        /// <summary>
        /// Driver Attribute Name: ConfigurationFilename
        /// Description: Identifies the device configuration. Scanning
        /// SetDefaults sets this value to Factory Defaults.
        /// Once set with this or another user defined value,
        /// this value changes to Modified upon scanning any
        /// parameter bar code.
        /// </summary>
        public string ConfigurationFilename
        {
            get { return _configurationFilename; }
            set
            {
                _configurationFilename = value;
                SetAttribute(new ScannerAttribute { Id = (ushort)DiscoveryAttribute.ConfigurationFilename, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }
    }
}
