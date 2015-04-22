/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// The Synapse buffer attribute contains a proprietary format which stores host configuration. This format is not published however, the contents of this attribute can be copied from a “golden” scanner which has the
    /// correct settings and copied to other devices.
    /// </summary>
    public class Synapse : MotorolaAttributeSet
    {
        /// <summary>
        /// Initializes an Synapse object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Synapse(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>The parameter defines the Host specific
        /// configuration parameters.</para>
        /// <remarks>The Synapse buffer contents are in a proprietary format. They are used by Symbol Utilities to
        /// configure host related configuration changes.</remarks>
        /// </summary>
        public byte[] Value
        {
            get
            {
                return (byte[])GetAttribute((ushort)SynapseAttribute.Synapse).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)SynapseAttribute.Synapse, DataType = DataType.Array, Value = ValueConverters.ByteArrayToHexString(value) });
            }
        }
    }
}
