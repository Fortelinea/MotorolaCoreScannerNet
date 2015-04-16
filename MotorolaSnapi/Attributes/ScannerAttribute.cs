using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi.Attributes
{
    /// <summary>
    /// Represents a single scanner attribute. Holds identification info and the value of the attribute.
    /// </summary>
    public class ScannerAttribute
    {
        /// <summary>
        /// Attribute ID
        /// </summary>
        public ushort Id { get; set; }

        /// <summary>
        /// Name of attribute.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Internal data type of attribute represented by a char.
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// Read / Write permissions
        /// </summary>
        public char Permission { get; set; }

        /// <summary>
        /// Value of the attribute.
        /// </summary>
        public object Value { get; set; }
    }
}