using System;
using Motorola.Snapi.Attributes;

namespace Motorola.Snapi
{
    public interface IMotorolaSnapiScanner
    {
        string DateOfManufacture { get; }

        string Firmware { get; }

        Guid GUID { get; }

        string ModelNumber { get; }

        int ProductId { get; }

        int ScannerId { get; }

        string UsbHostMode { get; }

        string SerialNumber { get; }

        int VendorId { get; }

        void EnableDataMatrixBarcodes();

        void Initialize();

        void SetHostMode(string mode, bool permanent = false, bool silent = true);

        Discovery Discovery { get; }

        Ocr OCR { get; }

        SystemEvents Events { get; }

        Status Status { get; }
    }
}