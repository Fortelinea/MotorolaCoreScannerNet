using System;
using Motorola.Snapi.Commands;

namespace Motorola.Snapi
{
    public interface IMotorolaSnapiScanner
    {
        string DateOfManufacture { get; set; }

        string Firmware { get; set; }

        Guid GUID { get; set; }

        string ModelNumber { get; set; }

        int ProductId { get; set; }

        int ScannerId { get; set; }

        string UsbHostMode { get; set; }

        string SerialNumber { get; set; }

        int VendorId { get; set; }

        void EnableDataMatrixBarcodes();

        void Initialize();

        void SetHostMode(string mode, bool permanent = false, bool silent = true);
    }
}