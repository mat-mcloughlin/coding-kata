namespace CodingKata.Extensions
{
    using System.Linq;

    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            var sanitisedString = str.ToLower().Replace(" ", string.Empty);

            return sanitisedString.SequenceEqual(sanitisedString.Reverse());
        }
    }
}