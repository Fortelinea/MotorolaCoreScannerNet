using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing RSS / GS1 Databar barcode attributes.
    /// </summary>
    public class RssGs1Databar : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a RssGs1Databar object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal RssGs1Databar(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: GS1DataBar14</para>
        /// <para>This parameter enables the decoding of GS1 DataBar-14 and its stacked variant.</para>
        /// </summary>
        public bool Gs1DataBar14Enabled
        {
            get
            {
                return (bool)GetAttribute(RssGs1DatabarAttribute.Gs1DataBar14)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = RssGs1DatabarAttribute.Gs1DataBar14, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: GS1DataBarLimited</para>
        /// <para>This parameter enables the decoding of GS1 DataBar Limited.</para>
        /// </summary>
        public bool Gs1DataBarLimitedEnabled
        {
            get
            {
                return (bool)GetAttribute(RssGs1DatabarAttribute.Gs1DataBarLimited)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = RssGs1DatabarAttribute.Gs1DataBarLimited, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: GS1DataBarExpanded</para>
        /// <para>This parameter enables the decoding of DataBar Expanded and its stacked variant.</para>
        /// </summary>
        public bool Gs1DataBarExpandedEnabled
        {
            get
            {
                return (bool)GetAttribute(RssGs1DatabarAttribute.Gs1DataBarExpanded)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = RssGs1DatabarAttribute.Gs1DataBarExpanded, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: ConvertGS1DataBarToUPCEAN</para>
        /// <para>TThis parameter only applies to GS1 DataBa-14 and GS1 DataBar Limited symbols not decoded as part of a Composite symbol. Enable this to strip
        /// the leading '010' from GS1 DataBar-14 and GS1 DataBar Limited symbols encoding a single zero as the first digit, and report the bar code as EAN-13.
        /// For bar codes beginning with two or more zeros but not six zeros, this parameter strips the leading '0100' and reports the bar code as UPC-A. The
        /// UPC-A Preamble parameter that transmits the system character and country code applies to converted bar codes. Note that neither the system
        /// character nor the check digit can be stripped.</para>
        /// </summary>
        public bool Gs1DataBarIsConvertedToUpcean
        {
            get
            {
                return (bool)GetAttribute(RssGs1DatabarAttribute.ConvertGs1DataBarToUpcean)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = RssGs1DatabarAttribute.ConvertGs1DataBarToUpcean, DataType = DataType.Bool, Value = value });
            }
        }
    }
}