using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorola.Snapi.Constants
{
    public enum DiscoveryAttribute : ushort
    {
        ModelNumber = 533,
        SerialNumber = 534,
        BluetoothAddress = 541,
        DeviceClass = 20007,
        DateOfManufacture = 535,
        LastServiceDate = 536,
        ScannerFirmwareVersion = 20004,
        ScankitVersion = 20008,
        ImagekitVersion = 20013,
        CombinedFirmwareVersion = 20009,
        RSMVersion = 20011,
        DateOfFirstProgramming = 614,
        ConfigurationFilename = 616
    }
}
