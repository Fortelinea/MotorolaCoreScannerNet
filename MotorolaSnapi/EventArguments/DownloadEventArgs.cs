using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    /// Contains event information related to firmware downloading. Contains the current component being downloaded and the number of records downloaded.
    /// </summary>
    public class DownloadEventArgs : FirmwareEventArgs {
        /// <summary>
        /// Creates a new instnace of DownloadEventArgs
        /// </summary>
        /// <param name="scannerId">Id number of the scanner that is downloading.</param>
        /// <param name="status">Status or error code.</param>
        /// <param name="component">software component number being downloaded.</param>
        /// <param name="progress">Number of records downloaded.</param>
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
        /// Software component number being downloaded.
        /// </summary>
        public int Component { get; private set; }
    }
}