/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using System.Drawing;
using System.Drawing.Imaging;

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    /// Contains image data and sender info for when a scanner captures an image.
    /// </summary>
    public class ImageEventArgs : ScannerEventArgs {
        /// <summary>
        /// Creates a new image event instance.
        /// </summary>
        /// <param name="scannerId">Id number of the scanner that triggered the event.</param>
        /// <param name="format">File format of the image.</param>
        /// <param name="image">Image object containing the data of the image that was captured.</param>
        public ImageEventArgs(uint scannerId, ImageFormat format, Image image) : base(scannerId)
        {
            Format = format;
            Image = image;
        }
        /// <summary>
        /// File format of the received image.
        /// </summary>
        public ImageFormat Format { get; private set; }

        /// <summary>
        /// Image received by the scanner.
        /// </summary>
        public Image Image { get; private set; }
    }
}