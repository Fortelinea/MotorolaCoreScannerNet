using System;

namespace Motorola.Snapi.EventArguments
{
    public class IOEventArgs : EventArgs
    {
        /// <summary>
        /// Reserved parameter
        /// </summary>
        public short Type { get; private set; }
        /// <summary>
        /// Reserved parameter
        /// </summary>
        public byte Data { get; private set; }
        public IOEventArgs(short type, byte data)
        {
            Type = type;
            Data = data;
        }
    }
}