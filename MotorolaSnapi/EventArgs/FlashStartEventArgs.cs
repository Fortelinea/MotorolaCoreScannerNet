using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArgs
{
    public class FlashStartEventArgs : FirmwareEventArgs
    {
        private readonly int _maxCount;
        public FlashStartEventArgs(uint scannerId, StatusCode status, int maxCount) : base(scannerId, status) { _maxCount = maxCount; }

        public int MaxCount { get { return _maxCount; } }
    }
}