using System.Collections.Generic;

namespace Motorola.Snapi.Constants
{
    public static class DiscoveryAttribute
    {
        public static ushort ModelNumber = 533;
        public static ushort SerialNumber = 534;
        public static ushort BluetoothAddress = 541;
        public static ushort DeviceClass = 20007;
        public static ushort DateOfManufacture = 535;
        public static ushort LastServiceDate = 536;
        public static ushort ScannerFirmwareVersion = 20004;
        public static ushort ScankitVersion = 20008;
        public static ushort ImagekitVersion = 20013;
        public static ushort CombinedFirmwareVersion = 20009;
        public static ushort RSMVersion = 20011;
        public static ushort DateOfFirstProgramming = 614;
        public static ushort ConfigurationFilename = 616;

        public static IEnumerable<ushort> All = new ushort[]
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
