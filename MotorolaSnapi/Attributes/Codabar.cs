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
    /// Provides properties for accessing Codabar barcode attributes.
    /// </summary>
    public class Codabar : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Codabar object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Codabar(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: Codabar</para>
        /// <para>This parameter enables the decoding of Codabar.</para>
        /// </summary>
        public bool CodabarEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)CodabarAttribute.Codabar)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)CodabarAttribute.Codabar, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: CLSIEditing</para>
        /// <para>This parameter strips the start and stop characters and inserts a space after the first, fifth, and tenth characters of a 14-character Codabar
        /// symbol. Symbol length does not include start and stop characters.</para>
        /// </summary>
        public bool ClsiEditingEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)CodabarAttribute.ClsiEditing)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)CodabarAttribute.ClsiEditing, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: NOTISEditing</para>
        /// <para>This parameter strips the start and stop characters from a decoded Codabar symbol.</para>
        /// </summary>
        public bool NotisEditingEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)CodabarAttribute.NotisEditing)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)CodabarAttribute.NotisEditing, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforCodabarLength1</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCodabarLength1
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)CodabarAttribute.LengthForCodabarLength1)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)CodabarAttribute.LengthForCodabarLength1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: LengthforCodabarLength2</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort LengthForCodabarLength2
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)CodabarAttribute.LengthForCodabarLength2)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)CodabarAttribute.LengthForCodabarLength2, DataType = DataType.Byte, Value = value });
            }
        }
    }
}