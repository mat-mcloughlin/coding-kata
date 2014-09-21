namespace CodingKata.Facts.Extensions
{
    using CodingKata.Extensions;

    using Xunit;
    using Xunit.Should;

    public class StringExtensionsFacts
    {
        [Fact]
        public void StringIsPalindrome()
        {
            var test = "Bo Bob";

            var actual = test.IsPalindrome();

            actual.ShouldBeTrue();
        }

        [Fact]
        public void StringIsntPalindrome()
        {
            var test = "Bo Boab";

            var actual = test.IsPalindrome();

            actual.ShouldBeFalse();
        }
    }
}
