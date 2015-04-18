using System.Drawing;
using System.Drawing.Imaging;

namespace Motorola.Snapi.EventArguments
{
    public class ImageEventArgs : ScannerEventArgs {
        private readonly ImageFormat _format;
        private readonly Image _image;

        public ImageEventArgs(uint scannerId, ImageFormat format, Image image) : base(scannerId)
        {
            _format = format;
            _image = image;
        }
        /// <summary>
        /// File format of the received image.
        /// </summary>
        public ImageFormat Format { get { return _format;} }
        /// <summary>
        /// Image received by the scanner.
        /// </summary>
        public Image Image { get { return _image;} }
    }
}