/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.Linq;
using System.Xml.Linq;
using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    ///     Keyboard emulation control.
    /// </summary>
    public class Keyboard
    {
        #region KeyboardLocale enum

        public enum KeyboardLocale
        {
            English = 0,

            French = 1
        }

        #endregion

        private readonly CCoreScanner _scannerDriver;

        /// <summary>
        ///     Initializes a Keyboard object.
        /// </summary>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Keyboard(CCoreScanner scannerDriver) { _scannerDriver = scannerDriver; }

        /// <summary>
        ///     True if keyboard emulation is enabled.
        /// </summary>
        public bool EnableEmulation
        {
            get
            {
                var inXml = "<inArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorGetConfig, ref inXml, out outXml, out status);

                var xdoc = XDocument.Parse(outXml);
                var keyEnumState = xdoc.Descendants("KeyEnumState").First();
                return Convert.ToBoolean(keyEnumState.Value);
            }
            set
            {
                var inXml = $"<inArgs><cmdArgs><arg-bool>{(value ? "TRUE" : "FALSE")}</arg-bool></cmdArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorEnable, ref inXml, out outXml, out status);
            }
        }

        /// <summary>
        ///     Keyboard Locale
        /// </summary>
        public KeyboardLocale Locale
        {
            get
            {
                var inXml = "<inArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorGetConfig, ref inXml, out outXml, out status);

                var xdoc = XDocument.Parse(outXml);
                var keyEnumLocale = xdoc.Descendants("KeyEnumLocale").First();
                return (KeyboardLocale)Convert.ToInt32(keyEnumLocale.Value);
            }
            set
            {
                var inXml = $"<inArgs><cmdArgs><arg-int>{(int)value}</arg-int></cmdArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorEnable, ref inXml, out outXml, out status);
            }
        }
    }
}