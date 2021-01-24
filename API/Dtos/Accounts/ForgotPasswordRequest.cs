using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}