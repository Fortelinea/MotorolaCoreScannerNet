/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.IO;
using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    ///     Firmware related commands.
    /// </summary>
    public class Firmware
    {
        private readonly CCoreScanner _scannerDriver;

        private readonly int _scannerId;

        /// <summary>
        ///     Instantiates a new Firmware object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Firmware(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
        }

        /// <summary>
        ///     Abort Firmware update process of a specified scanner while it is progressing.
        ///     WARNING! If the scanner’s firmware is not backup protected, issuing this command during a firmware update may cause
        ///     a corruption leaving the scanner inoperable.
        /// </summary>
        public void AbortFirmwareUpdate()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.AbortUpdateFirmware, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        /// <summary>
        ///     Start the updated firmware. This causes a reboot of the specified scanner.
        /// </summary>
        public void StartNewFirmware()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.StartNewFirmware, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        /// <summary>
        ///     Update the firmware of the specified scanner. A user can specify the bulk firmware update option for faster
        ///     firmware download in SNAPI mode.
        ///     If an application registered for ScanRMDEvents, it receives ScanRMDEvents as described.
        /// </summary>
        /// <param name="firmwarePath">Path to new firmware file.</param>
        /// <param name="mode">Update mode</param>
        public void UpdateFirmware(string firmwarePath, UpdateMode mode)
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-string>{1}</arg-string><arg-int>{2}</arg-int></cmdArgs></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId, firmwarePath, (int)mode);
            string outXml;
            int status;
            var extension = Path.GetExtension(firmwarePath);
            if ((extension != null) && string.Equals(extension, ".dat", StringComparison.OrdinalIgnoreCase))
                _scannerDriver.ExecCommand((int)ScannerCommand.UpdateFirmware, ref inXml, out outXml, out status);
            else if ((extension != null) && string.Equals(extension, ".scnplg", StringComparison.OrdinalIgnoreCase))
                _scannerDriver.ExecCommand((int)ScannerCommand.UpdateFirmwareFromPlugin, ref inXml, out outXml, out status);
            else
                throw new ArgumentOutOfRangeException("Firmware files should have the extension \".dat\" and plugin files should have the extension \".scnplg\"");
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }
    }
}