namespace Motorola.Snapi.EventArgs
{
    public class PnpEventArgs : ScannerEventArgs
    {
        public PnpEventArgs(uint scannerId, string ppnpdata) : base(scannerId) {
            Xml = ppnpdata;
        }

        public string Xml { get; private set; }
    }
}