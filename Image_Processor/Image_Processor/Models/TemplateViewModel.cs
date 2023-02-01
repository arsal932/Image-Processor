namespace Image_Processor.Models
{
    public class TemplateViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int TotalVideos { get; set; }
        public int TotalImages { get; set; }
        public bool Type { get; set; }
        public int categoryId { get; set; }
        public DateTime? Last_Modified { get; set; }
        //public List<IFormFile>? Files { get; set; }
    }
}
