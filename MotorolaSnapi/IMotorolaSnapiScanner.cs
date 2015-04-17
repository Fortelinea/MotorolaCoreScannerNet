using System;
using Motorola.Snapi.Attributes;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    public interface IMotorolaSnapiScanner
    {
        #region ScannerInfo
        string DateOfManufacture { get; }

        string Firmware { get; }

        Guid GUID { get; }

        string ModelNumber { get; }

        int ProductId { get; }

        int ScannerId { get; }

        string UsbHostMode { get; }

        string SerialNumber { get; }

        int VendorId { get; }

        CaptureMode CaptureMode { set; }
        #endregion ScannerInfo

        #region Commands
        void SetHostMode(string mode, bool permanent = false, bool silent = true);
        void SetAllDefault();
        #endregion

        #region Attributes
        Discovery Discovery { get; }

        Ocr OCR { get; }

        SystemEvents Events { get; }

        Status Status { get; }

        Imaging Imaging { get; }

        Beeper Beeper { get; }

        LicenseParsing License { get; }

        Adf ADF { get; }

        Synapse Synapse { get; }

        UpcEan UPC_EAN { get; }
        #endregion
    }
}