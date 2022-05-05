namespace MailSystem.Contracts.Users
{
    public class CreateUserContract
    {
        public string Email { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}