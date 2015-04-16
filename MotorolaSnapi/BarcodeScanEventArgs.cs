using System;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    public class BarcodeScanEventArgs : EventArgs
    {
        private readonly BarcodeType _barcodeType;
        private readonly string _data;
        private readonly byte[] _rawData;
        private readonly UInt32 _scannerId;

        public BarcodeScanEventArgs(UInt32 scannerIdentifier, BarcodeType barcodeType, string data, byte[] rawData)
        {
            _scannerId = scannerIdentifier;
            _data = data;
            _rawData = rawData;
            _barcodeType = barcodeType;
        }

        public BarcodeType BarcodeType
        {
            get { return _barcodeType; }
        }

        public string Data
        {
            get { return _data; }
        }

        public byte[] RawData
        {
            get { return _rawData; }
        }

        public UInt32 ScannerId
        {
            get { return _scannerId; }
        }
    }
}