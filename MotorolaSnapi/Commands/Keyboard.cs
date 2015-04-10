using CoreScanner;
using System;
using System.Linq;
using System.Xml.Linq;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Commands
{
    public class Keyboard
    {
        private ICoreScanner _scannerDriver;

        internal Keyboard(ICoreScanner scannerDriver)
        {
            _scannerDriver = scannerDriver;
        }

        public enum KeyboardLocale
        {
            English = 0,
            French = 1
        }

        public bool EnableEmulation
        {
            get
            {
                string inXml = "<inArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorGetConfig, ref inXml, out outXml, out status);

                XDocument xdoc = XDocument.Parse(outXml);
                XElement keyEnumState = xdoc.Descendants("KeyEnumState").First();
                return Convert.ToBoolean(keyEnumState.Value);
            }
            set
            {
                string inXml = String.Format("<inArgs><cmdArgs><arg-bool>{0}</arg-bool></cmdArgs></inArgs>", value ? "TRUE" : "FALSE");
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorEnable, ref inXml, out outXml, out status);
            }
        }

        public KeyboardLocale Locale
        {
            get
            {
                string inXml = "<inArgs></inArgs>";
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorGetConfig, ref inXml, out outXml, out status);

                XDocument xdoc = XDocument.Parse(outXml);
                XElement keyEnumLocale = xdoc.Descendants("KeyEnumLocale").First();
                return (KeyboardLocale)Convert.ToInt32(keyEnumLocale.Value);
            }
            set
            {
                string inXml = String.Format("<inArgs><cmdArgs><arg-int>{0}</arg-int></cmdArgs></inArgs>", (Int32)value);
                string outXml;
                int status;
                _scannerDriver.ExecCommand((int)ScannerCommand.KeyboardEmulatorEnable, ref inXml, out outXml, out status);
            }
        }
    }
}