using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Image_Processor.Models
{
    public class FileViewModel
    {        
        [Required]
        [Column(nameof(ID), TypeName = "int")]
        public int ID { get; set; }
        [Required]
        [Column(nameof(TemplateID), TypeName = "int")]
        public int TemplateID { get; set; }
        public string? TemplateName { get; set; }
        public string? CategoryName { get; set; }
        [Required]
        [Column(nameof(Path), TypeName = "nvarchar(MAX)")]
        public string Path { get; set; }
        [Required]
        [Column(nameof(Type), TypeName = "BIT")]
        public bool Type { get; set; }
        [Column(nameof(Name), TypeName = "nvarchar(200)")]
        public string? Name { get; set; }
        [Column(nameof(Last_Modified), TypeName = "datetime")]
        public DateTime? Last_Modified { get; set; }
    }
}
