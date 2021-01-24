using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}