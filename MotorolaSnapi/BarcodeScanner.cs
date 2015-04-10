using CoreScanner;
using Motorola.Snapi.Attributes;
using Motorola.Snapi.Enums;
using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;

namespace Motorola.Snapi
{
    public class BarcodeScanner : IMotorolaSnapiScanner
    {
        private Ocr _ocr;
        private ICoreScanner _scannerDriver;

        internal BarcodeScanner(ICoreScanner scannerDriver, XElement scannerXml)
        {
            _scannerDriver = scannerDriver;
            Parse(scannerXml);
            _ocr = new Ocr(ScannerId, _scannerDriver);
        }

        public enum ScannerHostMode : uint
        {
            [Description("XUA-45001-1")]
            IbmHid = 1,

            [Description("XUA-45001-2")]
            IbmTt = 2,

            [Description("XUA-45001-3")]
            HidKb = 3,

            [Description("XUA-45001-8")]
            OPOS = 8,

            [Description("XUA-45001-9")]
            SNAPI = 9,

            [Description("XUA-45001-10")]
            SnapiWithoutImaging = 10,

            [Description("XUA-45001-11")]
            CdcSerialEmulation = 11
        }

        public string DateOfManufacture { get; set; }

        public string Firmware { get; set; }

        public Guid GUID { get; set; }

        public ScannerHostMode HostMode
        {
            set
            {
                // The TRUE is for silent change, the FALSE is for permanent change
                var inXml = String.Format(
                    @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-string>XUA-45001-{1}</arg-string><arg-bool>TRUE</arg-bool><arg-bool>FALSE</arg-bool></cmdArgs></inArgs>", ScannerId, (int)value);
                string outXml;
                int status;

                _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSwitchHostMode, ref inXml, out outXml, out status);
            }
        }

        public string ModelNumber { get; set; }

        public Ocr Ocr
        {
            get { return _ocr; }
        }

        public int ProductId { get; set; }

        public int ScannerId { get; set; }

        public string SerialNumber { get; set; }

        public int VendorId { get; set; }

        public void EnableDataMatrixBarcodes()
        {
            //TODO Implement
        }

        public void EnableLeicaBarcodes()
        {
            _ocr.EnableOcrB = true;
            _ocr.Template = "3333 333";
            _ocr.ValidCharacters = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            _ocr.Orientation = BarcodeOrientation.Omnidirectional;
            _ocr.MinCharacters = 7;
            _ocr.MaxCharacters = 9;
            _ocr.Lines = 1;
            _ocr.SecurityLevel = 70;
        }

        private void Parse(XElement scannerXml)
        {
            if ((scannerXml == null) || (scannerXml.IsEmpty))
                throw new InvalidDataException("Xml is empty");

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