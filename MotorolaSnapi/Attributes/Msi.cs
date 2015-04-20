using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    public class Msi : MotorolaAttributeSet
    {
        internal Msi(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: MSI</para>
        /// <para>This parameter enables the decoding of MSI.</para>
        /// </summary>
        public bool MsiEnabled
        {
            get
            {
                return (bool)GetAttribute(MsiAttribute.Msi)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = MsiAttribute.Msi, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: MSICheckDigits</para>
        /// <para>This parameter determines how many check digits will be analyzed during decoding. With MSI symbols, one
        /// check digit is mandatory and always verified by the reader. The second check digit is optional.</para>
        /// </summary>
        public MsiCheckDigit MsiCheckDigits
        {
            get
            {
                return (MsiCheckDigit)GetAttribute(MsiAttribute.MsiCheckDigits)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = MsiAttribute.MsiCheckDigits, DataType = DataType.Bool, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: TransmitMSICheckDigit</para>
        /// <para>This parameter enables transmission of bar code data with a check digit.</para>
        /// </summary>
        public bool TransmitMsiCheckDigit
        {
            get
            {
                return (bool)GetAttribute(MsiAttribute.TransmitMsiCheckDigit)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = MsiAttribute.TransmitMsiCheckDigit, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: MSICheckDigitAlgorithm</para>
        /// <para>This parameter selects which of two algorithms are used for the verification of the second MSI check digit.</para>
        /// </summary>
        public MsiCheckDigitAlgorithm MsiCheckDigitAlgorithm
        {
            get
            {
                return (MsiCheckDigitAlgorithm)GetAttribute(MsiAttribute.MsiCheckDigitAlgorithm)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = MsiAttribute.MsiCheckDigitAlgorithm, DataType = DataType.Bool, Value = (byte)value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforMsiLength1</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForMsiLength1
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute(MsiAttribute.LengthForMsiLength1)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = MsiAttribute.LengthForMsiLength1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforMsiLength2</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForMsiLength2
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute(MsiAttribute.LengthForMsiLength2)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = MsiAttribute.LengthForMsiLength2, DataType = DataType.Byte, Value = value });
            }
        }
    }
}