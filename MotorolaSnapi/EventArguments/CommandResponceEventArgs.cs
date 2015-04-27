/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System.Xml.Linq;

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    /// Contains the results of an async command.
    /// </summary>
    internal class CommandResponceEventArgs
    {
        /// <summary>
        /// Creates a new instance of CommandResponceEventArgs.
        /// </summary>
        /// <param name="outXml">Command results in xml format.</param>
        internal CommandResponceEventArgs(XDocument outXml) { OutXml = outXml; }

        /// <summary>
        /// Command results in xml format.
        /// </summary>
        internal XDocument OutXml { get; set; }
    }
}