using System;

namespace Motorola.Snapi.EventArguments
{
    /// <summary>
    /// Contains data that is sent by the scanner when another device tries to access it and it is exclusively claimed.
    /// </summary>
    //TODO Figure out what this data is for.
    public class IoEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of IoEventArgs
        /// </summary>
        /// <param name="type">Reserved parameter.</param>
        /// <param name="data">Reserved parameter.</param>
        public IoEventArgs(short type, byte data)
        {
            Type = type;
            Data = data;
        }

        /// <summary>
        /// Reserved parameter.
        /// </summary>
        public short Type { get; private set; }
        /// <summary>
        /// Reserved parameter.
        /// </summary>
        public byte Data { get; private set; }
    }
}