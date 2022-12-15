namespace Image_Processor.Models
{
    public class TemplateViewModel
    {
        public string Name { get;set;}
        public string Description { get;set;}
        public int TotalVideos { get;set;}
        public int TotalImages { get; set; }
        public List<IFormFile> Files { get;set;}
    }
}
