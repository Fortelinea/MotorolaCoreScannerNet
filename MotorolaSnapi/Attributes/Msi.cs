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
    ///     Provides properties for accessing and modifying scanner MSI barcode attributes.
    /// </summary>
    public class Msi : MotorolaAttributeSet
    {
        /// <summary>
        ///     Initializes a Msi object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Msi(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        ///     <para>Driver Attribute Name: LengthforMsiLength1</para>
        ///     <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForMsiLength1
        {
            //Not sure what this actually does or what the values mean.
            get { return Convert.ToUInt16(GetAttribute((ushort)MsiAttribute.LengthForMsiLength1).Value); }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)MsiAttribute.LengthForMsiLength1,
                                 DataType = DataType.Byte,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: LengthforMsiLength2</para>
        ///     <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForMsiLength2
        {
            //Not sure what this actually does or what the values mean.
            get { return Convert.ToUInt16(GetAttribute((ushort)MsiAttribute.LengthForMsiLength2).Value); }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)MsiAttribute.LengthForMsiLength2,
                                 DataType = DataType.Byte,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: MSICheckDigitAlgorithm</para>
        ///     <para>This parameter selects which of two algorithms are used for the verification of the second MSI check digit.</para>
        /// </summary>
        public MsiCheckDigitAlgorithm MsiCheckDigitAlgorithm
        {
            get { return (MsiCheckDigitAlgorithm)GetAttribute((ushort)MsiAttribute.MsiCheckDigitAlgorithm).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)MsiAttribute.MsiCheckDigitAlgorithm,
                                 DataType = DataType.Bool,
                                 Value = (byte)value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: MSICheckDigits</para>
        ///     <para>
        ///         This parameter determines how many check digits will be analyzed during decoding. With MSI symbols, one
        ///         check digit is mandatory and always verified by the reader. The second check digit is optional.
        ///     </para>
        /// </summary>
        public MsiCheckDigit MsiCheckDigits
        {
            get { return (MsiCheckDigit)GetAttribute((ushort)MsiAttribute.MsiCheckDigits).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)MsiAttribute.MsiCheckDigits,
                                 DataType = DataType.Bool,
                                 Value = (byte)value
                             });
            }
        }

        /// <summary>
        ///     Driver Attribute Name: MSI
        ///     <para>This parameter enables the decoding of MSI barcodes.</para>
        /// </summary>
        public bool MsiEnabled
        {
            get { return (bool)GetAttribute((ushort)MsiAttribute.Msi).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)MsiAttribute.Msi,
                                 DataType = DataType.Bool,
                                 Value = value
                             });
            }
        }

        /// <summary>
        ///     <para>Driver Attribute Name: TransmitMSICheckDigit</para>
        ///     <para>This parameter enables transmission of bar code data with a check digit.</para>
        /// </summary>
        public bool TransmitMsiCheckDigit
        {
            get { return (bool)GetAttribute((ushort)MsiAttribute.TransmitMsiCheckDigit).Value; }
            set
            {
                SetAttribute(new ScannerAttribute
                             {
                                 Id = (ushort)MsiAttribute.TransmitMsiCheckDigit,
                                 DataType = DataType.Bool,
                                 Value = value
                             });
            }
        }
    }
}