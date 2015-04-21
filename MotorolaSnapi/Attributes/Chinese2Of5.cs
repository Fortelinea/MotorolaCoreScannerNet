using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    public class Chinese2Of5 : MotorolaAttributeSet
    {
        internal Chinese2Of5(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

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