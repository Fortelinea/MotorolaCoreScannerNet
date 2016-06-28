/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

namespace Motorola.Snapi.Constants.Enums
{
    public enum SupplementalMode : byte
    {
        IgnoreSupplemental,

        UPC_EAN_JANOnlyWithSupplemental,

        AutodiscriminateUPC_EAN_JANSupplementals,

        EnableSmartSupplementalMode,

        Enable378_379SupplementalMode,

        Enable978SupplementalMode
    }
}