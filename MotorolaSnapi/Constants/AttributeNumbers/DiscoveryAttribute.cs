using System.Collections.Generic;

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    public static class DiscoveryAttribute
    {
        public const ushort ModelNumber = 533;
        public const ushort SerialNumber = 534;
        public const ushort BluetoothAddress = 541;
        public const ushort DeviceClass = 20007;
        public const ushort DateOfManufacture = 535;
        public const ushort LastServiceDate = 536;
        public const ushort ScannerFirmwareVersion = 20004;
        public const ushort ScankitVersion = 20008;
        public const ushort ImagekitVersion = 20013;
        public const ushort CombinedFirmwareVersion = 20009;
        public const ushort RSMVersion = 20011;
        public const ushort DateOfFirstProgramming = 614;
        public const ushort ConfigurationFilename = 616;

        public static readonly IEnumerable<ushort> All = new []
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
