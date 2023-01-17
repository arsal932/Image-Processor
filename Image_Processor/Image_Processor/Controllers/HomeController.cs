using Image_Processor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Image_Processor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            return View();
        }
        public IActionResult Templates()
        {
            return View();
        }
        public IActionResult CreateEvent()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult CreateEvent(string obj)
        {
            return RedirectToAction("CreateEvent");
        }
        public IActionResult EditEvent()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult EditEvent(string obj)
        {
            return RedirectToAction("CreateEvent");
        }
        [HttpPost]
        public IActionResult DeleteEvent(string obj)
        {
            return RedirectToAction("CreateEvent");
        }
        public IActionResult ContentPlanner()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}