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
    /// Provides properties for accessing Chinese 2 of 5 barcode attributes.
    /// </summary>
    public class Chinese2Of5 : MotorolaAttributeSet
    {
        internal Chinese2Of5(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: Chinese2of5</para>
        /// <para>This parameter enables the decoding of Chinese 2 of 5 barcodes.</para>
        /// </summary>
        public bool Chinese2Of5Enabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Chinese2Of5Attribute.Chinese2Of5)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Chinese2Of5Attribute.Chinese2Of5, DataType = DataType.Bool, Value = value });
            }
        }
    }
}