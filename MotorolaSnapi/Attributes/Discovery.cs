using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying scanner discovery attributes.
    /// </summary>
    public class Discovery : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Discovery object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Discovery(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver){}

        /// <summary>
        /// <para>Driver Attribute Name: ModelNumber</para>
        /// <para>Model number of the scanner which matches the label of the device.</para>
        /// <para>For example:"LS4208-SR20001ZZ"</para>
        /// </summary>
        public string ModelNumber
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.ModelNumber).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: SerialNumber</para>
        /// <para>Unique serial number assigned at time of manufacture.</para>
        /// <para>For example:"M1J26F45V"</para>
        /// </summary>
        public string SerialNumber
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.SerialNumber).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: BluetoothAddress</para>
        /// <para>Unique Bluetooth Address of the device, assigned at time of manufacture.</para>
        /// <para>For example: {05, 27, 33, 89, 13, 75}</para>
        /// </summary>
        public byte[] BluetoothAddress
        {
            get
            {
                var attribute = GetAttribute((ushort)DiscoveryAttribute.BluetoothAddress);
                if (attribute != null)
                    return ValueConverters.HexStringToByteArray((string)attribute.Value);
                return null;
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: DeviceClass</para>
        /// <para>Description of the device’s hardware.</para>
        /// <para>For example: "1D Laser", "2D Laser", "Imager",
        /// "Cordless 1D Laser", "Cordless 2D Laser",
        /// "Cordless Imager", "Cordless Base Station"</para>
        /// </summary>
        public string DeviceClass
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.DeviceClass).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: DateofManufacture</para>
        /// <para>Date of Device Manufacture.</para>
        /// <para>For example: "15APR05"</para>
        /// </summary>
        public DateTime DateOfManufacture
        {
            get
            {
                return DateTime.Parse((string)GetAttribute((ushort)DiscoveryAttribute.DateOfManufacture)
                                                  .Value);
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LastServiceDate</para>
        /// <para>Date of last repair within a Motorola Authorized repair facility.</para>
        /// <para>For example: "15APR05"</para>
        /// </summary>
        public DateTime LastServiceDate
        {
            get
            {
                var lastServiceDate = (string)GetAttribute((ushort)DiscoveryAttribute.LastServiceDate).Value;
                return !lastServiceDate.Equals("0000000") ? DateTime.Parse(lastServiceDate) : DateTime.MinValue;
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ScannerFirmwareVersion</para>
        /// <para>Internal Symbol tracking code for the scanner’s operating system version.</para>
        /// <para>For example: "NBRFMAAC" or "PAAAACS00-001-N01S0"</para>
        /// </summary>
        public string ScannerFirmwareVersion
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.ScannerFirmwareVersion).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ScankitVersion</para>
        /// <para>Identifies the 1D decode package that is resident in the device.</para>
        /// <para>For example: "SKIT4.33T02"</para>
        /// </summary>
        public string ScankitVersion
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.ScankitVersion).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ImagekitVersion</para>
        /// <para>Identifies the 2D decode package that is resident in the device.</para>
        /// <para>For example: "IMGKIT_4.04T02"</para>
        /// </summary>
        public string ImagekitVersion
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.ImagekitVersion).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: CombinedFirmwareVersion</para>
        /// <para>Reports firmware versions of the multiple CPU’s on
        /// a single product with space delimiters.</para>
        /// <para>For example: "NBRPUAAA NBRPUDAA"</para>
        /// </summary>
        public string CombinedFirmwareVersion
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.CombinedFirmwareVersion).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: RSMVersion</para>
        /// <para>Identifies the RSM version resident in the device.</para>
        /// <para>For example: "2.0"</para>
        /// </summary>
        public string RsmVersion
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.RSMVersion).Value; }
        }

        /// <summary>
        /// <para>Driver Attribute Name: DateofFirstProgramming</para>
        /// <para>Date of first electronic programming.</para>
        /// <para>For example: "15APR05"</para>
        /// </summary>
        public DateTime DateOfFirstProgramming
        {
            get
            {
                var dateOfFirstProgramming = (string)GetAttribute((ushort)DiscoveryAttribute.DateOfFirstProgramming).Value;
                return !dateOfFirstProgramming.Equals("DDMMMYY") ? DateTime.Parse(dateOfFirstProgramming) : DateTime.MinValue;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)DiscoveryAttribute.DateOfFirstProgramming, DataType = DataType.String, Value = value.ToString("DDMMMYY") });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ConfigurationFilename</para>
        /// <para>Identifies the device configuration. Scanning
        /// SetDefaults sets this value to Factory Defaults.
        /// Once set with this or another user defined value,
        /// this value changes to Modified upon scanning any
        /// parameter bar code.</para>
        /// </summary>
        public string ConfigurationFilename
        {
            get { return (string)GetAttribute((ushort)DiscoveryAttribute.ConfigurationFilename).Value; }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)DiscoveryAttribute.ConfigurationFilename, DataType = DataType.String, Value = value });
            }
        }
    }
}
