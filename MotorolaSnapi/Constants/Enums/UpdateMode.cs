/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System.ComponentModel;

namespace Motorola.Snapi.Constants.Enums
{
    public enum UpdateMode
    {
        [Description("USB HID")]
        UsbHid = 1,

        [Description("USB Bulk")]
        UsbBulk = 2
    }
}