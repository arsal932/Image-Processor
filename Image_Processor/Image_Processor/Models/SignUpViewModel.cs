using System.ComponentModel.DataAnnotations;

namespace Image_Processor.Models
{
    public class SignUpViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }        
        [Required]
        [EmailAddress]
        [Display(Name = "User Email")]
        public string Email { get; set; }
        [Required]        
        [Display(Name = "User Name")]
        public string UserName { get; set; }       
    }
}
