using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult view()
        {
            return View();
        }
        public IActionResult GetList()
        {
            Thread.Sleep(2000);
            return PartialView();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Edit(string name)
        {
            return RedirectToAction("view");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            return RedirectToAction("view");
        }
    }
}
