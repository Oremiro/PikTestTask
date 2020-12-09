using System.Linq;
using Api.Entities;

namespace Api.EntityServices
{
    public interface IAuthService
    {
        User GetUserById(int id);
        User GetUserByUsernameAndPassword(string username, string password);
    }
    public class AuthService: IAuthService
    {
        private IFileContext _fileContext { get; set; }
        public AuthService()
        {
            var filePath = FileContext.FindFilePath();
            _fileContext = new FileContext(filePath);
        }

        public User GetUserById(int id)
        {
            var user = _fileContext.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var passwordHash = Helpers.AuthHelper.GetHashString(password);
            var user = _fileContext.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);
            return user;
        }
    }
}