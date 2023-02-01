using Image_Processor.Data.Services;
using Image_Processor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Image_Processor.Controllers
{
    public class TemplatesController : Controller
    {
        private readonly IService<CategoryViewModel, int, Response> _categoryService;
        private readonly IService<TemplateViewModel, int, Response> _templateService;
        public TemplatesController(IService<CategoryViewModel, int, Response> categoryService,
            IService<TemplateViewModel, int, Response> templateService)
        {
            _categoryService = categoryService;
            _templateService = templateService;
        }
        public async Task<IActionResult> List()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getList()
        {
            try
            {
                var templates = (List<TemplateViewModel>)(await _templateService.GetAll(null)).Object;
                return PartialView(templates != null ? templates : new List<TemplateViewModel>());
            }
            catch { }
            return PartialView(new List<CategoryViewModel>());
        }
        public async Task<IActionResult> Create()
        {
            ViewData["Categories"] = new SelectList((List<CategoryViewModel>)(await _categoryService.GetAll(null)).Object, "ID", "Name");
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TemplateViewModel templateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    templateViewModel.Last_Modified = DateTime.Now;
                    await _templateService.Insert(templateViewModel);
                    await _templateService.SaveChangesAsync();
                }
            }
            catch { }
            return RedirectToAction("List");
        }
        public async Task<IActionResult> AddFiles()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddFiles(TemplateViewModel templateViewModel)
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int template)
        {
            try
            {
                ViewData["Categories"] = new SelectList((List<CategoryViewModel>)(await _categoryService.GetAll(null)).Object, "ID", "Name");
                var Template = (TemplateViewModel)_templateService.GetById(template).Result.Object;
                if (Template != null)
                    return PartialView(Template);
            }
            catch { }
            return PartialView(new TemplateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TemplateViewModel templateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    templateViewModel.Last_Modified = DateTime.Now;
                    _templateService.Update(templateViewModel);
                    _templateService.SaveChanges();
                }
            }
            catch { }
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int template)
        {
            try
            {
                ViewData["Categories"] = new SelectList((List<CategoryViewModel>)(await _categoryService.GetAll(null)).Object, "ID", "Name");
                var Template = (TemplateViewModel)_templateService.GetById(template).Result.Object;
                if (Template != null)
                    return PartialView(Template);
            }
            catch { }
            return PartialView(new TemplateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TemplateViewModel templateViewModel)
        {
            try
            {
                await _templateService.Delete(templateViewModel.id);
                await _templateService.SaveChangesAsync();
            }
            catch { }
            return RedirectToAction("List");
        }
        //public async Task<IActionResult> ContactsList(int? SusbcriberList)
        //{
        //    ViewBag.page = "Contacts";
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> getContactsList(int? SusbcriberList)
        //{
        //    Thread.Sleep(2000);
        //    List<ContactViewModel> Contacts = new List<ContactViewModel>();
        //    Contacts.Add(new ContactViewModel() { FirstName = "Mahaz", LastName = "khan", Address = "H10 -Islamabad", Email = "Mahaz@gmail.com", Phone = "+42-12342123", DateOfBirth = DateTime.Now });
        //    Contacts.Add(new ContactViewModel() { FirstName = "Tanveer", LastName = "khan", Address = "G10 -Islamabad", Email = "Tanveer@gmail.com", Phone = "+42-12366123", DateOfBirth = DateTime.Now });
        //    Contacts.Add(new ContactViewModel() { FirstName = "Sadiq", LastName = "khan", Address = "F10 -Islamabad", Email = "Sadiq@gmail.com", Phone = "+42-12316523", DateOfBirth = DateTime.Now });

        //    return PartialView(Contacts);
        //}
        //[HttpGet]
        //public async Task<IActionResult> EditContact(int Contact)
        //{
        //    return PartialView(new ContactViewModel() { FirstName = "Mahaz", LastName = "khan", Address = "H10 -Islamabad", Email = "Mahaz@gmail.com", Phone = "+42-12342123", DateOfBirth = DateTime.Now });
        //}
        //[HttpPost]
        //public async Task<IActionResult> EditContact(ContactViewModel ContactViewModel)
        //{
        //    return RedirectToAction("ContactsList");
        //}
        //[HttpGet]
        //public async Task<IActionResult> DeleteContact(int Contact)
        //{
        //    return PartialView(new ContactViewModel() { FirstName = "Mahaz", LastName = "khan", Address = "H10 -Islamabad", Email = "Mahaz@gmail.com", Phone = "+42-12342123", DateOfBirth = DateTime.Now });
        //}
        //[HttpPost]
        //public async Task<IActionResult> DeleteContact(ContactViewModel ContactViewModel)
        //{
        //    return RedirectToAction("ContactsList");
        //}
    }
}
