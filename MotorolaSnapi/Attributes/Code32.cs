/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using Interop.CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing Code32 barcode attributes.
    /// </summary>
    public class Code32 : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Code32 object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Code32(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        /// <para>Driver Attribute Name: Code32</para>
        /// <para>This parameter enables the decoding of Code32.</para>
        /// </summary>
        public bool Code32Enabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Code32Attribute.Code32)
                                 .Value;
            }
            set { SetAttribute(new ScannerAttribute {Id = (ushort)Code32Attribute.Code32, DataType = DataType.Bool, Value = value}); }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Code32Prefix</para>
        /// <para>This parameter enables the decoding of This parameter enables the Code32 Prefix.</para>
        /// </summary>
        public bool Code32Prefix
        {
            get
            {
                return (bool)GetAttribute((ushort)Code32Attribute.Code32Prefix)
                                 .Value;
            }
            set { SetAttribute(new ScannerAttribute {Id = (ushort)Code32Attribute.Code32Prefix, DataType = DataType.Bool, Value = value}); }
        }
    }
}