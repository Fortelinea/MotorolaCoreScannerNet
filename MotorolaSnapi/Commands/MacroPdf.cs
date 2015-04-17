using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Commands
{
    /// <summary>
    /// MacroPDF commands.
    /// </summary>
    public class MacroPdf
    {
        private readonly CCoreScanner _scannerDriver;
        private readonly int _scannerId;
        /// <summary>
        /// Instantiates a new MacroPdf object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal MacroPdf(CCoreScanner scannerDriver, int scannerId)
        {
            _scannerDriver = scannerDriver;
            _scannerId = scannerId;
        }

        /// <summary>
        /// Flush MacroPDF buffer of this scanner
        /// </summary>
        public void Flush()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            string inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.FlushMacroPdf, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("MacroPDF flush failed") { ErrorCode = (StatusCode)status };
        }

        /// <summary>
        /// Abort MacroPDF continuous read.
        /// </summary>
        public void Abort()
        {
            const string setCommandXml = @"<inArgs><scannerID>{0}</scannerID></inArgs>";
            string inXml = string.Format(setCommandXml, _scannerId);
            string outXml;
            int status;
            _scannerDriver.ExecCommand((int)ScannerCommand.AbortMacroPdf, ref inXml, out outXml, out status);
            if (status != 0)
                throw new ScannerException("Abort MacroPDF failed") { ErrorCode = (StatusCode)status };
        }
    }
}