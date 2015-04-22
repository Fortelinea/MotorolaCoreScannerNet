/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    /// Beeper and LED control.
    /// </summary>
    public class Actions
    {
        private readonly CCoreScanner _scannerDriver;
        private readonly int _scannerId;

        /// <summary>
        /// Instantiates a new Actions object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Actions(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
        }

        /// <summary>
        /// Sound the beeper with the specified pattern.
        /// </summary>
        /// <param name="pattern">Beep pattern.</param>
        public void SoundBeeper(BeepPattern pattern)
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-int>{1}</arg-int></cmdArgs></inArgs>";
            string inXml = string.Format(setCommandXml, _scannerId, (int)pattern);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.SetAction, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Sound beeper command failed") { ErrorCode = (StatusCode)status };
        }

        public void ToggleLed(LedMode mode)
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-int>{1}</arg-int></cmdArgs></inArgs>";
            string inXml = string.Format(setCommandXml, _scannerId, (int)mode);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.SetAction, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Toggle led command failed") { ErrorCode = (StatusCode)status };
        }
    }

}
