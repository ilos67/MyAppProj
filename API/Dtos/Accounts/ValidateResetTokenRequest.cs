using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}