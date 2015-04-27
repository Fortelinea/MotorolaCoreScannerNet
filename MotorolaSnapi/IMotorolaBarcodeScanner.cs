/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using Motorola.Snapi.Attributes;
using Motorola.Snapi.Commands;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    public interface IMotorolaBarcodeScanner
    {
        ScannerInfo Info { get; }
        CaptureMode CaptureMode { set; }
        void Reboot();

        #region Commands

        void SetHostMode(string mode, bool permanent = false, bool silent = true);
        AccessControl AccessControl { get; }
        Actions Actions { get; }
        Defaults Defaults { get; }
        Firmware Firmware { get; }
        Trigger Trigger { get; }
        MacroPdf MacroPDF { get; }

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

        Code128 Code128 { get; }

        Code39 Code39 { get; }

        Code93 Code93 { get; }

        Code11 Code11 { get; }

        Interleaved2Of5 Interleaved2Of5 { get; }

        Discrete2Of5 Discrete2Of5 { get; }

        Chinese2Of5 Chinese2Of5 { get; }

        Codabar Codabar { get; }

        Msi MSI { get; }

        RssGs1Databar RssGs1Databar { get; }

        Code32 Code32 { get; }

        SymbologySecurity SymbologySecurity { get; }

        Pdf PDF { get; }

        DataMatrixQr DataMatrixQR { get; }

        Maxicode Maxicode { get; }

        Postal Postal { get; }

        SignatureCapture SignatureCapture { get; }

        #endregion
    }
}