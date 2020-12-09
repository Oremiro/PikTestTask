namespace Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public override string ToString()
        {
            return $"<Id: {Id}, Username: {Username}, PasswordHash: {PasswordHash}>";
        }
    }
}