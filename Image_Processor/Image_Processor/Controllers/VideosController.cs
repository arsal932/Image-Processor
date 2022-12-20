using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    public class VideosController : Controller
    {
        public IActionResult Editor()
        {
            return View();
        }
    }
}
