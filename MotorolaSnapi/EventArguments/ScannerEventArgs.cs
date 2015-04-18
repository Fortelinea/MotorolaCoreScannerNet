using System;

namespace Motorola.Snapi.EventArguments
{
    public class ScannerEventArgs : EventArgs
    {
        private readonly uint _scannerId;
        internal ScannerEventArgs(uint scannerId) { _scannerId = scannerId; }

        /// <summary>
        /// Id number of the scanner that generated the event.
        /// </summary>
        public uint ScannerId
        {
            get { return _scannerId; }
        }
    }
}