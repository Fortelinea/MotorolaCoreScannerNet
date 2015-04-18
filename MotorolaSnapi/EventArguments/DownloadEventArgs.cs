using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArguments
{
    public class DownloadEventArgs : FirmwareEventArgs {

        public DownloadEventArgs(uint scannerId, StatusCode status, int component, int progress = 0) : base(scannerId, status)
        {
            Component = component;
            Progress = progress;
        }
        /// <summary>
        /// Number of records downloaded. This value can be compared to TotalRecords from the FlashSessionStarted event to get the completion percentage.
        /// </summary>
        public int Progress { get; private set; }
        /// <summary>
        /// Software component number
        /// </summary>
        public int Component { get; private set; }
    }
}