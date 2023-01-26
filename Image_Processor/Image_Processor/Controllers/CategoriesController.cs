using Image_Processor.Data.Services;
using Image_Processor.Models;
using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IService<CategoryViewModel, int, Response> _categoryService;
        public CategoriesController(IService<CategoryViewModel, int, Response> _categoryService)
        {
            this._categoryService = _categoryService;
        }
        public IActionResult view()
        {
            return View();
        }
        public async Task<IActionResult> GetList()
        {
            try { return PartialView((List<CategoryViewModel>)(await _categoryService.GetAll(null)).Object); }
            catch { }
            return PartialView(new List<CategoryViewModel>());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView(new CategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.Insert(categoryViewModel);
                }
            }
            catch { }
            return RedirectToAction("view");
        }
    }
}
