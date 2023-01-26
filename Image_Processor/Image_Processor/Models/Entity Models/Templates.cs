using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Image_Processor.Models.Entity_Models
{
    [Table("Templates")]
    public class Templates
    {
        [Key]
        [Required]
        [Column(nameof(TemplateID), TypeName = "int")]
        public int TemplateID { get; set; }
        [Required]
        [Column(nameof(CategoryID), TypeName = "int")]
        public int CategoryID { get; set; }

        [Required]
        [Column(nameof(TemplateName), TypeName = "nvarchar(200)")]
        public string TemplateName { get; set; }
        [Column(nameof(Description), TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        [Required]
        [Column(nameof(EditorType), TypeName = "BIT")]
        public bool EditorType { get; set; }
        [Column(nameof(Last_Modified), TypeName = "datetime")]
        public DateTime? Last_Modified { get; set; }
        public Categories Category { get; set; }
        public List<Files> Files { get; set; }
    }
}
