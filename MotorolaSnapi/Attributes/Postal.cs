using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing Postal barcode attributes.
    /// </summary>
    public class Postal : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Postal object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Postal(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: USPost1</para>
        /// <para>This parameter enables the decoding of USPost1.</para>
        /// </summary>
        public bool UsPost1Enabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.UsPost1)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.UsPost1, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: USPost2</para>
        /// <para>This parameter enables the decoding of USPost2.</para>
        /// </summary>
        public bool UsPost2Enabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.UsPost2)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.UsPost2, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UKPost</para>
        /// <para>This parameter enables the decoding of UKPost.</para>
        /// </summary>
        public bool UkPostEnabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.UkPost)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.UkPost, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: CanadaPost</para>
        /// <para>This parameter enables the decoding of CanadaPost.</para>
        /// </summary>
        public bool CanadaPostEnabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.CanadaPost)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.CanadaPost, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: USPostParity</para>
        /// <para>This parameter enables the parity option of USPostal bar codes.</para>
        /// </summary>
        public bool UsPostParityEnabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.UsPostParity)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.UsPostParity, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: UKPostParity</para>
        /// <para>This parameter enables the parity option of UKPostal bar codes.</para>
        /// </summary>
        public bool UkPostParityEnabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.UkPostParity)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.UkPostParity, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: JapanPost</para>
        /// <para>This parameter enables the parity option of Japan Post bar codes.</para>
        /// </summary>
        public bool JapanPostEnabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.JapanPost)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.JapanPost, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: AusPost</para>
        /// <para>This parameter enables the parity option of Australia Post bar codes.</para>
        /// </summary>
        public bool AusPostEnabled
        {
            get
            {
                return (bool)GetAttribute(PostalAttribute.AusPost)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = PostalAttribute.AusPost, DataType = DataType.Bool, Value = value });
            }
        }
    }
}