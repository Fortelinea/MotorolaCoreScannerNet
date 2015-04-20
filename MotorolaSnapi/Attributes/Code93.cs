using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing Code93 barcode attributes.
    /// </summary>
    public class Code93 : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Code93 object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Code93(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: Code93</para>
        /// <para>This parameter enables the decoding of Code 93.</para>
        /// </summary>
        public bool Code93Enabled
        {
            get
            {
                return (bool)GetAttribute(Code93Attribute.Code93)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code93Attribute.Code93, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforCode93Length1</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCode93Length1
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute(Code93Attribute.LengthForCode93Length1)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code93Attribute.LengthForCode93Length1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforCode93Length2</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCode93Length2
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute(Code93Attribute.LengthForCode93Length2)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code93Attribute.LengthForCode93Length2, DataType = DataType.Byte, Value = value });
            }
        }
    }
}