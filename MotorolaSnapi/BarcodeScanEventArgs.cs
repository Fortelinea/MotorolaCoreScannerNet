using System;

namespace Motorola.Snapi
{
    public class BarcodeScanEventArgs : EventArgs
    {
        private string _data;
        private UInt32 _scannerId;

        public BarcodeScanEventArgs(UInt32 scannerIdentifier, string data)
        {
            _scannerId = scannerIdentifier;
            _data = data;
        }

        public string Data
        {
            get
            {
                return _data;
            }
        }

        public UInt32 ScannerId
        {
            get
            {
                return _scannerId;
            }
        }
    }
}