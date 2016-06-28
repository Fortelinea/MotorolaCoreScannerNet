/*Copyright (c) 2015 Fortelinea
/
/See the file license.txt for copying permission
*/

namespace Motorola.Snapi.Constants.AttributeNumbers
{
    internal enum Code39Attribute : ushort
    {
        Code39 = 0,

        TriopticCode39 = 13,

        ConvertCode39ToCode32 = 86,

        Code32Prefix = 231,

        LengthForCode39Length1 = 18,

        LengthForCode39Length2 = 19,

        Code39CheckDigitVerification = 48,

        TransmitCode39CheckDigit = 43,

        Code39FullAsciiConversion = 17,

        BufferCode39 = 113
    }
}