/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using Motorola.Snapi.Attributes;

namespace Motorola.Snapi
{
    public partial class BarcodeScanner
    {
        private Adf _adf;

        private Beeper _beeper;

        private Custom _custom;

        private Chinese2Of5 _chinese2Of5;

        private Codabar _codabar;

        private Code11 _code11;

        private Code128 _code128;

        private Code32 _code32;

        private Code39 _code39;

        private Code93 _code93;

        private DataMatrixQr _dataMatrixQr;

        private Discovery _discovery;

        private Discrete2Of5 _discrete2Of5;

        private Imaging _imaging;

        private Interleaved2Of5 _interleaved2Of5;

        private LicenseParsing _license;

        private Maxicode _maxicode;

        private Msi _msi;

        private Ocr _ocr;

        private Pdf _pdf;

        private Postal _postal;

        private RssGs1Databar _rssGs1Databar;

        private SignatureCapture _signatureCapture;

        private Status _status;

        private SymbologySecurity _symbologySecurityLevel;

        private Synapse _synapse;

        private SystemEvents _systemEvents;

        private UpcEan _upcEan;

        #region IMotorolaBarcodeScanner Members

        public Adf ADF => _adf ?? (_adf = new Adf(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Beeper Beeper => _beeper ?? (_beeper = new Beeper(Info.ScannerId, _scannerDriver));

        public Custom Custom => _custom ?? (_custom = new Custom(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Chinese2Of5 Chinese2Of5 => _chinese2Of5 ?? (_chinese2Of5 = new Chinese2Of5(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Codabar Codabar => _codabar ?? (_codabar = new Codabar(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Code11 Code11 => _code11 ?? (_code11 = new Code11(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Code128 Code128 => _code128 ?? (_code128 = new Code128(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Code32 Code32 => _code32 ?? (_code32 = new Code32(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Code39 Code39 => _code39 ?? (_code39 = new Code39(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Code93 Code93 => _code93 ?? (_code93 = new Code93(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public DataMatrixQr DataMatrixQR => _dataMatrixQr ?? (_dataMatrixQr = new DataMatrixQr(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Discovery Discovery => _discovery ?? (_discovery = new Discovery(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Discrete2Of5 Discrete2Of5 => _discrete2Of5 ?? (_discrete2Of5 = new Discrete2Of5(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public SystemEvents Events => _systemEvents ?? (_systemEvents = new SystemEvents(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Imaging Imaging => _imaging ?? (_imaging = new Imaging(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Interleaved2Of5 Interleaved2Of5 => _interleaved2Of5 ?? (_interleaved2Of5 = new Interleaved2Of5(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public LicenseParsing License => _license ?? (_license = new LicenseParsing(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Maxicode Maxicode => _maxicode ?? (_maxicode = new Maxicode(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Msi MSI => _msi ?? (_msi = new Msi(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Ocr OCR => _ocr ?? (_ocr = new Ocr(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Pdf PDF => _pdf ?? (_pdf = new Pdf(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Postal Postal => _postal ?? (_postal = new Postal(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public RssGs1Databar RssGs1Databar => _rssGs1Databar ?? (_rssGs1Databar = new RssGs1Databar(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public SignatureCapture SignatureCapture => _signatureCapture ?? (_signatureCapture = new SignatureCapture(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Status Status => _status ?? (_status = new Status(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public SymbologySecurity SymbologySecurity => _symbologySecurityLevel ?? (_symbologySecurityLevel = new SymbologySecurity(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public Synapse Synapse => _synapse ?? (_synapse = new Synapse(Info.ScannerId, _scannerDriver));

        #endregion

        #region IMotorolaBarcodeScanner Members

        public UpcEan UPC_EAN => _upcEan ?? (_upcEan = new UpcEan(Info.ScannerId, _scannerDriver));

        #endregion
    }
}