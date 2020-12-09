using System;
using System.Collections.Generic;
using System.IO;
using Api.Entities;

namespace Api
{
    public interface IFileContext
    {
        List<User> Users { get; set; }
    }
    public class FileContext: IFileContext
    {
        public List<User> Users { get; set; }
        # region constructor

        public FileContext(string path)
        {
            Users = new List<User>();
            populateRowList(path);
        }
        # endregion
        # region private
        // There could be smarter logic, but implement it for single user object without some irow interface
        
        private void populateRowList(string path)
        {
            // Read file

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var line = streamReader.ReadLine();
                    while (line != null)
                    {
                        var user = parseTsvToObject(line);
                        Users.Add(user);
                        line = streamReader.ReadLine();
                        
                    }
                }
            }
        }
        
        // Could add some 'Schema' method, but i think it will be overhead for test task
        private User parseTsvToObject(string line)
        {
            var user = new User();
            var tokens = line.Split('\t');
            // Important not to create here try-catch, because we need exception raised
            user.Id = Convert.ToInt32(tokens[0]);
            user.Username = tokens[1];
            user.PasswordHash = tokens[2];
            return user;
        }
        # endregion
        # region public
        public static string FindFilePath(string fileName = "users.tsv")
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = $"{dir}/assets/{fileName}";
            return path;
        } 
        # endregion
    }
}