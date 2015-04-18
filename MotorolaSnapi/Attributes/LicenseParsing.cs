using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// <para>Provides properties for accessing and modifying Driver License Parsing attributes.</para>
    /// <remarks>Notes: DL parsing rules are in a proprietary format. End users wishing to deploy DL parsing rules should first manually
    /// program the scanner using programming bar codes and then reading the attribute from the application. The rules can then be
    /// deployed to other scanners in the enterprise.</remarks> 
    /// </summary>
    public class LicenseParsing : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a DLParsing object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal LicenseParsing(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Number: DLParseMode</para>
        /// <para>This parameter specifies a Driver’s License parsing Mode. It can be disabled,
        /// set to Embedded driver’s license parsing (does not require Motorola software on
        /// the host) or set to Server Based driver’slicense parsing (requires Motorola software on the host).</para>
        /// <para>Values: Parsing Off (0), Parse w Embedded Software (1), Encrypt then send to host (2)</para>
        /// </summary>
        public LicenseParseMode LicenseParseMode
        {
            get
            {
                var attribute = GetAttribute(LicenseParsingAttribute.DLParseMode);
                if (attribute != null)
                    return (LicenseParseMode)Convert.ToUInt16(attribute.Value);
                return LicenseParseMode.NA;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = LicenseParsingAttribute.DLParseMode, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Number: DLParseBuffer</para>
        /// <para>The buffer containing the DL parse rules.</para>
        /// <para>Notes: DL parsing rules are in a proprietary format. End users wishing to deploy DL parsing rules should first manually
        /// program the scanner using programming bar codes and then reading the attribute from the application. The rules can then be
        /// deployed to other scanners in the enterprise.</para>
        /// </summary>
        public byte[] LicenseParseBuffer
        {
            get
            {
                var attribute = GetAttribute(LicenseParsingAttribute.DLParseBuffer);
                if (attribute != null)
                    return (byte[])attribute.Value;
                return null;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = LicenseParsingAttribute.DLParseMode, DataType = DataType.Array, Value = ValueConverters.ByteArrayToHexString(value) });
            }
        }
    }
}
