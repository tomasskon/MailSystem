using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MailSystem.Contracts.Authentication
{
    public class CourierLoginContract
    {
        [Required]
        [MinLength(10), MaxLength(50)]
        public string EmailAddress { get; set; }
        
        [Required]
        [PasswordPropertyText]
        [MinLength(6), MaxLength(20)]
        public string Password { get; set; }
    }
}