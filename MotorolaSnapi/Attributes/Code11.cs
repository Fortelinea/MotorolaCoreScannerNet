/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    ///     Provides properties for accessing Code11 barcode attributes.
    /// </summary>
    public class Code11 : MotorolaAttributeSet
    {
        /// <summary>
        ///     Instantiates a Code11 object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Code11(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        ///     <para>Driver Attribute Name: Code11CheckDigitVerification</para>
        ///     <para>
        ///         This parameter enables the scanner to check the integrity of all Code 11 symbols to verify that the data
        ///         complies with specified check digit algorithm.
        ///     </para>
        /// </summary>
        public Code11CheckDigit Code11CheckDigitVerification
        {
            get { return (Code11CheckDigit)GetAttribute((ushort)Code11Attribute.Code11CheckDigitVerification).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Code11Attribute.Code11CheckDigitVerification,
                                 DataType = DataType.Byte,
                                 Value = (byte)value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: Code11</para>
        ///     <para>This parameter enables the decoding of Code 11.</para>
        /// </summary>
        public bool Code11Enabled
        {
            get { return (bool)GetAttribute((ushort)Code11Attribute.Code11).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Code11Attribute.Code11,
                                 DataType = DataType.Bool,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: LengthforCode11Length1</para>
        ///     <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCode11Length1
        {
            //Not sure what this actually does or what the values mean.
            get { return Convert.ToUInt16(GetAttribute((ushort)Code11Attribute.LengthForCode11Length1).Value); }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Code11Attribute.LengthForCode11Length1,
                                 DataType = DataType.Byte,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: LengthforCode11Length2</para>
        ///     <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCode11Length2
        {
            //Not sure what this actually does or what the values mean.
            get { return Convert.ToUInt16(GetAttribute((ushort)Code11Attribute.LengthForCode11Length2).Value); }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Code11Attribute.LengthForCode11Length2,
                                 DataType = DataType.Byte,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: TransmitCode11CheckDigit</para>
        ///     <para>
        ///         This parameter enables transmission of bar code data with a check digit. Code 11 Check Digit Verification
        ///         must be enabled for this parameter to function.
        ///     </para>
        /// </summary>
        public bool TransmitCode11CheckDigit
        {
            get { return (bool)GetAttribute((ushort)Code11Attribute.TransmitCode11CheckDigit).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Code11Attribute.TransmitCode11CheckDigit,
                                 DataType = DataType.Bool,
                                 Value = value
                             });
            }
        }
    }
}