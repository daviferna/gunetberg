using System;
using System.Text.RegularExpressions;

namespace Gunetberg.Extension
{
    public static class StringExtension
    {
        public static bool HasEmailFormat(this string stringToCheck)
        {
            return Regex.IsMatch(stringToCheck, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
