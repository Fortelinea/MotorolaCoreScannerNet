using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    public class Maxicode : MotorolaAttributeSet
    {
        public Maxicode(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: Maxicode</para>
        /// <para>This parameter enables the decoding of Maxicode.</para>
        /// </summary>
        public bool Code11Enabled
        {
            get
            {
                return (bool)GetAttribute(MaxicodeAttribute.Maxicode)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = MaxicodeAttribute.Maxicode, DataType = DataType.Bool, Value = value });
            }
        }
    }
}