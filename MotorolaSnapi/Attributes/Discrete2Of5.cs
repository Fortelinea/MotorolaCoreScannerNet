using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing Discrete 2 of 5 (DTF) barcode attributes.
    /// </summary>
    public class Discrete2Of5 : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Discrete2Of5 object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Discrete2Of5(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: Discrete2of5</para>
        /// <para>This parameter enables the decoding of Discrete 2 of 5.</para>
        /// </summary>
        public bool Discrete2Of5Enabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Discrete2Of5Attribute.Discrete2Of5)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Discrete2Of5Attribute.Discrete2Of5, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforD2of5Length1</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForD2Of5Length1
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)Discrete2Of5Attribute.LengthForD2Of5Length1)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Discrete2Of5Attribute.LengthForD2Of5Length1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforD2of5Length2</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForD2Of5Length2
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)Discrete2Of5Attribute.LengthForD2Of5Length2)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Discrete2Of5Attribute.LengthForD2Of5Length2, DataType = DataType.Byte, Value = value });
            }
        }
    }
}