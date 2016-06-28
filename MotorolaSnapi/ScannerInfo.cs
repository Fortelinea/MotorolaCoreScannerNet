/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.IO;
using System.Xml.Linq;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi
{
    /// <summary>
    ///     Contains information about this scanner.
    ///     <para>NOTE: If this information was changed you must call get GetDevices() again to update your scanner list.</para>
    /// </summary>
    public class ScannerInfo
    {
        public ScannerInfo(XElement scannerXml) { Parse(scannerXml); }

        /// <summary>
        ///     Date of manufacture.
        /// </summary>
        public string DateOfManufacture { get; private set; }

        /// <summary>
        ///     Asset tracking information of the scanner.
        /// </summary>
        public Guid GUID { get; private set; }

        /// <summary>
        ///     Currently installed firmware.
        ///     <para>
        ///         NOTE: If you updated your firmware after you last called GetDevices, this information will be obsolete. Call
        ///         GetDevices again to update your scanner collection.
        ///     </para>
        /// </summary>
        public string InstalledFirmware { get; private set; }

        /// <summary>
        ///     Scanner model number.
        /// </summary>
        public string ModelNumber { get; private set; }

        /// <summary>
        ///     Product ID.
        /// </summary>
        public int ProductId { get; private set; }

        /// <summary>
        ///     Current scannerID.
        ///     <para>May change on reboot. Call GetScanners again to update.</para>
        /// </summary>
        public int ScannerId { get; private set; }

        /// <summary>
        ///     Unique serial number of the device.
        /// </summary>
        public string SerialNumber { get; private set; }

        /// <summary>
        ///     USB Host mode of the scanner.
        ///     <para>
        ///         NOTE: If you changed the USB host mode after you last called GetDevices, this information will be obsolete.
        ///         Call GetDevices again to update your scanner collection.
        ///     </para>
        /// </summary>
        public string UsbHostMode { get; private set; }

        /// <summary>
        ///     Vendor ID.
        /// </summary>
        public int VendorId { get; private set; }

        /// <summary>
        ///     Parses scanner info from this scanner's xml. (Usually from GetDevices Method which executes the GetScanners
        ///     command.)
        ///     <para>NOTE: If this information was changed you must call get GetDevices() again to update your scanner list.</para>
        /// </summary>
        /// <param name="scannerXml">Xml containing info for this scanner</param>
        private void Parse(XElement scannerXml)
        {
            if ((scannerXml == null) || scannerXml.IsEmpty)
                throw new InvalidDataException("Xml is empty");

            ParseHostMode(scannerXml);

            ParseId(scannerXml);

            ParseSerialNumber(scannerXml);

            ParseGuid(scannerXml);

            ParseVid(scannerXml);

            ParsePid(scannerXml);

            ParseModelNumber(scannerXml);

            ParseDateOfManufacture(scannerXml);

            ParseFirmware(scannerXml);
        }

        private void ParseDateOfManufacture(XElement scannerXml)
        {
            var dateOfManufacture = scannerXml.Element("DoM");
            if (dateOfManufacture != null)
                DateOfManufacture = dateOfManufacture.Value.Trim();
        }

        private void ParseFirmware(XElement scannerXml)
        {
            var firmware = scannerXml.Element("firmware");
            if (firmware != null)
                InstalledFirmware = firmware.Value.Trim();
        }

        private void ParseGuid(XElement scannerXml)
        {
            var guid = scannerXml.Element("GUID");
            if (guid != null)
            {
                try
                {
                    GUID = Guid.Parse(guid.Value);
                }
                catch { }
            }
        }

        private void ParseHostMode(XElement scannerXml)
        {
            var type = scannerXml.Attribute("type");
            var mode = type.Value;
            switch (mode)
            {
                case "SNAPI":
                {
                    UsbHostMode = HostMode.USB_SNAPI_Imaging;
                    break;
                }
                case "USBIBMHID":
                {
                    UsbHostMode = HostMode.USB_IBMHID;
                    break;
                }
                case "USBHIDKB":
                {
                    UsbHostMode = HostMode.USB_HIDKB;
                    break;
                }
                case "USBIBMTT":
                {
                    UsbHostMode = HostMode.USB_IBMTT;
                    break;
                }
            }
        }

        private void ParseId(XElement scannerXml)
        {
            var scannerId = scannerXml.Element("scannerID");
            if (scannerId != null)
            {
                try
                {
                    ScannerId = int.Parse(scannerId.Value);
                }
                catch
                {
                    throw;
                }
            }
        }

        private void ParseModelNumber(XElement scannerXml)
        {
            var modelNumber = scannerXml.Element("modelnumber");
            if (modelNumber != null)
                ModelNumber = modelNumber.Value.Trim();
        }

        private void ParsePid(XElement scannerXml)
        {
            var productId = scannerXml.Element("PID");
            if (productId != null)
            {
                try
                {
                    ProductId = int.Parse(productId.Value);
                }
                catch { }
            }
        }

        private void ParseSerialNumber(XElement scannerXml)
        {
            var serialNumber = scannerXml.Element("serialnumber");
            if (serialNumber != null)
                SerialNumber = serialNumber.Value.Trim();
        }

        private void ParseVid(XElement scannerXml)
        {
            var vendorId = scannerXml.Element("VID");
            if (vendorId != null)
            {
                try
                {
                    VendorId = int.Parse(vendorId.Value);
                }
                catch { }
            }
        }
    }
}