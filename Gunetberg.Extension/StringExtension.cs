using System;

namespace Gunetberg.Extension
{
    public static class StringExtension
    {
        public static bool IsNullOrWhitespace(this string stringToCheck)
        {
            return stringToCheck == null || stringToCheck == string.Empty;
        }
    }
}
