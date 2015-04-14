using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CoreScanner;
using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing status attributes of cordless scanners.
    /// </summary>
    public class Status : MotorolaAttributeSet 
    {
        /// <summary>
        /// Initializes a SystemEvents object.
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal Status(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) { }

        /// <summary>
        /// Indicates if the cordless scanner is inserted in the cradle
        /// </summary>
        public bool InCradle
        {
            get
            {
                return (bool)GetAttribute(StatusAttribute.InCradleDetect)
                                 .Value;
            }
        }

        /// <summary>
        /// Indicates if the device is being used in ScanStand.
        /// </summary>
        public bool IsHandsfree
        {
            get
            {
                return (bool)GetAttribute(StatusAttribute.OperationalMode)
                                 .Value;
            }
        }

        /// <summary>
        /// Indicates if the device is charging.
        /// </summary>
        public bool Charging
        {
            get
            {
                return (bool)GetAttribute(StatusAttribute.Charging)
                                 .Value;
            }
        }
    }
}