/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    ///     Access Control commands.
    /// </summary>
    public class AccessControl
    {
        private readonly CCoreScanner _scannerDriver;

        private readonly int _scannerId;

        /// <summary>
        ///     Instantiates a new AccessControl object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal AccessControl(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
        }

        /// <summary>
        ///     Claim this device.
        /// </summary>
        public void Claim()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.ClaimDevice, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        /// <summary>
        ///     Release this device.
        /// </summary>
        public void Release()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.ReleaseDevice, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }
    }
}