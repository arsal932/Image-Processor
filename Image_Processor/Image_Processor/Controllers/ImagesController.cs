using Image_Processor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers;
public class ImagesController : Controller
{
    public async Task<IActionResult> Gallery()
    {
        return View();
    }
    public async Task<IActionResult> GetTemplates()
    {
        Thread.Sleep(2000);
        return PartialView();
    }
    public async Task<IActionResult> Template()
    {
        return View();
    }
    public async Task<IActionResult> GetTemplate()
    {
        Thread.Sleep(2000);
        return PartialView();
    }
    public async Task<IActionResult> List()
    {
        ViewBag.page = "Images";
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> getList()
    {
        Thread.Sleep(2000);
        List<ImagesViewModel> Images = new List<ImagesViewModel>();
        Images.Add(new ImagesViewModel() { DisplayFileName = "Image1DisplayName",OriginalFileName="Image1.png",Path="/Images/Image1",Ext="png" });
        Images.Add(new ImagesViewModel() { DisplayFileName = "Image2DisplayName", OriginalFileName = "Image2.jpg", Path = "/Images/Image2", Ext = "jpg" });
        Images.Add(new ImagesViewModel() { DisplayFileName = "Image3DisplayName", OriginalFileName = "Image3.png", Path = "/Images/Image3", Ext = "png" });
        Images.Add(new ImagesViewModel() { DisplayFileName = "Image4DisplayName", OriginalFileName = "Image4.jpg", Path = "/Images/Image4", Ext = "jpg" });
        Images.Add(new ImagesViewModel() { DisplayFileName = "Image5DisplayName", OriginalFileName = "Image5.png", Path = "/Images/Image5", Ext = "png" });
        Images.Add(new ImagesViewModel() { DisplayFileName = "Image6DisplayName", OriginalFileName = "Image6.jpg", Path = "/Images/Image6", Ext = "jpg" });
        return PartialView(Images);
    }
    public async Task<IActionResult> UploadImage()
    {
        return PartialView();
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadImage(ImagesViewModel imagesViewModel)
    {
        return RedirectToAction("List");
    }   
    [HttpGet]
    public async Task<IActionResult> Delete(int image)
    {
        return PartialView(new ImagesViewModel() { DisplayFileName = "School",OriginalFileName="MyImage.png",Path="/Images/Editor/MyImage.png" });
    }
    [HttpPost]
    public async Task<IActionResult> Delete(ImagesViewModel imagesViewModel)
    {
        return RedirectToAction("List");
    }
    [HttpGet]
    public IActionResult ImageEditor()
    {
        ViewBag.page = "Image Editor";
        return View();
    }
}
