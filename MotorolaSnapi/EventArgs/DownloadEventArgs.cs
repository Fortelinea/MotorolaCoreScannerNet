using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArgs
{
    public class DownloadEventArgs : FirmwareEventArgs {
        public int Component { get; private set; }

        public DownloadEventArgs(uint scannerId, StatusCode status, int component, int progress = 0) : base(scannerId, status)
        {
            Component = component;
            Progress = progress;
        }

        public object Progress { get; private set; }
    }
}