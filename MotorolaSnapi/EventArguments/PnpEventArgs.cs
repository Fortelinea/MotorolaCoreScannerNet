namespace Motorola.Snapi.EventArguments
{
    public class PnpEventArgs : ScannerEventArgs
    {
        public PnpEventArgs(uint scannerId) : base(scannerId) {}
        //TODO Possibly expand this to include more scanner info so this may be used instead of GetScanners in certain situations.
    }
}