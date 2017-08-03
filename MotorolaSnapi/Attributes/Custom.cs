/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using CoreScanner;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    ///     Provides properties for accessing and modifying custom scanner attributes. For advanced users. See the product guide for your particular device.
    /// </summary>
    public class Custom : MotorolaAttributeSet
    {
        /// <summary>
        ///     Initializes a Custom object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Custom(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        ///     Sets the value of a parameter on your device. For advanced users. See the product guide for your particular device.
        /// </summary>
        /// /// <param name="attributeNumber">Number of the attribute to set. See the product guide for your particular device.</param>
        /// <param name="attributeType">Data type of the attribute. See the product guide for your particular device.</param>
        /// <param name="attributeValue">Set the attribute to this value. See the product guide for your particular device.</param>
        public void SetDeviceParameter(ushort attributeNumber, DataType attributeType, object attributeValue)
        {
            SetAttribute(new ScannerAttribute
            {
                Id = attributeNumber,
                DataType = attributeType,
                Value = attributeValue
            });
        }

        /// <summary>
        ///     Gets the value of a parameter on your device. See the product guide for your particular device.
        /// </summary>
        /// <param name="attributeNumber">Number of the attribute to set. See the product guide for your particular device.</param>
        /// <returns>Value of the attribute. See the product guide for your particular device.</returns>
        public object GetDeviceParameter(ushort attributeNumber)
        {
             object attributeValue = GetAttribute(attributeNumber).Value;

            return attributeValue;
        }
    }
}