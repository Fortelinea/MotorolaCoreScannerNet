using CoreScanner;
using Motorola.Snapi.Attributes;

namespace Motorola.Snapi
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
    }
}