using System;
using CoreScanner;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying scanner discovery attributes.
    /// </summary>
    public class Discovery : MotorolaAttributeSet
    {

        /// <summary>
        /// Initializes a Discovery object containing the current values of all discovery attributes for a given scanner.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Discovery(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver){}

        /// <summary>
        /// Driver Attribute Name: ModelNumber
        /// Description: Model number of the scanner which matches the label of the device.
        /// For example:"LS4208-SR20001ZZ"
        /// </summary>
        public string ModelNumber
        {
            get { return (string)GetAttribute(DiscoveryAttribute.ModelNumber).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: SerialNumber
        /// Description: Unique serial number assigned at time of manufacture.
        /// For example:"M1J26F45V"
        /// </summary>
        public string SerialNumber
        {
            get { return (string)GetAttribute(DiscoveryAttribute.SerialNumber).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: BluetoothAddress
        /// Description: Unique Bluetooth Address of the device, assigned at time of manufacture.
        /// For example: {05, 27, 33, 89, 13, 75}
        /// </summary>
        public byte[] BluetoothAddress
        {
            get
            {
                var attribute = GetAttribute(DiscoveryAttribute.BluetoothAddress);
                if (attribute != null)
                    return ValueConverters.StringToByteArray((string)attribute.Value);
                return null;
            }
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
            get { return (string)GetAttribute(DiscoveryAttribute.DeviceClass).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: DateofManufacture
        /// Description: Date of Device Manufacture.
        /// For example: "15APR05"
        /// </summary>
        public DateTime DateOfManufacture
        {
            get
            {
                return DateTime.Parse((string)GetAttribute(DiscoveryAttribute.DateOfManufacture)
                                                  .Value);
            }
        }

        /// <summary>
        /// Driver Attribute Name: LastServiceDate
        /// Description: Date of last repair within a Motorola Authorized repair facility.
        /// For example: "15APR05"
        /// </summary>
        public DateTime LastServiceDate
        {
            get
            {
                var lastServiceDate = (string)GetAttribute(DiscoveryAttribute.LastServiceDate).Value;
                return !lastServiceDate.Equals("0000000") ? DateTime.Parse(lastServiceDate) : DateTime.MinValue;
            }
        }

        /// <summary>
        /// Driver Attribute Name: ScannerFirmwareVersion
        /// Description: Internal Symbol tracking code for the scanner’s operating system version.
        /// For example: "NBRFMAAC" or "PAAAACS00-001-N01S0"
        /// </summary>
        public string ScannerFirmwareVersion
        {
            get { return (string)GetAttribute(DiscoveryAttribute.ScannerFirmwareVersion).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: ScankitVersion
        /// Description: Identifies the 1D decode package that is resident in the device.
        /// For example: "SKIT4.33T02"
        /// </summary>
        public string ScankitVersion
        {
            get { return (string)GetAttribute(DiscoveryAttribute.ScankitVersion).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: ImagekitVersion
        /// Description: Identifies the 2D decode package that is resident in the device.
        /// For example: "IMGKIT_4.04T02"
        /// </summary>
        public string ImagekitVersion
        {
            get { return (string)GetAttribute(DiscoveryAttribute.ImagekitVersion).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: CombinedFirmwareVersion
        /// Description: Reports firmware versions of the multiple CPU’s on
        /// a single product with space delimiters.
        /// For example: "NBRPUAAA NBRPUDAA"
        /// </summary>
        public string CombinedFirmwareVersion
        {
            get { return (string)GetAttribute(DiscoveryAttribute.CombinedFirmwareVersion).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: RSMVersion
        /// Description: Identifies the RSM version resident in the device.
        /// For example: "2.0"
        /// </summary>
        public string RsmVersion
        {
            get { return (string)GetAttribute(DiscoveryAttribute.RSMVersion).Value; }
        }

        /// <summary>
        /// Driver Attribute Name: DateofFirstProgramming
        /// Description: Date of first electronic programming.
        /// For example: "15APR05"
        /// </summary>
        public DateTime DateOfFirstProgramming
        {
            get
            {
                var dateOfFirstProgramming = (string)GetAttribute(DiscoveryAttribute.DateOfFirstProgramming).Value;
                return !dateOfFirstProgramming.Equals("DDMMMYY") ? DateTime.Parse(dateOfFirstProgramming) : DateTime.MinValue;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = DiscoveryAttribute.DateOfFirstProgramming, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value.ToString("DDMMMYY") });
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
            get { return (string)GetAttribute(DiscoveryAttribute.ConfigurationFilename).Value; }
            set
            {
                SetAttribute(new ScannerAttribute { Id = DiscoveryAttribute.ConfigurationFilename, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }
    }
}
