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
    public partial class BarcodeScanner : IMotorolaBarcodeScanner
    {

        private readonly CCoreScanner _scannerDriver;

        internal BarcodeScanner(CCoreScanner scannerDriver, XElement scannerXml)
        {
            _scannerDriver = scannerDriver;
            Info = new ScannerInfo(scannerXml);
        }

        #region Commands

        private MacroPdf _macroPdf;

        public MacroPdf MacroPDF => _macroPdf ?? (_macroPdf = new MacroPdf(_scannerDriver, Info.ScannerId));

        private Actions _actions;

        public Actions Actions => _actions ?? (_actions = new Actions(_scannerDriver, Info.ScannerId));

        private Defaults _defaults;

        public Defaults Defaults => _defaults ?? (_defaults = new Defaults(_scannerDriver, Info.ScannerId));

        private Firmware _firmware;

        public Firmware Firmware => _firmware ?? (_firmware = new Firmware(_scannerDriver, Info.ScannerId));

        private AccessControl _accessControl;

        /// <summary>
        ///     Commands for claiming and releasing this device.
        /// </summary>
        public AccessControl AccessControl => _accessControl ?? (_accessControl = new AccessControl(_scannerDriver, Info.ScannerId));

        private Trigger _trigger;

        /// <summary>
        ///     Represents a vitural trigger.
        /// </summary>
        public Trigger Trigger => _trigger ?? (_trigger = new Trigger(_scannerDriver, Info.ScannerId));

        /// <summary>
        ///     Change the USB host mode of the scanner.
        /// </summary>
        /// <param name="mode">Host mode code</param>
        /// <param name="permanent">Keep in this mode after power cycle.</param>
        /// <param name="silent">Change modes silently (No beep)</param>
        public void SetHostMode(string mode, bool permanent = false, bool silent = true)
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-string>{1}</arg-string><arg-bool>{2}</arg-bool><arg-bool>{3}</arg-bool></cmdArgs></inArgs>";
            var inXml = string.Format(setCommandXml, Info.ScannerId, mode, silent ? "TRUE" : "FALSE", permanent ? "TRUE" : "FALSE");
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSwitchHostMode, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        /// <summary>
        ///     Turn the aim of this scanner on or off
        /// </summary>
        public bool AimEnabled
        {
            set
            {
                if (value)
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    var inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.AimOn, ref inXml, out outXml, out status);
                    var s = (StatusCode)status;
                    if (s != StatusCode.Success)
                        throw new ScannerException(s);
                }
                else
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    var inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.AimOff, ref inXml, out outXml, out status);
                    var s = (StatusCode)status;
                    if (s != StatusCode.Success)
                        throw new ScannerException(s);
                }
            }
        }

        /// <summary>
        ///     Enable or disable scanning
        /// </summary>
        public bool ScanningEnabled
        {
            set
            {
                if (value)
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    var inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.ScanEnable, ref inXml, out outXml, out status);
                    var s = (StatusCode)status;
                    if (s != StatusCode.Success)
                        throw new ScannerException(s);
                }
                else
                {
                    const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
                    var inXml = string.Format(setCommandXml, Info.ScannerId);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.ScanDisable, ref inXml, out outXml, out status);
                    var s = (StatusCode)status;
                    if (s != StatusCode.Success)
                        throw new ScannerException(s);
                }
            }
        }

        /// <summary>
        ///     Reboot the scanner
        /// </summary>
        public void Reboot()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, Info.ScannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.RebootScanner, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        #endregion

        #region ScannerInfo

        public ScannerInfo Info { get; }

        public CaptureMode CaptureMode
        {
            set
            {
                var inXml = @"<inArgs><scannerID>1</scannerID></inArgs>";
                string outXml;
                var status = 0;

                if (value == CaptureMode.Image)
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceCaptureImage, ref inXml, out outXml, out status);
                else if (value == CaptureMode.Barcode)
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceCaptureBarcode, ref inXml, out outXml, out status);
                else if (value == CaptureMode.Video)
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceCaptureVideo, ref inXml, out outXml, out status);
                var s = (StatusCode)status;
                if (s != StatusCode.Success)
                    throw new ScannerException(s);
            }
        }

        #endregion
    }

}