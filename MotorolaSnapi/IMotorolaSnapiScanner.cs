using Motorola.Snapi.Commands;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    public interface IMotorolaSnapiScanner
    {
        ScannerInfo Info { get; }

        CaptureMode CaptureMode { set; }

        #region Commands
        void SetHostMode(string mode, bool permanent = false, bool silent = true);
        AccessControl AccessControl { get; }
        Actions Actions { get; }
        Defaults Defaults { get; }
        Firmware Firmware { get; }
        Trigger Trigger { get; }
        MacroPdf MacroPDF { get; }
        #endregion

        #region Attributes
        AttributeSets Attributes { get; }
        #endregion

        void Reboot();
    }
}