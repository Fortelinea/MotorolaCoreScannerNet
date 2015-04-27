/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System.ComponentModel;

namespace Motorola.Snapi.Constants.Enums
{
    public enum LicenseParseMode : byte
    {
        [Description("Parsing Off")]
        Off,

        [Description("Parse license with Embedded Software.")]
        ParseEmbedded,

        [Description("Encrypt license then send to host for parsing")]
        ParseServer,

        [Description("Not Available")]
        NA
    }
}