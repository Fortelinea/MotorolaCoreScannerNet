using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing and modifying SignatureCapture attributes.
    /// </summary>
    public class SignatureCapture : MotorolaAttributeSet
    {
        /// <summary>
        /// Initializes a SignatureCapture object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal SignatureCapture(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// Driver Attribute Name: SignatureCapture
        /// <para>This parameter enables the decoding of Signature Bar codes.</para>
        /// <remarks><para>NOTE: Scanning an signature capture bar code will product an Image of the contents within the bar code.</para></remarks>
        /// </summary>
        public bool SignatureCaptureEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)SignatureCaptureAttribute.SignatureCapture)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)SignatureCaptureAttribute.SignatureCapture, DataType = DataType.Bool, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: SigCapWidth</para>
        /// <para>This parameter sets the width of the signature capture.</para>
        /// </summary>
        public ushort CaptureWidth
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)SignatureCaptureAttribute.CaptureWidth)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)SignatureCaptureAttribute.CaptureWidth, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: SigCapHeight</para>
        /// <para>This parameter sets the height of the signature capture.</para>
        /// </summary>
        public ushort CaptureHeight
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)SignatureCaptureAttribute.CaptureHeight)
                                 .Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)SignatureCaptureAttribute.CaptureHeight, DataType = DataType.Byte, Value = value });
            }
        }
    }
}