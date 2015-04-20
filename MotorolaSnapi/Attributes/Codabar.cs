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
                return (bool)GetAttribute(CodabarAttribute.Codabar)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = CodabarAttribute.Codabar, DataType = DataType.Bool, Value = value });
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
                return (bool)GetAttribute(CodabarAttribute.ClsiEditing)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = CodabarAttribute.ClsiEditing, DataType = DataType.Bool, Value = value });
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
                return (bool)GetAttribute(CodabarAttribute.NotisEditing)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = CodabarAttribute.NotisEditing, DataType = DataType.Bool, Value = value });
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
                return Convert.ToUInt16(GetAttribute(CodabarAttribute.LengthForCodabarLength1)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = CodabarAttribute.LengthForCodabarLength1, DataType = DataType.Byte, Value = value });
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
                return Convert.ToUInt16(GetAttribute(CodabarAttribute.LengthForCodabarLength2)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = CodabarAttribute.LengthForCodabarLength2, DataType = DataType.Byte, Value = value });
            }
        }
    }
}