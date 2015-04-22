/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    /// Controls default settings on your scanner. Can restore defaults and write custom defaults.
    /// </summary>
    public class Defaults
    {
        private readonly CCoreScanner _scannerDriver;
        private readonly int _scannerId;

        /// <summary>
        /// Instantiates a new Defaults object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Defaults(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
        }

        /// <summary>
        /// Set all attributes to their default values. Uses custom default values if they are set.
        /// </summary>
        public void Restore()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            string inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.SetParameterDefaults, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Set all defaults failed") { ErrorCode = (StatusCode)status };
        }

        /// <summary>
        /// Set all attributes to their default values. Will not use custom default values.
        /// </summary>
        public void RestoreFactory()
        {
            string setAttributeXml = string.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", _scannerId, @"{0}", @"{1}", @"{2}");
            string inXml = string.Format(setAttributeXml, "X", 1);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Set all defaults failed") { ErrorCode = (StatusCode)status };
        }

        /// <summary>
        /// Save current settings as the default settings for this scanner.
        /// </summary>
        public void SetCustom()
        {
            string setAttributeXml = string.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", _scannerId, @"{0}", @"{1}", @"{2}");
            string inXml = string.Format(setAttributeXml, "X", 2);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Set all defaults failed") { ErrorCode = (StatusCode)status };
        }
    }
}