using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult view()
        {
            return View();
        }
    }
}
