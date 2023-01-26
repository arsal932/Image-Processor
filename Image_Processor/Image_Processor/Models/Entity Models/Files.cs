using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Image_Processor.Models.Entity_Models
{
    public class Files
    {
        [Key]
        [Required]
        [Column(nameof(FileID), TypeName = "int")]
        public int FileID { get; set; }
        [Required]
        [Column(nameof(TemplateID), TypeName = "int")]
        public int TemplateID { get; set; }

        [Required]
        [Column(nameof(Path), TypeName = "nvarchar(MAX)")]
        public string Path { get; set; }
        [Required]
        [Column(nameof(Type), TypeName = "BIT")]
        public bool Type { get; set; }
        [Column(nameof(DisplayName), TypeName = "nvarchar(200)")]
        public string? DisplayName { get; set; }
        [Column(nameof(Last_Modified), TypeName = "datetime")]
        public DateTime? Last_Modified { get; set; }
        public Templates Template { get;set;}

    }
}
