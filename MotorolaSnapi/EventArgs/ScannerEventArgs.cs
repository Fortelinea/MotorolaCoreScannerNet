namespace Motorola.Snapi.EventArgs
{
    public class ScannerEventArgs : System.EventArgs
    {
        private readonly uint _scannerId;
        internal ScannerEventArgs(uint scannerId) { _scannerId = scannerId; }

        public uint ScannerId
        {
            get { return _scannerId; }
        }
    }
}