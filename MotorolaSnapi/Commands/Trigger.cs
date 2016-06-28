/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    ///     Represents a virtual trigger. Contains commands for pulling and releasing the trigger.
    ///     Must set TriggerByCommand to true to begin using.
    /// </summary>
    public class Trigger
    {
        private readonly CCoreScanner _scannerDriver;

        private readonly int _scannerId;

        private readonly string _setAttributeXml;

        internal Trigger(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
            _setAttributeXml =
                $@"<inArgs><scannerID>{_scannerId}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{{0}}</id><datatype>{{1}}</datatype><value>{{2}}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>";
        }

        /// <summary>
        ///     Set to true to control scanning with commands. To stop, set to false.
        /// </summary>
        public bool TriggerByCommand
        {
            set
            {
                if (value)
                {
                    var inXml = string.Format(_setAttributeXml, "X", 0);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
                    var s = (StatusCode)status;
                    if (s != StatusCode.Success)
                        throw new ScannerException(s);
                }
                else
                {
                    var inXml = string.Format(_setAttributeXml, "X", 1);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
                    var s = (StatusCode)status;
                    if (s != StatusCode.Success)
                        throw new ScannerException(s);
                }
            }
        }

        /// <summary>
        ///     Virtualy pull the trigger of this scanner
        /// </summary>
        public void PullTrigger()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DevicePullTrigger, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }

        /// <summary>
        ///     Virtualy release the trigger of this scanner
        /// </summary>
        public void ReleaseTrigger()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            var inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceReleaseTrigger, ref inXml, out outXml, out status);
            var s = (StatusCode)status;
            if (s != StatusCode.Success)
                throw new ScannerException(s);
        }
    }
}