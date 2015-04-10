using Motorola.Snapi.Constants;

namespace Motorola.Snapi.Attributes
{
    public class ScannerAttribute
    {

        public ushort Id { get; set; }

        public string Name { get; set; }

        public DataType DataType { get; set; }

        public char Permission { get; set; }

        public object Value { get; set; }
    }
}