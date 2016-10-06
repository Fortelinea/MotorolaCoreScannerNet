/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    ///     Beeper and LED control.
    /// </summary>
    public class Actions
    {
        private readonly CCoreScanner _scannerDriver;

        private readonly int _scannerId;

        private readonly string _setAttributeXml;


        /// <summary>
        ///     Instantiates a new Actions object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Actions(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;

            _setAttributeXml =
                $@"<inArgs><scannerID>{_scannerId}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{{0}}</id><datatype>{{1}}</datatype><value>{{2}}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>";

        }

        /// <summary>
        ///     Sound the beeper with the specified pattern.
        /// </summary>
        /// <param name="pattern">Beep pattern.</param>
        public void SoundBeeper(BeepPattern pattern)
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-int>{1}</arg-int></cmdArgs></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId, (int)pattern);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.SetAction, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        public void ToggleLed(LedMode mode)
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-int>{1}</arg-int></cmdArgs></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId, (int)mode);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.SetAction, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        public void SetAttribute(uint attributeNumber, char type, string value)
        {
            var inXml = string.Format(_setAttributeXml, attributeNumber, type, value);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);

        }
        public void SetAttribute(uint attributeNumber, char type, int value)
        {
            this.SetAttribute(attributeNumber, type, value.ToString());
        }
    }

}