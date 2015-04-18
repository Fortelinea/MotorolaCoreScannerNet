using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArguments
{
    public class FlashStartEventArgs : FirmwareEventArgs
    {
        private readonly int _totalRecords;
        public FlashStartEventArgs(uint scannerId, StatusCode status, int totalRecords) : base(scannerId, status) { _totalRecords = totalRecords; }

        /// <summary>
        /// Total records to be downloaded. This value can be saved and compared to Progress on BlockFinished events to get the completion percentage.
        /// </summary>
        public int TotalRecords { get { return _totalRecords; } }
    }
}