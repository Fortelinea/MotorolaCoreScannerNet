/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    ///     Data passed by all firmware related events.
    /// </summary>
    public class FirmwareEventArgs : ScannerEventArgs
    {
        /// <summary>
        ///     Creates a new FirmwareEventArgs instance. Initializes Status.
        /// </summary>
        /// <param name="scannerId">Id number of the scanner that triggered the event.</param>
        /// <param name="status">Status or error code.</param>
        internal FirmwareEventArgs(uint scannerId, StatusCode status) : base(scannerId) { Status = status; }

        /// <summary>
        ///     Status or error code.
        /// </summary>
        public StatusCode Status { get; private set; }
    }
}