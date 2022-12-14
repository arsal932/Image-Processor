using Image_Processor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Authentication()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            return RedirectToAction("Authentication");
        }
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            return RedirectToAction("Authentication");
        }
        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            return RedirectToAction("Authentication");
        }
    }
}
