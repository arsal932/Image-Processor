using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Image_Processor.Models
{
    public class CategoryViewModel
    {        
        [Required]
        [Column(nameof(ID), TypeName = "int")]
        public int ID { get; set; }

        [Required]
        [Column(nameof(Name), TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Column(nameof(Description), TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }
        [Column(nameof(Last_Modified), TypeName = "datetime")]
        public DateTime? Last_Modified { get; set; }
    }
}
