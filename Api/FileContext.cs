using System.Collections.Generic;
using System.IO;
using Api.Entities;

namespace Api
{
    public interface IFileContext
    {
        
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
                    while (streamReader.ReadLine() != null)
                    {
                        
                    }
                }
            }
        }
        
        // Could add some 'Schema' method, but i think it will be overhead for test task
        private User parseTsvToObject(string line)
        {
            var user = new User();
            
        }
        # endregion
        # region public
        public static string FindFilePath(string fileName = "users.tsv")
        {
            var dir = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString());
            var path = $"{dir}/assets/{fileName}";
            return path;
        } 
        # endregion
    }
}