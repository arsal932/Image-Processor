using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Image_Processor.Models.Entity_Models
{
    
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [Required]
        [Column(nameof(CategoryID), TypeName = "int")]
        public int CategoryID { get; set; }
       
        [Required]
        [Column(nameof(CategoryName), TypeName = "nvarchar(200)")]
        public string CategoryName { get; set; }
        [Column(nameof(Description), TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }
        [Column(nameof(Last_Modified), TypeName = "datetime")]
        public DateTime? Last_Modified { get; set; }
        public List<Templates> Templates { get;set;}
       
    }
}
