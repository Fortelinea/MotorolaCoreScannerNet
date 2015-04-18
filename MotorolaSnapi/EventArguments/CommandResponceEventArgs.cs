using System.Xml.Linq;

namespace Motorola.Snapi.EventArguments
{
    internal class CommandResponceEventArgs
    {
        internal CommandResponceEventArgs(XDocument outXml) { OutXml = outXml; }
        internal XDocument OutXml { get; set; }
    }
}