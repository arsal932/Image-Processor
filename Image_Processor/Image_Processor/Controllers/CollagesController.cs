using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers;
public class CollagesController : Controller
{
    public IActionResult Maker()
    {
        ViewBag.page = "Collages";
        return View();
    }
}
