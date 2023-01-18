namespace Image_Processor.Models
{
    public class Response
    {
        public object Object { get; set; }
        // 0/false for error ,1/true for success
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
