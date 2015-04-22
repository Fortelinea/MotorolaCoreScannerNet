/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using System.Xml.Linq;
using CoreScanner;
using Motorola.Snapi.Commands;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    public partial class BarcodeScanner : IMotorolaSnapiScanner
    {
        private readonly CCoreScanner _scannerDriver;
        private readonly ScannerInfo _info;


        internal BarcodeScanner(CCoreScanner scannerDriver, XElement scannerXml)
        {
            _scannerDriver = scannerDriver;
            _info = new ScannerInfo(scannerXml);
        }

        #region Commands
        private MacroPdf _macroPdf;
        public MacroPdf MacroPDF { get { return _macroPdf ?? (_macroPdf = new MacroPdf(_scannerDriver, Info.ScannerId)); } }
        private Actions _actions;
        public Actions Actions { get { return _actions ?? (_actions = new Actions(_scannerDriver, Info.ScannerId)); } }
        private Defaults _defaults;
        public Defaults Defaults { get { return _defaults ?? (_defaults = new Defaults(_scannerDriver, Info.ScannerId)); } }
        private Firmware _firmware;
        public Firmware Firmware { get { return _firmware ?? (_firmware = new Firmware(_scannerDriver, Info.ScannerId)); } }
        private AccessControl _accessControl;
        /// <summary>
        /// Commands for claiming and releasing this device.
        /// </summary>
        public AccessControl AccessControl { get { return _accessControl ?? (_accessControl = new AccessControl(_scannerDriver, Info.ScannerId)); } }
        private Trigger _trigger;
        /// <summary>
        /// Represents a vitural trigger.
        /// </summary>
        public Trigger Trigger { get { return _trigger ?? (_trigger = new Trigger(_scannerDriver, Info.ScannerId)); } }
        /// <summary>
        /// Change the USB host mode of the scanner.
        /// </summary>
        /// <param name="mode">Host mode code</param>
        /// <param name="permanent">Keep in this mode after power cycle.</param>
        /// <param name="silent">Change modes silently (No beep)</param>
        public void SetHostMode(string mode, bool permanent = false, bool silent = true)
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-string>{1}</arg-string><arg-bool>{2}</arg-bool><arg-bool>{3}</arg-bool></cmdArgs></inArgs>";
            string inXml = string.Format(setCommandXml, Info.ScannerId, mode, silent ? "TRUE" : "FALSE", permanent ? "TRUE" : "FALSE");
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSwitchHostMode, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException{ErrorCode = (StatusCode)status};
        }

        /// <summary>
        /// Turn the aim of this scanner on or off
        /// </summary>
        public bool AimEnabled
        {
            set
            {
                if (value)
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    string inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.AimOn, ref inXml, out outXml, out status);
                    if (status != 0)
                        throw new ScannerException("Abort firmware update failed") {ErrorCode = (StatusCode)status};
                }
                else
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    string inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.AimOff, ref inXml, out outXml, out status);
                    if (status != 0)
                        throw new ScannerException("Aim set failed") { ErrorCode = (StatusCode)status };
                }
            }
        }


        /// <summary>
        /// Enable or disable scanning
        /// </summary>
        public bool ScanningEnabled
        {
            set
            {
                if (value)
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    string inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.ScanEnable, ref inXml, out outXml, out status);
                    if (status != 0)
                        throw new ScannerException("Abort firmware update failed") { ErrorCode = (StatusCode)status };
                }
                else
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    string inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.ScanDisable, ref inXml, out outXml, out status);
                    if (status != 0)
                        throw new ScannerException("Aim set failed") { ErrorCode = (StatusCode)status };
                }
            }
        }

        /// <summary>
        /// Reboot the scanner
        /// </summary>
        public void Reboot()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            string inXml = string.Format(setCommandXml, Info.ScannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.RebootScanner, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Reboot command failed") { ErrorCode = (StatusCode)status };
        }
        #endregion

        #region ScannerInfo
        public ScannerInfo Info { get { return _info; } }

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

    }

}