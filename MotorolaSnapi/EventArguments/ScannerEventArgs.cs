/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using System;

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    /// Contains just a scannerId. Base class for all Scanner events.
    /// </summary>
    public class ScannerEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instanxe of ScannerEventArgs.
        /// </summary>
        /// <param name="scannerId">Id number of the scanner that triggered the event.</param>
        internal ScannerEventArgs(uint scannerId) { ScannerId = scannerId; }

        /// <summary>
        /// Id number of the scanner that generated the event.
        /// </summary>
        public uint ScannerId { get; private set; }
    }
}