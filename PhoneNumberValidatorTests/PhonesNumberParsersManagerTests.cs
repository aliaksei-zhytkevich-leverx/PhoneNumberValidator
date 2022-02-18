using PhoneNumberValidator;
using PhoneNumberValidator.Helpers;
using Xunit;

namespace PhoneNumberValidatorTests
{
    public class PhonesNumberParsersManagerTests
    {
        [Theory]
        [InlineData("0", "+41 79 257 3115")]
        [InlineData("0041", "004179 257 3115")]
        [InlineData("0", "079 257 3115")]
        [InlineData("0", "(0)79 / 257-31-15")]
        public void SwitzPositiveTest(string code, string phone)
        {
            // Arrange
            var manager = new PhonesNumberParsersManager(PrefixConstants.SwitzPrefix);

            //Act
            var exception = Record.Exception(() => manager.Parse(code, phone));

            //Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("+41", "0", "+49 414 11")]
        [InlineData("+41", "1", "(0)79 / 257-31-15")]
        public void NegativeTest(string prefix, string code, string phone)
        {
            // Arrange
            var manager = new PhonesNumberParsersManager(prefix);

            //Act
            var exception = Record.Exception(() => manager.Parse(code, phone));

            //Assert
            Assert.NotNull(exception);
        }
    }
}
