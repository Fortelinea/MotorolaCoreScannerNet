using System.Security.Cryptography;
using CoreScanner;
using Motorola.Snapi.Commands;

namespace Motorola.Snapi.Attributes
{
    public class AttributeSets {
        private readonly CCoreScanner _scannerDriver;
        private Discovery _discovery;
        private SystemEvents _systemEvents;
        private Status _status;
        private Ocr _ocr;
        private Imaging _imaging;
        private Beeper _beeper;
        private LicenseParsing _license;
        private Adf _adf;
        private Synapse _synapse;
        private UpcEan _upcEan;
        private readonly int _scannerId;
        private Code128 _code128;
        private Code39 _code39;
        private Code93 _code93;
        private Code11 _code11;
        private Interleaved2Of5 _interleaved2Of5;
        private Discrete2Of5 _discrete2Of5;
        private Chinese2Of5 _chinese2Of5;
        private Codabar _codabar;
        private Msi _msi;
        private RssGs1Databar _rssGs1Databar;
        private Code32 _code32;
        private SymbologySecurity _symbologySecurityLevel;
        private Pdf _pdf;
        private DataMatrixQr _dataMatrixQr;
        private Maxicode _maxicode;
        private Postal _postal;
        private SignatureCapture _signatureCapture;

        public AttributeSets(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerId = scannerId;
            _scannerDriver = scannerDriver;
        }

        public Discovery Discovery
        {
            get { return _discovery ?? (_discovery = new Discovery(_scannerId, _scannerDriver)); }
        }

        public Ocr OCR
        {
            get { return _ocr ?? (_ocr = new Ocr(_scannerId, _scannerDriver)); }
        }

        public SystemEvents Events
        {
            get { return _systemEvents ?? (_systemEvents = new SystemEvents(_scannerId, _scannerDriver)); }
        }

        public Status Status
        {
            get { return _status ?? (_status = new Status(_scannerId, _scannerDriver)); }
        }

        public Imaging Imaging
        {
            get { return _imaging ?? (_imaging = new Imaging(_scannerId, _scannerDriver)); }
        }

        public Beeper Beeper
        {
            get { return _beeper ?? (_beeper = new Beeper(_scannerId, _scannerDriver)); }
        }

        public LicenseParsing License
        {
            get { return _license ?? (_license = new LicenseParsing(_scannerId, _scannerDriver)); }
        }

        public Adf ADF
        {
            get { return _adf ?? (_adf = new Adf(_scannerId, _scannerDriver)); }
        }

        public Synapse Synapse
        {
            get { return _synapse ?? (_synapse = new Synapse(_scannerId, _scannerDriver)); }
        }

        public UpcEan UPC_EAN
        {
            get { return _upcEan ?? (_upcEan = new UpcEan(_scannerId, _scannerDriver)); }
        }

        public Code128 Code128
        {
            get { return _code128 ?? (_code128 = new Code128(_scannerId, _scannerDriver)); }
        }

        public Code39 Code39
        {
            get { return _code39 ?? (_code39 = new Code39(_scannerId, _scannerDriver)); }
        }

        public Code93 Code93
        {
            get { return _code93 ?? (_code93 = new Code93(_scannerId, _scannerDriver)); }
        }

        public Code11 Code11
        {
            get { return _code11 ?? (_code11 = new Code11(_scannerId, _scannerDriver)); }
        }

        public Interleaved2Of5 Interleaved2Of5
        {
            get { return _interleaved2Of5 ?? (_interleaved2Of5 = new Interleaved2Of5(_scannerId, _scannerDriver)); }
        }

        public Discrete2Of5 Discrete2Of5
        {
            get { return _discrete2Of5 ?? (_discrete2Of5 = new Discrete2Of5(_scannerId, _scannerDriver)); }
        }

        public Chinese2Of5 Chinese2Of5
        {
            get { return _chinese2Of5 ?? (_chinese2Of5 = new Chinese2Of5(_scannerId, _scannerDriver)); }
        }

        public Codabar Codabar
        {
            get { return _codabar ?? (_codabar = new Codabar(_scannerId, _scannerDriver)); }
        }

        public Msi MSI
        {
            get { return _msi ?? (_msi = new Msi(_scannerId, _scannerDriver)); }
        }

        public RssGs1Databar RssGs1Databar
        {
            get { return _rssGs1Databar ?? (_rssGs1Databar = new RssGs1Databar(_scannerId, _scannerDriver)); }
        }

        public Code32 Code32
        {
            get { return _code32 ?? (_code32 = new Code32(_scannerId, _scannerDriver)); }
        }

        public SymbologySecurity SymbologySecurity
        {
            get { return _symbologySecurityLevel ?? (_symbologySecurityLevel = new SymbologySecurity(_scannerId, _scannerDriver)); }
        }

        public Pdf PDF
        {
            get { return _pdf ?? (_pdf = new Pdf(_scannerId, _scannerDriver)); }
        }

        public DataMatrixQr DataMatrixQR
        {
            get { return _dataMatrixQr ?? (_dataMatrixQr = new DataMatrixQr(_scannerId, _scannerDriver)); }
        }

        public Maxicode Maxicode
        {
            get { return _maxicode ?? (_maxicode = new Maxicode(_scannerId, _scannerDriver)); }
        }

        public Postal Postal
        {
            get { return _postal ?? (_postal = new Postal(_scannerId, _scannerDriver)); }
        }

        public SignatureCapture SignatureCapture
        {
            get { return _signatureCapture ?? (_signatureCapture = new SignatureCapture(_scannerId, _scannerDriver)); }
        }
    }
}