/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Motorola.Snapi.Constants.Enums;

namespace Motorola.Snapi
{
    [Serializable]
    public class ScannerException : Exception
    {
        public ScannerException(string message, [CallerMemberName] string function = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : base(message)
        {
            MemberName = function;
            FilePath = path;
            LineNumber = line;
        }

        public ScannerException(StatusCode errorCode, [CallerMemberName] string function = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : base(GetMessageFromErrorCode(errorCode))
        {
            ErrorCode = errorCode;
            MemberName = function;
            FilePath = path;
            LineNumber = line;
        }

        public ScannerException(string message, StatusCode errorCode, [CallerMemberName] string function = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) : base(message)
        {
            ErrorCode = errorCode;
            MemberName = function;
            FilePath = path;
            LineNumber = line;
        }

        public ScannerException(string message, StatusCode errorCode, Exception innerException, [CallerMemberName] string function = "", [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
            MemberName = function;
            FilePath = path;
            LineNumber = line;
        }

        public ScannerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ErrorCode = (StatusCode)info.GetInt32("ErrorCode");
            MemberName = info.GetString("MemberName");
            FilePath = info.GetString("FilePath");
            LineNumber = info.GetInt32("LineNumber");
        }

        public StatusCode ErrorCode { get; }

        public string FilePath { get; }

        public int LineNumber { get; }

        public string MemberName { get; }

        public static string GetMessageFromErrorCode(StatusCode errorCode)
        {
            var title = string.Empty;
            var description = string.Empty;
            try
            {
                title = errorCode.GetAttributeValue<DisplayAttribute>(x => x.Name);
            }
            catch
            {
                // Ignore
            }
            try
            {
                description = errorCode.GetAttributeValue<DisplayAttribute>(x => x.Description);
            }
            catch
            {
                // Ignore
            }
            return $"{title}{Environment.NewLine}{description}";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("ErrorCode", ErrorCode);
            info.AddValue("MemberName", MemberName);
            info.AddValue("FilePath", FilePath);
            info.AddValue("LineNumber", LineNumber);
        }
    }
}