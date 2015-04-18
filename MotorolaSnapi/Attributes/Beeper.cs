using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying scanner beeper attributes.
    /// </summary>
    public class Beeper : MotorolaAttributeSet
    {
        /// <summary>
        /// Initializes a Beeper object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Beeper(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: BeeperVolume</para>
        /// <para>Defines the volume level of the beeper.</para>
        /// <para>Values: "Low"(2) "Medium"(1) "High"(0)</para>
        /// </summary>
        public BeeperVolume BeeperVolume
        {
            get { return (BeeperVolume)GetAttribute(BeeperAttribute.BeeperVolume).Value; }
            set
            {
                SetAttribute(new ScannerAttribute { Id = BeeperAttribute.BeeperVolume, DataType = DataType.Byte, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: BeeperVolume</para>
        /// <para>The parameter defines the frequency level set of the beeper.</para>
        /// <para>Values: "Low"(2) "Medium"(1) "High"(0)</para>
        /// </summary>
        public BeeperFrequency BeeperFrequency
        {
            get { return (BeeperFrequency)GetAttribute(BeeperAttribute.BeeperFrequency).Value; }
            set
            {
                SetAttribute(new ScannerAttribute { Id = BeeperAttribute.BeeperFrequency, DataType = DataType.Byte, Value = (byte)value });
            }
        }
    }

}