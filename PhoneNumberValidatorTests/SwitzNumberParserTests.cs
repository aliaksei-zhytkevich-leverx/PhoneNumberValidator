using PhoneNumberValidator.Helpers;
using Xunit;

namespace PhoneNumberValidatorTests
{
    public class SwitzNumberParserTests
    {
        [Theory]
        [InlineData("+1", "0", "+1792573115", "792573115")]
        [InlineData("+41", "0", "+41792573115", "792573115")]
        [InlineData("+141", "0", "+141792573115", "792573115")]
        [InlineData("+41", "0", "0792573115", "792573115")]
        [InlineData("+41", "01", "01792573115", "792573115")]
        [InlineData("+41", "142", "142792573115", "792573115")]
        public void CleanPositiveTest(string prefix, string? code, string phone, string expectedResult)
        {
            // Arrange
            var parser = new SwitzNumberParser();

            // Act
            var result = parser.Clean(prefix, code, phone);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("283563245")]
        public void IsValidPhonePositiveTest(string phone)
        {
            // Arrange
            var parser = new SwitzNumberParser();

            // Act
            var result = parser.IsValidPhone(phone);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("0")]
        [InlineData("a")]
        [InlineData("gsdf5462132dfgs6da")]
        [InlineData("943861")]
        [InlineData("947325668323861")]
        public void IsValidPhoneNegativeTest(string phone)
        {
            // Arrange
            var parser = new SwitzNumberParser();

            // Act
            var result = parser.IsValidPhone(phone);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("+41", "792573115", "+41792573115")]
        public void FormatPositiveTest(string prefix, string phone, string expectedResult)
        {
            // Arrange
            var parser = new SwitzNumberParser();

            // Act
            var result = parser.Format(prefix, phone);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}