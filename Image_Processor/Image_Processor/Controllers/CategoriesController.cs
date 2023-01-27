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
            try
            {
                var categories = (List<CategoryViewModel>)(await _categoryService.GetAll(null)).Object;
                return PartialView(categories != null ? categories : new List<CategoryViewModel>());
            }
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
                    await _categoryService.SaveChangesAsync();
                }
            }
            catch { }
            return RedirectToAction("view");
        }
        [HttpGet]
        public IActionResult Edit(int category)
        {
            try
            {
                var Category = (CategoryViewModel)_categoryService.GetById(category).Result.Object;
                if (Category != null)
                    return PartialView(Category);
            }
            catch { }
            return PartialView(new CategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Update(categoryViewModel);
                    _categoryService.SaveChanges();
                }
            }
            catch { }
            return RedirectToAction("view");
        }
        [HttpGet]
        public IActionResult Delete(int category)
        {
            try
            {
                var Category = (CategoryViewModel)_categoryService.GetById(category).Result.Object;
                if (Category != null)
                    return PartialView(Category);
            }
            catch { }
            return PartialView(new CategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.Delete(categoryViewModel.ID);
                    await _categoryService.SaveChangesAsync();
                }
            }
            catch { }
            return RedirectToAction("view");
        }
    }
}
