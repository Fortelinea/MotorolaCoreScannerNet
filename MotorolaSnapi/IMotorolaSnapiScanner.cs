using System;

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

        string SerialNumber { get; set; }

        int VendorId { get; set; }
    }
}