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
    ///     Provides properties for accessing Interleaved 2 of 5 (ITF) barcode attributes.
    /// </summary>
    public class Interleaved2Of5 : MotorolaAttributeSet
    {
        /// <summary>
        ///     Instantiates a Interleaved2Of5 object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Interleaved2Of5(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        ///     <para>Driver Attribute Name: I2of5CheckDigitVerification</para>
        ///     <para>
        ///         This parameter enables the scanner to check the integrity of all I 2 of 5 symbols to verify the data complies
        ///         with either the Uniform Symbology
        ///         Specification (USS), or the Optical Product Code Council (OPCC) check digit algorithm.
        ///     </para>
        /// </summary>
        public I2Of5CheckDigit I2Of5CheckDigitVerification
        {
            get { return (I2Of5CheckDigit)GetAttribute((ushort)Interleaved2Of5Attribute.I2Of5CheckDigitVerification).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Interleaved2Of5Attribute.I2Of5CheckDigitVerification,
                                 DataType = DataType.Byte,
                                 Value = (byte)value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: ConvertI2of5toEAN13</para>
        ///     <para>
        ///         This parameter converts 14-character I 2 of 5 codes to EAN-13, and transmit to the host as EAN-13. To
        ///         accomplish this, the I 2 of 5 code must be enabled,
        ///         and the code must have a leading zero and a valid EAN-13 check digit.
        ///     </para>
        /// </summary>
        public bool I2Of5IsConvertedToEan13
        {
            get { return (bool)GetAttribute((ushort)Interleaved2Of5Attribute.ConvertI2Of5ToEan13).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Interleaved2Of5Attribute.ConvertI2Of5ToEan13,
                                 DataType = DataType.Bool,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: Interleaved2of5</para>
        ///     <para>This parameter enables the decoding of Interleaved 2 of 5.</para>
        /// </summary>
        public bool Interleaved2Of5Enabled
        {
            get { return (bool)GetAttribute((ushort)Interleaved2Of5Attribute.Interleaved2Of5).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Interleaved2Of5Attribute.Interleaved2Of5,
                                 DataType = DataType.Bool,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: LengthforI2of5Length1</para>
        ///     <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForI2Of5Length1
        {
            //Not sure what this actually does or what the values mean.
            get { return Convert.ToUInt16(GetAttribute((ushort)Interleaved2Of5Attribute.LengthForI2Of5Length1).Value); }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Interleaved2Of5Attribute.LengthForI2Of5Length1,
                                 DataType = DataType.Byte,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: LengthforI2of5Length2</para>
        ///     <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForI2Of5Length2
        {
            //Not sure what this actually does or what the values mean.
            get { return Convert.ToUInt16(GetAttribute((ushort)Interleaved2Of5Attribute.LengthForI2Of5Length2).Value); }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Interleaved2Of5Attribute.LengthForI2Of5Length2,
                                 DataType = DataType.Byte,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: TransmitI2Of5CheckDigit</para>
        ///     <para>
        ///         This parameter enables transmission of bar code data with a check digit. I2Of5 Check Digit Verification must
        ///         be enabled for this parameter to function.
        ///     </para>
        /// </summary>
        public bool TransmitI2Of5CheckDigit
        {
            get { return (bool)GetAttribute((ushort)Interleaved2Of5Attribute.TransmitI2Of5CheckDigit).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)Interleaved2Of5Attribute.TransmitI2Of5CheckDigit,
                                 DataType = DataType.Bool,
                                 Value = value
                             });
            }
        }
    }
}