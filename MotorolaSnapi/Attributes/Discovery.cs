using System;
using System.Collections.Generic;
using System.Linq;
using CoreScanner;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    public class Discovery : MotorolaAttributeSet
    {
        private string _modelNumber;
        private string _serialNumber;
        private byte[] _bluetoothAddress;
        private string _deviceClass;
        private DateTime _dateOfManufacture;
        private DateTime _lastServiceDate;
        private string _scannerFirmwareVersion;
        private string _scankitVersion;
        private string _imagekitVersion;
        private string _combinedFirmwareVersion;
        private string _rsmVersion;
        private string _dateOfFirstProgramming;
        private string _configurationFilename;

        public Discovery(int scannerId, ICoreScanner scannerDriver) : base(scannerId, scannerDriver)
        {
            var attr = new List<ushort>();
            attr.AddRange(Enum.GetValues(typeof(DiscoveryAttribute)).Cast<ushort>());
            var attributes = GetAttributes(attr);
            _modelNumber = (string)attributes[DiscoveryAttribute.ModelNumber].Value;
            _serialNumber = (string)attributes[DiscoveryAttribute.SerialNumber].Value;
            _bluetoothAddress = ValueConverters.StringToByteArray((string)attributes[DiscoveryAttribute.BluetoothAddress].Value);
            _deviceClass = (string)attributes[DiscoveryAttribute.DeviceClass].Value;
            _dateOfManufacture = DateTime.Parse((string)attributes[DiscoveryAttribute.DateOfManufacture].Value);
            _lastServiceDate = DateTime.Parse((string)attributes[DiscoveryAttribute.LastServiceDate].Value);
            _scannerFirmwareVersion = (string)attributes[DiscoveryAttribute.ScannerFirmwareVersion].Value;
            _scankitVersion = (string)attributes[DiscoveryAttribute.ScankitVersion].Value;
            _imagekitVersion = (string)attributes[DiscoveryAttribute.ImagekitVersion].Value;
            _combinedFirmwareVersion = (string) attributes[DiscoveryAttribute.CombinedFirmwareVersion].Value;
            _rsmVersion = (string)attributes[DiscoveryAttribute.RSMVersion].Value;
            _dateOfFirstProgramming = (string)attributes[DiscoveryAttribute.DateOfFirstProgramming].Value;
            _configurationFilename = (string)attributes[DiscoveryAttribute.ConfigurationFilename].Value;
        }

        public string ModelNumber
        {
            get { return _modelNumber; }
            set
            {
                _modelNumber = value;

                SetAttribute(new ScannerAttribute { Id = 533, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });
            }
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
            set
            {
                _serialNumber = value;

                SetAttribute(new ScannerAttribute { Id = 534, DataType = ValueConverters.ActualTypeToDataType(typeof(string)), Value = value });

            }
        }

        public byte[] BluetoothAddress
        {
            get { return _bluetoothAddress; }
            set { _bluetoothAddress = value; }
        }

        public string DeviceClass
        {
            get { return _deviceClass; }
            set { _deviceClass = value; }
        }

        public DateTime DateOfManufacture
        {
            get { return _dateOfManufacture; }
            set { _dateOfManufacture = value; }
        }

        public DateTime LastServiceDate
        {
            get { return _lastServiceDate; }
            set { _lastServiceDate = value; }
        }

        public string ScannerFirmwareVersion
        {
            get { return _scannerFirmwareVersion; }
            set { _scannerFirmwareVersion = value; }
        }

        public string ScankitVersion
        {
            get { return _scankitVersion; }
            set { _scankitVersion = value; }
        }

        public string ImagekitVersion
        {
            get { return _imagekitVersion; }
            set { _imagekitVersion = value; }
        }

        public string CombinedFirmwareVersion
        {
            get { return _combinedFirmwareVersion; }
            set { _combinedFirmwareVersion = value; }
        }

        public string RsmVersion
        {
            get { return _rsmVersion; }
            set { _rsmVersion = value; }
        }

        public string DateOfFirstProgramming
        {
            get { return _dateOfFirstProgramming; }
            set { _dateOfFirstProgramming = value; }
        }

        public string ConfigurationFilename
        {
            get { return _configurationFilename; }
            set { _configurationFilename = value; }
        }
    }
}
