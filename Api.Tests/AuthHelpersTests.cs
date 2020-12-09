using System;
using Xunit;
using Xunit.Abstractions;

namespace Api.Tests
{
    public class AuthHelpersTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AuthHelpersTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestGetHashString()
        {
            Assert.Equal(Helpers.AuthHelper.GetHashString("password"),"5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8");
        }
    }
}