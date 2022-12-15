using Image_Processor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    public class TemplatesController : Controller
    {
        public async Task<IActionResult> List()
        {            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> getList()
        {
            Thread.Sleep(2000);
            List<TemplateViewModel> Templates = new List<TemplateViewModel>();
            Templates.Add(new TemplateViewModel() { Name = "Exam Template", Description= "this is the exam template description.",TotalImages=10,TotalVideos=20 });
            Templates.Add(new TemplateViewModel() { Name = "Cricket Template", Description = "this is the cricket template description.", TotalImages = 20, TotalVideos = 30 });
            Templates.Add(new TemplateViewModel() { Name = "Football Template", Description = "this is the football template description.", TotalImages = 40, TotalVideos = 50 });
            Templates.Add(new TemplateViewModel() { Name = "Custom Template", Description = "this is the custom template description.", TotalImages = 60, TotalVideos = 70 });
            return PartialView(Templates);
        }       
        public async Task<IActionResult> Create()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TemplateViewModel templateViewModel)
        {
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
            return PartialView(new TemplateViewModel() { Name = "Custom Template", Description = "this is the custom template description.", TotalImages = 60, TotalVideos = 70 } );
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TemplateViewModel templateViewModel)
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int template)
        {
            return PartialView(new TemplateViewModel() { Name = "Custom Template", Description = "this is the custom template description.", TotalImages = 60, TotalVideos = 70 });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TemplateViewModel templateViewModel)
        {
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
