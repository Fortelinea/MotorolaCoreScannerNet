/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/


using System;
using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Provides properties for accessing barcode security attributes.
    /// </summary>
    public class SymbologySecurity : MotorolaAttributeSet
    {
        /// <summary>
        /// Instantiates a SymbologySecurity object
        /// </summary>
        /// <param name="scannerId">ID number of the scanner to get/set data from.</param>
        /// <param name="scannerDriver">CCoreScanner instance</param>
        internal SymbologySecurity(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: RedundancyLevel</para>
        /// <para>This parameter sets the scanner�s Redundancy Level. The scanner offers four levels of decode redundancy. Select higher redundancy levels for
        /// decreasing levels of bar code quality. As redundancy levels increase, the scanner�s aggressiveness decreases. Refer to your scanner�s Product Reference Guide for details.</para>
        /// <remarks><para>Values: 0(lowest), 1, 2, 3, 4</para></remarks>
        /// </summary>
        public ushort RedundancyLevel
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)SymbologySecurityAttribute.RedundancyLevel).Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)SymbologySecurityAttribute.RedundancyLevel, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: SecurityLevel</para>
        /// <para>The scanner offers four levels of decode security for delta bar codes, which include the Code 128 family, UPC/EAN, and Code 93. Select increasing levels of security for
        /// decreasing levels of bar code quality. As security levels increase, the scanner�s aggressiveness decreases. Refer to your scanner�s Product Reference Guide for details.</para>
        /// <remarks><para>Values: 0(lowest), 1, 2, 3, 4</para></remarks>
        /// </summary>
        public ushort SecurityLevel
        {
            get
            {
                return Convert.ToUInt16(GetAttribute((ushort)SymbologySecurityAttribute.SecurityLevel).Value);
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)SymbologySecurityAttribute.SecurityLevel, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: BidirectionalRedundancy</para>
        /// <para>This parameter enables Bi-directional decode Redundancy, which adds security to linear code type decoding. When enabled, a bar code must be
        /// successfully scanned in both directions (forward and reverse) before reporting a good decode.</para>
        /// </summary>
        public bool BidirectionalRedundancyEnabled
        {
            get
            {
                return (bool)GetAttribute((ushort)SymbologySecurityAttribute.BidirectionalRedundancy)
                                 .Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = (ushort)SymbologySecurityAttribute.BidirectionalRedundancy, DataType = DataType.Bool, Value = value });
            }
        }
    }
}