using Pharmalina.Domain.Exceptions;
using Pharmalina.Domain.ValueObjects;
using Xunit;

namespace Pharmalina.Domain.Tests.ValueObjects
{
    public class AdAccountTests
    {
        [Fact]
        public void ShouldHaveCorrectDomain()
        {
            var account = new AdAccount("am\\moh");

            Assert.Equal("am", account.Domain);
        }

        [Fact]
        public void ShouldHaveCorrectName()
        {
            var account = new AdAccount("am\\moh");

            Assert.Equal("moh", account.Name);
        }

        [Fact]
        public void ToStringReturnsDomainAndName()
        {
            const string value = "am\\moh";

            var account = new AdAccount(value);

            Assert.Equal(value, account.ToString());
        }

        [Fact]
        public void ImplicitConversionToStringReturnsDomainAndName()
        {
            const string value = "am\\moh";

            var account = new AdAccount(value);

            string result = account;

            Assert.Equal(value, result);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            var account = (AdAccount)"am\\moh";

            Assert.Equal("am", account.Domain);
            Assert.Equal("moh", account.Name);
        }

        [Fact]
        public void ShouldThrowAdAccountInvalidExceptionForInvalidAdAccount()
        {
            Assert.Throws<AdAccountInvalidException>(() => (AdAccount)"ammoh");
        }
    }
}
