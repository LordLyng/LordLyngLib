using System;

namespace LordLyngLib.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool NotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool NotNullOrWhiteSpace (this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        public static bool IsValidGuid (this string str)
        {
            if (string.IsNullOrWhiteSpace (str))
                return false;

            var canParse = Guid.TryParse (str, out var result);

            return canParse && result != default;
        }
    }
}
