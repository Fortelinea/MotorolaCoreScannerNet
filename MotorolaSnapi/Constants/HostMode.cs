namespace Motorola.Snapi.Constants
{
    /// <summary>
    /// Stores strings used for setting host mode.
    /// </summary>
    public static class HostMode
    {
        public const string USB_SNAPI_Imaging = @"XUA-45001-9"; //USB-SNAPI with Imaging
        public const string USB_SNAPI_NoImaging = @"XUA-45001-10"; //USB-SNAPI without Imaging
        public const string USB_IBMHID = @"XUA-45001-1"; //USB-IBMHID
        public const string USB_IBMTT = @"XUA-45001-2"; //USB-IBMTT
        public const string USB_HIDKB = @"XUA-45001-3"; //USB-HIDKB
        public const string USB_OPOS = @"XUA-45001-8"; //USB-OPOS
        public const string USB_CDC = @"XUA-45001-11"; //USB-CDC Serial Emulation *THIS WILL PREVENT THE SDK FROM COMMUNICATING WITH THE SCANNER UNTIL YOU RESET DEFAULTS*
    }
}