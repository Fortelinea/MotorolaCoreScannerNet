using System;

namespace Motorola.Snapi
{
    public class PnpEventArgs : EventArgs
    {
        public PnpEventArgs(string ppnpdata)
        {
            Xml = ppnpdata;
        }

        public string Xml { get; private set; }
    }
}