namespace MailSystem.Contracts.Authentication
{
    public class CourierRegisterContract
    {
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}