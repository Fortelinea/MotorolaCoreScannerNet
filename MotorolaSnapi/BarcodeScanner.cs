using CoreScanner;
using Motorola.Snapi.Attributes;
using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using Motorola.Snapi.Constants;

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
            SetHostMode(HostMode.USB_SNAPI_Imaging);
            _ocr = new Ocr(ScannerId, _scannerDriver);
        }


        public int SetHostMode(string mode, bool permanent = false, bool silent = true)
        {
            string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-string>{1}</arg-string><arg-bool>{2}</arg-bool><arg-bool>{3}</arg-bool></cmdArgs></inArgs>";
            string inXml = string.Format(setCommandXml, ScannerId, mode, silent ? "TRUE" : "FALSE", permanent ? "TRUE" : "FALSE");
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSwitchHostMode, ref inXml, out outXml, out status);
            return status;
        }

        public string DateOfManufacture { get; set; }

        public string Firmware { get; set; }

        public Guid GUID { get; set; }

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