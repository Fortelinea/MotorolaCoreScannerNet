using System.ComponentModel;

namespace Motorola.Snapi.Constants.Enums
{
    public enum EventType : ushort
    {
        [Description("Barcode scan events.")]
        Barcode = 1,
        [Description("Image capture events.")]
        Image = 2,
        [Description("Video capture events.")]
        Video = 4,
        [Description("Firmware update events.")]
        Rmd = 8,
        [Description("Attach / Detach events.")]
        Pnp = 16,
        [Description("CommandResponceEvent's, IOEvent's, and ScannerNotificationEvent's")]
        Other = 32
    }
}
