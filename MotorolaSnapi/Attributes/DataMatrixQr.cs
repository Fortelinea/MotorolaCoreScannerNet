using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing DataMatrix QR barcode attributes.
    /// </summary>
    public class DataMatrixQr : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a DataMatrixQr object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        public DataMatrixQr(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: DataMatrix</para>
        /// <para>This parameter enables the decoding of DataMatrix.</para>
        /// </summary>
        public bool DataMatrixEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)DataMatrixQrAttribute.DataMatrix)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)DataMatrixQrAttribute.DataMatrix, DataType = DataType.Bool, Value = value });
            }
        }
    }
}