using System.Drawing;
using System.Drawing.Imaging;

namespace Motorola.Snapi
{
    public class ImageEventArgs {
        private readonly uint _scannerId;
        private readonly ImageFormat _format;
        private readonly Image _image;

        public ImageEventArgs(uint scannerId, ImageFormat format, Image image)
        {
            _scannerId = scannerId;
            _format = format;
            _image = image;
        }

        public uint ScannerId { get { return _scannerId;} }
        public ImageFormat Format { get { return _format;} }
        public Image Image { get { return _image;} }
    }
}