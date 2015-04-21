using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing status attributes of cordless scanners.
    /// </summary>
    public class Status : MotorolaAttributeSet 
    {
        /// <summary>
        /// Initializes a SystemEvents object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Status(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        /// <para>Driver Attribute Name: InCradleDetect</para>
        /// <para>Indicates if the cordless scanner is inserted in the cradle.</para>
        /// <para>Values: "In Cradle"(true) "Out of Cradle"(false)</para>
        /// </summary>
        public bool InCradle
        {
            get
            {
                var scannerAttribute = GetAttribute((ushort)StatusAttribute.InCradleDetect);
                if (scannerAttribute != null)
                {
                    return (bool)scannerAttribute.Value;   
                }
                return false;
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: OperationalMode</para>
        /// <para>Indicates if the device is being used in ScanStand.</para>
        /// <para>Values: “Handsfree”(true) “Handheld”(false)</para>
        /// </summary>
        public bool IsHandsfree
        {
            get
            {
                var scannerAttribute = GetAttribute((ushort)StatusAttribute.OperationalMode);
                if (scannerAttribute != null)
                {
                    return (bool)scannerAttribute.Value;
                }
                return false;
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Charging</para>
        /// <para>Indicates if the device is charging.</para>
        /// <para>Values: "false" "true"</para>
        /// </summary>
        public bool Charging
        {
            get
            {
                var scannerAttribute = GetAttribute((ushort)StatusAttribute.Charging);
                if (scannerAttribute != null)
                {
                    return (bool)scannerAttribute.Value;
                }
                return false;
            }
        }
    }
}