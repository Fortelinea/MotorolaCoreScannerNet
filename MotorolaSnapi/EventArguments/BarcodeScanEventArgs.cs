using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArguments
{
    public class BarcodeScanEventArgs : ScannerEventArgs
    {
        private readonly BarcodeType _barcodeType;
        private readonly string _data;
        private readonly byte[] _rawData;

        public BarcodeScanEventArgs(uint scannerId, BarcodeType barcodeType, string data, byte[] rawData) : base(scannerId)
        {
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
    }
}