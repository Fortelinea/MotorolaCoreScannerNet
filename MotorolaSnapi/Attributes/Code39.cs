using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing Code39 barcode attributes.
    /// </summary>
    public class Code39 : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Code39 object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Code39(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: Code39</para>
        /// <para>This parameter enables the decoding of Code 39.</para>
        /// </summary>
        public bool Code39Enabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.Code39)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.Code39, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: TriopticCode39</para>
        /// <para>This parameter enables the decoding of Trioptic Code 39. Trioptic Code 39 and Code 39 Full ASCII cannot be enabled simultaneously.</para>
        /// </summary>
        public bool TriopticCode39Enabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.TriopticCode39)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.TriopticCode39, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ConvertCode39toCode32</para>
        /// <para>This parameter converts Code 39 to Code 32. Code 39 must be enabled for this parameter to function.</para>
        /// </summary>
        public bool Code39IsConvertedToCode32
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.ConvertCode39ToCode32)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.ConvertCode39ToCode32, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Code32Prefix</para>
        /// <para>This parameter enables adding the prefix character “A” to all Code 32 bar codes. Convert Code 39 to Code 32 must be enabled for this parameter to function.</para>
        /// </summary>
        public bool Code32PrefixAdded
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.Code32Prefix)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.Code32Prefix, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforCode39Length1</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCode39Length1
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)Code39Attribute.LengthForCode39Length1)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.LengthForCode39Length1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforCode39Length2</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCode39Length2
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)Code39Attribute.LengthForCode39Length2)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.LengthForCode39Length2, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Code39CheckDigitVerification</para>
        /// <para>This parameter enables the scanner to check the integrity of all Code 39 symbols to verify that the data complies with specified check digit
        /// algorithm. Only Code 39 symbols which include a modulo 43 check digit are decoded. Enable this feature if the Code 39 symbols contain a Modulo 43 check digit.</para>
        /// </summary>
        public bool Code39CheckDigitVerificationEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.Code39CheckDigitVerification)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.Code39CheckDigitVerification, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: TransmitCode39CheckDigit</para>
        /// <para>This parameter enables transmission of bar code data with a check digit. Code 39 Check Digit Verification must be enabled for this parameter to function.</para>
        /// </summary>
        public bool TransmitCode39CheckDigit
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.TransmitCode39CheckDigit)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.TransmitCode39CheckDigit, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Code39FullASCIIConversion</para>
        /// <para>This parameter enables the interpretation of Code 39 as Code 39 Full ASCII. Trioptic Code 39 and Code 39 Full ASCII cannot be enabled simultaneously. 
        /// Code 39 Full ASCII to Full ASCII Correlation is host-dependent and is described in the ASCII Character Set table of your scanner’s Product Reference Guide.</para>
        /// </summary>
        public bool Code39FullAsciiConversionEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.Code39FullAsciiConversion)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.Code39FullAsciiConversion, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: BufferCode39</para>
        /// <para>This parameter allows the scanner to accumulate data from multiple Code 39 symbols.</para>
        /// </summary>
        public bool BufferCode39Enabled
        {
            get
            {
                return (bool)GetAttribute((ushort)Code39Attribute.BufferCode39)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)Code39Attribute.BufferCode39, DataType = DataType.Bool, Value = value });
            }
        }
    }
}
