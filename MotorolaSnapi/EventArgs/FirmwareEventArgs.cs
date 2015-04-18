using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArgs
{
    public class FirmwareEventArgs : ScannerEventArgs
    {
        private readonly StatusCode _status;
        internal FirmwareEventArgs(uint scannerId, StatusCode status) : base(scannerId)
        {
            _status = status;
        }

        public StatusCode Status { get { return _status; } }
    }
}