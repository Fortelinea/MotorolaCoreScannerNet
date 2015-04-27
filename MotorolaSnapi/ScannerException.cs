/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.Runtime.Serialization;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    [Serializable]
    public class ScannerException : Exception
    {
        private StatusCode _errorCode;
        public ScannerException() { }
        public ScannerException(string message) : base(message) { }
        public ScannerException(string message, Exception innerException) : base(message, innerException) { }

        public ScannerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info != null)
                _errorCode = (StatusCode)info.GetInt32("_errorCode");
        }

        internal StatusCode ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
                info.AddValue("_errorCode", _errorCode);
        }
    }
}