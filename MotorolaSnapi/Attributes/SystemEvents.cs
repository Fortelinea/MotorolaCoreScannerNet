using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying SystemEvents attributes.
    /// These apply only to  SSI RS232 mode.
    /// </summary>
    public class SystemEvents : MotorolaAttributeSet
    {
        /// <summary>
        /// Initializes a SystemEvents object containing the current values of all System Event attributes for a given scanner.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal SystemEvents(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver){}

        /// <summary>
        /// <para>Driver Attribute Name: DecodeEvent</para>
        /// <para>Description: When enabled, the scanner generates a message
        /// to the host whenever a bar code is successfully
        /// decoded. When disabled, no notification is sent</para>
        /// <para>Values: "On" (true), "Off" (false)</para>
        /// </summary>
        public bool DecodeEventEnabled
        {
            get
            {
                return (bool)GetAttribute(SystemEventAttribute.DecodeEvent)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = SystemEventAttribute.DecodeEvent, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: BootupEvent</para>
        /// <para>Description: When enabled, the scanner generates a message to the host
        /// whenever power is applied. When disabled, no notification is sent</para>
        /// <para>Values: "On" (true), "Off" (false)</para>
        /// </summary>
        public bool BootupEventEnabled
        {
            get
            {
                return (bool)GetAttribute(SystemEventAttribute.BootupEvent)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = SystemEventAttribute.BootupEvent, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ParamEvent</para>
        /// <para>Description: When enabled, the scanner generates a message
        /// to the host when a parameter is changed.</para>
        /// <para>Values: "On" (true), "Off" (false)</para>
        /// </summary>
        public bool ParamEventEnabled
        {
            get
            {
                return (bool)GetAttribute(SystemEventAttribute.ParamEvent)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = SystemEventAttribute.ParamEvent, DataType = DataType.Bool, Value = value });
            }
        }
    }
}