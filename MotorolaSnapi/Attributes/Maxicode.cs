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
    /// Provides properties for accessing Maxicode barcode attributes.
    /// </summary>
    public class Maxicode : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Maxicode object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        public Maxicode(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        /// <para>Driver Attribute Name: Maxicode</para>
        /// <para>This parameter enables the decoding of Maxicode.</para>
        /// </summary>
        public bool Code11Enabled
        {
            get
            {
                return (bool)GetAttribute((ushort)MaxicodeAttribute.Maxicode)
                                 .Value;
            }
            set { SetAttribute(new ScannerAttribute {Id = (ushort)MaxicodeAttribute.Maxicode, DataType = DataType.Bool, Value = value}); }
        }
    }
}