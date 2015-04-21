using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing PDF barcode attributes.
    /// </summary>
    public class Pdf : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a Pdf object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Pdf(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: PDF</para>
        /// <para>This parameter enables the decoding of PDF.</para>
        /// </summary>
        public bool PdfEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)PdfAttribute.Pdf)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)PdfAttribute.Pdf, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: MicroPDF</para>
        /// <para>This parameter enables the decoding of MicroPDF.</para>
        /// </summary>
        public bool MicroPdfEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)PdfAttribute.MicroPdf)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)PdfAttribute.MicroPdf, DataType = DataType.Bool, Value = value });
            }
        }
    }
}