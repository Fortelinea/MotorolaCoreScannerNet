using System;

namespace Motorola.Snapi
{
    internal static class EnumUtil
    {
        public static string GetAttributeValue<T>(this Enum e, Func<T, object> selector) where T : Attribute
        {
            var output = e.ToString();
            var memInfo = e.GetType().GetMember(output);
            if (memInfo.Length <= 0) return output;

            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length <= 0) return output;

            var firstAttr = (T)attributes[0];
            var str = selector(firstAttr).ToString();
            output = string.IsNullOrWhiteSpace(str) ? output : str;

            return output;
        }
    }
}