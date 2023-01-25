using System.ComponentModel.DataAnnotations;

namespace Image_Processor.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? returnUrl { get;set;}
        public bool RememberMe { get; set; }
    }
}
