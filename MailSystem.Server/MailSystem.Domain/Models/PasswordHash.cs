namespace MailSystem.Domain.Models
{
    public class PasswordHash
    {
        public string Hash { get; set; }
        
        public byte[] Salt { get; set; }
    }
}