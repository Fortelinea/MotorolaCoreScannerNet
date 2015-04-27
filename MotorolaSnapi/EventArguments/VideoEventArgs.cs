/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    /// Not implemented. Only contains scanner id. No plans to implement in the near future unless I find a need for it.
    /// </summary>
    public class VideoEventArgs : ScannerEventArgs
    {
        internal VideoEventArgs(uint scannerId) : base(scannerId) { }
    }
}