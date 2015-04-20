using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    public class DataMatrixQr : MotorolaAttributeSet
    {
        public DataMatrixQr(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: DataMatrix</para>
        /// <para>This parameter enables the decoding of DataMatrix.</para>
        /// </summary>
        public bool DataMatrixEnabled
        {
            get
            {
                return (bool)GetAttribute(DataMatrixQrAttribute.DataMatrix)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = DataMatrixQrAttribute.DataMatrix, DataType = DataType.Bool, Value = value });
            }
        }
    }
}