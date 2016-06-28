/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    ///     Data sent by scanner when a flash has started.
    /// </summary>
    public class FlashStartEventArgs : FirmwareEventArgs
    {
        /// <summary>
        ///     Creates a new instance of FlashStartEventArgs
        /// </summary>
        /// <param name="scannerId">Id number of the scanner that triggered the event.</param>
        /// <param name="status">Status or error code.</param>
        /// <param name="totalRecords">Total number of records to be downloaded.</param>
        public FlashStartEventArgs(uint scannerId, StatusCode status, int totalRecords) : base(scannerId, status) { TotalRecords = totalRecords; }

        /// <summary>
        ///     Total records to be downloaded. This value can be saved and compared to Progress on BlockFinished events to get the
        ///     completion percentage.
        /// </summary>
        public int TotalRecords { get; private set; }
    }
}