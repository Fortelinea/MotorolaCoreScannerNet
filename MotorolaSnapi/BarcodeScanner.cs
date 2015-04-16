using System;
using System.IO;
using System.Xml.Linq;
using CoreScanner;
using Motorola.Snapi.Attributes;
using Motorola.Snapi.Constants;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    public class BarcodeScanner : IMotorolaSnapiScanner
    {
        private readonly CCoreScanner _scannerDriver;

        internal BarcodeScanner(CCoreScanner scannerDriver, XElement scannerXml)
        {
            _scannerDriver = scannerDriver;
            Parse(scannerXml);
        }

        #region Commands
        public void SetHostMode(string mode, bool permanent = false, bool silent = true)
        {
            string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-string>{1}</arg-string><arg-bool>{2}</arg-bool><arg-bool>{3}</arg-bool></cmdArgs></inArgs>";
            string inXml = string.Format(setCommandXml, ScannerId, mode, silent ? "TRUE" : "FALSE", permanent ? "TRUE" : "FALSE");
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSwitchHostMode, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException{ErrorCode = (StatusCode)status};
            UsbHostMode = mode;
            //return status;
        }
        #endregion

        #region ScannerInfo
        public string DateOfManufacture { get; private set; }

        public string Firmware { get; private set; }

        public Guid GUID { get; private set; }

        public string UsbHostMode { get; private set; }

        public string ModelNumber { get; private set; }

        public int ProductId { get; private set; }

        public int ScannerId { get; private set; }

        public string SerialNumber { get; private set; }

        public int VendorId { get; private set; }

        public CaptureMode CaptureMode
        {
            set
            {
                var inXml = string.Format(@"<inArgs><scannerID>1</scannerID></inArgs>");
                string OutXml;
                int status = 0;

                if (value == CaptureMode.Image)
                {
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceCaptureImage, ref inXml, out OutXml, out status);
                }
                else if (value == CaptureMode.Barcode)
                {
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceCaptureBarcode, ref inXml, out OutXml, out status);
                }
                else if (value == CaptureMode.Video)
                {
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceCaptureVideo, ref inXml, out OutXml, out status);
                }
                if (status != 0)
                {
                    throw new ScannerException(string.Format("Failed to set mode to {0}.", value)){ErrorCode = (StatusCode)status};
                }
            }
        }
        #endregion

        #region Attributes
        private Discovery _discovery;
        private SystemEvents _systemEvents;
        private Status _status;
        private Ocr _ocr;
        private Imaging _imaging;
        private Beeper _beeper;
        private LicenseParsing _license;

        public Discovery Discovery
        {
            get { return _discovery ?? (_discovery = new Discovery(ScannerId, _scannerDriver)); }
        }

        public Ocr OCR
        {
            get { return _ocr ?? (_ocr = new Ocr(ScannerId, _scannerDriver)); }
        }

        public SystemEvents Events
        {
            get { return _systemEvents ?? (_systemEvents = new SystemEvents(ScannerId, _scannerDriver)); }
        }

        public Status Status
        {
            get { return _status ?? (_status = new Status(ScannerId, _scannerDriver)); }
        }

        public Imaging Imaging
        {
            get { return _imaging ?? (_imaging = new Imaging(ScannerId, _scannerDriver)); }
        }

        public Beeper Beeper
        {
            get { return _beeper ?? (_beeper = new Beeper(ScannerId, _scannerDriver)); }
        }

        public LicenseParsing License
        {
            get { return _license ?? (_license = new LicenseParsing(ScannerId, _scannerDriver)); }
        }

        #endregion

        //public void EnableLeicaBarcodes()
        //{
        //    _ocr.EnableOcrB = true;
        //    _ocr.Template = "3333 333";
        //    _ocr.ValidCharacters = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    _ocr.Orientation = BarcodeOrientation.Omnidirectional;
        //    _ocr.MinCharacters = 7;
        //    _ocr.MaxCharacters = 9;
        //    _ocr.Lines = 1;
        //    _ocr.SecurityLevel = 70;
        //}

        /// <summary>
        /// Parses scanner info from this scanner's xml. (Usually from GetDevices Method which executes the GetScanners command.)
        /// </summary>
        /// <param name="scannerXml">Xml containing info for this scanner</param>
        private void Parse(XElement scannerXml)
        {
            if ((scannerXml == null) || (scannerXml.IsEmpty))
                throw new InvalidDataException("Xml is empty");

            XAttribute type = scannerXml.Attribute("type");
            var mode = type.Value;
            switch (mode)
            {
                case ("SNAPI"):
                {
                    UsbHostMode = HostMode.USB_SNAPI_Imaging;
                    break;
                }
                case ("USBIBMHID"):
                {
                    UsbHostMode = HostMode.USB_IBMHID;
                    break;
                }
                case ("USBHIDKB"):
                {
                    UsbHostMode = HostMode.USB_HIDKB;
                    break;
                }
                case ("USBIBMTT"):
                {
                    UsbHostMode = HostMode.USB_IBMTT;
                    break;
                }
            }

            XElement scannerId = scannerXml.Element("scannerID");
            if (scannerId != null)
            {
                try
                {
                    ScannerId = Int32.Parse(scannerId.Value);
                }
                catch
                {
                    throw;
                }
            }

            XElement serialNumber = scannerXml.Element("serialnumber");
            if (serialNumber != null)
                SerialNumber = serialNumber.Value.Trim();

            XElement guid = scannerXml.Element("GUID");
            if (guid != null)
            {
                try
                {
                    GUID = Guid.Parse(guid.Value);
                }
                catch
                { }
            }

            XElement vendorId = scannerXml.Element("VID");
            if (vendorId != null)
            {
                try
                {
                    VendorId = Int32.Parse(vendorId.Value);
                }
                catch
                { }
            }

            XElement productId = scannerXml.Element("PID");
            if (productId != null)
            {
                try
                {
                    ProductId = Int32.Parse(productId.Value);
                }
                catch
                { }
            }

            XElement modelNumber = scannerXml.Element("modelnumber");
            if (modelNumber != null)
                ModelNumber = modelNumber.Value.Trim();

            XElement dateOfManufacture = scannerXml.Element("DoM");
            if (dateOfManufacture != null)
                DateOfManufacture = dateOfManufacture.Value.Trim();

            XElement firmware = scannerXml.Element("firmware");
            if (firmware != null)
                Firmware = firmware.Value.Trim();
        }
    }
}