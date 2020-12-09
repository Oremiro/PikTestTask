using Api.EntityServices;
using Xunit;

namespace Api.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void TestGetUserById()
        {
            IAuthService authService = new AuthService();
            // More correct way - just create another user via context, and test his existence, but it test task, so i'll use that method
            var user = authService.GetUserById(1);
            Assert.True(user.Id == 1 && user.Username == "user" && user.PasswordHash == "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8");
        }
        
        [Fact]
        public void TestGetUserByUsernameAndPassword()
        {
            IAuthService authService = new AuthService();
            // More correct way - just create another user via context, and test his existence, but it test task, so i'll use that method
            var user = authService.GetUserByUsernameAndPassword("user", "password");
            Assert.True(user.Id == 1 && user.Username == "user" && user.PasswordHash == "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8");
        }
    }
}