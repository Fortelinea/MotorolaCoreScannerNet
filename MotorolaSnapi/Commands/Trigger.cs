/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using System;
using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    /// Represents a virtual trigger. Contains commands for pulling and releasing the trigger.
    /// Must set TriggerByCommand to true to begin using.
    /// </summary>
    public class Trigger {
        private readonly CCoreScanner _scannerDriver;
        private readonly int _scannerId;
        internal Trigger(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
        }

        /// <summary>
        /// Virtualy pull the trigger of this scanner
        /// </summary>
        public void PullTrigger()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            string inXml = String.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DevicePullTrigger, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Trigger pull failed") { ErrorCode = (StatusCode)status };
        }

        /// <summary>
        /// Virtualy release the trigger of this scanner
        /// </summary>
        public void ReleaseTrigger()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            string inXml = String.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.DeviceReleaseTrigger, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Trigger pull failed") { ErrorCode = (StatusCode)status };
        }

        /// <summary>
        /// Set to true to control scanning with commands. To stop, set to false.
        /// </summary>
        public bool TriggerByCommand
        {
            set 
            {
                if (value)
                {
                    string setAttributeXml = string.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", _scannerId, @"{0}", @"{1}", @"{2}");
                    string inXml = string.Format(setAttributeXml, "X", 0);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
                    if (status != 0)
                        throw new ScannerException("Set all defaults failed") { ErrorCode = (StatusCode)status };
                }
                else
                {
                    string setAttributeXml = string.Format(@"<inArgs><scannerID>{0}</scannerID><cmdArgs><arg-xml><attrib_list><attribute><id>{1}</id><datatype>{2}</datatype><value>{3}</value></attribute></attrib_list></arg-xml></cmdArgs></inArgs>", _scannerId, @"{0}", @"{1}", @"{2}");
                    string inXml = string.Format(setAttributeXml, "X", 1);
                    string outXml;
                    int status;
                    _scannerDriver.ExecCommand((int)ScannerCommand.DeviceSetParameters, ref inXml, out outXml, out status);
                    if (status != 0)
                        throw new ScannerException("Set all defaults failed") { ErrorCode = (StatusCode)status };
                }
            }
        }
    }
}