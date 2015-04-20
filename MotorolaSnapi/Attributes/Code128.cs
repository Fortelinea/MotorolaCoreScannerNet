using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing Code128 barcode attributes.
    /// </summary>
    public class Code128 : MotorolaAttributeSet
    {
        private readonly int _scannerId;
        private readonly CCoreScanner _scannerDriver;
        /// <summary>
        /// Instantiates a Code128 object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Code128(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver){}

        /// <summary>
        /// <para>Driver Attribute Name: Code128</para>
        /// <para>This parameter enables the decoding of Code 128 barcodes.</para>
        /// </summary>
        public bool Code128Enabled
        {
            get
            {
                return (bool)GetAttribute(Code128Attribute.Code128)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code128Attribute.Code128, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UCC/EAN-128</para>
        /// <para>This parameter enables the decoding of UCC/EAN-128 barcodes.</para>
        /// </summary>
        public bool UccEan128Enabled
        {
            get
            {
                return (bool)GetAttribute(Code128Attribute.UccEan128)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code128Attribute.UccEan128, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ISBT128</para>
        /// <para>This parameter enables the decoding of ISBT128 barcodes.</para>
        /// </summary>
        public bool Isbt128Enabled
        {
            get
            {
                return (bool)GetAttribute(Code128Attribute.Isbt128)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code128Attribute.Isbt128, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Code128Redundancy</para>
        /// </summary>
        public bool Code128RedundancyEnabled
        {
            get
            {
                return (bool)GetAttribute(Code128Attribute.Code128Redundancy)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code128Attribute.Code128Redundancy, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: EAN128Emulation</para>
        /// <para>This parameter enables EAN128 emulation.</para>
        /// </summary>
        public bool Ean128EmulationEnabled
        {
            get
            {
                return (bool)GetAttribute(Code128Attribute.Ean128Emulation)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code128Attribute.Ean128Emulation, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Code128Length1</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort Code128Length1
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute(Code128Attribute.Code128Length1).Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code128Attribute.Code128Length1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: Code128Length2</para>
        /// <para>Defines the allowable lengths for the symbology.</para>
        /// </summary>
        public ushort Code128Length2
        {//Not sure what this actually does or what the values mean.
            get
            {
                return Convert.ToUInt16(GetAttribute(Code128Attribute.Code128Length2).Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = Code128Attribute.Code128Length2, DataType = DataType.Byte, Value = value });
            }
        }
    }
}