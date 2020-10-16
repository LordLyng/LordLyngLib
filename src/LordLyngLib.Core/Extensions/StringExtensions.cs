using System;

namespace LordLyngLib.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return str.IsNullOrEmpty();
        }

        public static bool NotNullOrEmpty(this string str)
        {
            return !str.IsNullOrEmpty();
        }

        public static bool IsNullOrWhitespace(this string str)
        {
            return str.IsNullOrWhitespace();
        }

        public static bool NotNullOrWhitespace(this string str)
        {
            return !str.IsNullOrWhitespace();
        }

        public static bool IsValidGuid(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            var canParse = Guid.TryParse(str, out var result);

            return canParse && result != default;
        }
    }
}