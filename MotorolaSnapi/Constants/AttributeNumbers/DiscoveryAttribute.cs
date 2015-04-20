using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal static class DiscoveryAttribute
    {
        internal const ushort ModelNumber = 533;
        internal const ushort SerialNumber = 534;
        internal const ushort BluetoothAddress = 541;
        internal const ushort DeviceClass = 20007;
        internal const ushort DateOfManufacture = 535;
        internal const ushort LastServiceDate = 536;
        internal const ushort ScannerFirmwareVersion = 20004;
        internal const ushort ScankitVersion = 20008;
        internal const ushort ImagekitVersion = 20013;
        internal const ushort CombinedFirmwareVersion = 20009;
        internal const ushort RSMVersion = 20011;
        internal const ushort DateOfFirstProgramming = 614;
        internal const ushort ConfigurationFilename = 616;

        internal static readonly IEnumerable<ushort> All = new []
                                                {
                                                    ModelNumber,
                                                    SerialNumber,
                                                    BluetoothAddress,
                                                    DeviceClass,
                                                    DateOfManufacture,
                                                    LastServiceDate,
                                                    ScannerFirmwareVersion,
                                                    ScankitVersion,
                                                    ImagekitVersion,
                                                    CombinedFirmwareVersion,
                                                    RSMVersion,
                                                    DateOfFirstProgramming,
                                                    ConfigurationFilename
                                                };
    }
}
