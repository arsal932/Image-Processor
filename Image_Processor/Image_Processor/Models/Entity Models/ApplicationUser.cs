using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Image_Processor.Models.Entity_Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Column(nameof(FirstName), TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(nameof(LastName), TypeName = "nvarchar(20)")]
        public string LastName { get; set; }                
        public string? ImagePath { get; set; }      
      
        //[NotMapped]
    }
}
