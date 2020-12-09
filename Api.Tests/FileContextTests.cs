using System;
using System.Collections.Generic;
using Api.Entities;
using Xunit;
using Xunit.Abstractions;

namespace Api.Tests
{
    public class FileContextTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public FileContextTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestUsersList()
        {
            var filePath = FileContext.FindFilePath();
            var fileContext = new FileContext(filePath);
            foreach (var user in fileContext.Users)
            {
                _testOutputHelper.WriteLine(user.ToString());
            }

            Assert.True(fileContext.Users[0].Id == 1 &&
                        fileContext.Users[0].Username == "user" &&
                        fileContext.Users[0].PasswordHash ==
                        "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8");
        }
    }
}