/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    ///     Controls default settings on your scanner. Can restore defaults and write custom defaults.
    /// </summary>
    public class Defaults
    {
        private readonly CCoreScanner _scannerDriver;

        private readonly int _scannerId;

        private readonly string _setAttributeXml;

        /// <summary>
        ///     Instantiates a new Defaults object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Defaults(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
            _setAttributeXml =
                $@"<inArgs><scannerID>{_scannerId}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{{0}}</id><datatype>{{1}}</datatype><value>{{2}}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>";
        }

        /// <summary>
        ///     Set all attributes to their default values. Uses custom default values if they are set.
        /// </summary>
        public void Restore()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.SetParameterDefaults, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        /// <summary>
        ///     Set all attributes to their default values. Will not use custom default values.
        /// </summary>
        public void RestoreFactory()
        {
            var inXml = string.Format(_setAttributeXml, "X", 1);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        /// <summary>
        ///     Save current settings as the default settings for this scanner.
        /// </summary>
        public void SetCustom()
        {
            var inXml = string.Format(_setAttributeXml, "X", 2);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }
    }
}