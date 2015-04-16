using CoreScanner;
using Motorola.Snapi.Constants.AttributeNumbers;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// <para>Provides properties for accessing and modifying scanner ADF attributes.</remarks>
    /// <remarks>The ADF buffer attribute contains a proprietary format which stores data formatting configurations. This format is not published however, the contents of this attribute can be copied from a "golden" scanner which
    /// has the correct settings and copied to other devices.</remarks>
    /// </summary>
    public class Adf : MotorolaAttributeSet
    {
        internal Adf(int scannerId, CCoreScanner scannerDriver) : base(scannerId, scannerDriver) {}

        /// <summary>
        /// <para>Driver Attribute Name: ADFRules</para>
        /// <para>Description: The parameter defines the advanced data formatting rules which should be applied to decoded bar codes.</remarks>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte[] ADFRules
        {
            get
            {
                return (byte[])GetAttribute(AdfAttribute.ADFRules).Value;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.ADFRules, DataType = DataType.Array, Value = ValueConverters.ByteArrayToHexString(value) });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyDelay</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyDelay
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyDelay);
                if(attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyDelay, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: PauseDuration</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte PauseDuration
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.PauseDuration);
                if(attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.PauseDuration, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyCategory1</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyCategory1
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyCategory1);
                if(attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyCategory1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyCategory2</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyCategory2
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyCategory2);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyCategory2, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyCategory3</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyCategory3
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyCategory3);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyCategory3, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyCategory4</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyCategory4
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyCategory4);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyCategory4, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyCategory5</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyCategory5
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyCategory5);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyCategory5, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyCategory6</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyCategory6
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyCategory6);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyCategory6, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyValue1</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyValue1
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyValue1);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyValue1, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyValue2</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyValue2
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyValue2);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyValue2, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyValue3</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyValue3
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyValue3);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyValue3, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyValue4</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyValue4
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyValue4);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyValue4, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyValue5</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyValue5
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyValue5);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyValue5, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: KeyValue6</para>
        /// <remarks>The ADF rules are in a proprietary format. End users wishing to deploy ADF rules should first manually program 
        /// the scanner using programming bar codes and then reading the attribute from an application. The rule can then be 
        /// deployed to other scanners in the enterprise.</remarks>
        /// </summary>
        public byte KeyValue6
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.KeyValue6);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.KeyValue6, DataType = DataType.Byte, Value = value });
            }
        }

        /// <summary>
        /// <para>Driver Attribute Name: SimpleDataFormat</para>
        /// <para> The parameter controls the simple data
        /// formatting where data is presented in
        /// <code>&lt;prefix1&gt;&lt;data&gt;&lt;suffix1&gt;&lt;suffix2&gt;.</code></para>
        /// <remarks>Values:
        /// <para>0 – &lt;DATA&gt;</para>
        /// <para>1 – &lt;DATA&gt;&lt;SUFFIX1&gt;</para>
        /// <para>2 – &lt;DATA&gt;&lt;SUFFIX2&gt;</para>
        /// <para>3 – &lt;DATA&gt;&lt;SUFFIX1&gt;&lt;SUFFIX2&gt;</para>
        /// <para>4 – &lt;PREFIX&gt;&lt;DATA</para>
        /// <para>5 – &lt;PREFIX&gt;&lt;DATA&gt;&lt;SUFFIX1&gt;</para>
        /// <para>6 – &lt;PREFIX&gt;&lt;DATA&gt;&lt;SUFFIX2&gt;</para>
        /// <para>7 – &lt;PREFIX&gt;&lt;DATA&gt;&lt;SUFFIX1&gt;&lt;SUFFIX2&gt;</para></remarks>
        /// </summary>
        public byte SimpleDataFormat
        {
            get
            {
                var attribute = GetAttribute(AdfAttribute.SimpleDataFormat);
                if (attribute != null) return (byte)attribute.Value;
                return 0;
            }
            set
            {
                SetAttribute(new ScannerAttribute { Id = AdfAttribute.SimpleDataFormat, DataType = DataType.Byte, Value = value });
            }
        }
    }
}
