using System.Drawing;
using System.Drawing.Imaging;

namespace Motorola.Snapi.EventArgs
{
    public class ImageEventArgs : ScannerEventArgs {
        private readonly ImageFormat _format;
        private readonly Image _image;

        public ImageEventArgs(uint scannerId, ImageFormat format, Image image) : base(scannerId)
        {
            _format = format;
            _image = image;
        }

        public ImageFormat Format { get { return _format;} }
        public Image Image { get { return _image;} }
    }
}