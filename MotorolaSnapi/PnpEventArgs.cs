using System;

namespace Motorola.Snapi
{
    public class PnpEventArgs : EventArgs
    {
        public PnpEventArgs(short eventtype, string ppnpdata)
        {
            EventType = eventtype;
            Xml = ppnpdata;
        }
        public short EventType { get; private set; }

        public string Xml { get; private set; }
    }
}