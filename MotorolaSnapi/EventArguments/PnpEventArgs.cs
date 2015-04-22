/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    /// Contains scanner info sent when a scanner is connected or disconnected.
    /// </summary>
    public class PnpEventArgs : ScannerEventArgs
    {
        /// <summary>
        /// Creates a new PnpEventArgs instance. passes scannerId to base class.
        /// </summary>
        /// <param name="scannerId">Id number of scanner that triggered the event.</param>
        public PnpEventArgs(uint scannerId) : base(scannerId) {}
        //TODO Possibly expand this to include more scanner info so this may be used instead of GetScanners in certain situations.
    }
}