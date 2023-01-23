using Image_Processor.Data.Services;
using Image_Processor.Models;
using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(IAccountService _account, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._account=_account;
        }
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
            if (ModelState.IsValid)
            {                
                var result =(IdentityResult) await _account.CreateAsync(signUpViewModel).Object;
                if (result.Succeeded)
                {
                    await _account.SignInAsync(signUpViewModel, isPersistent: false);                    
                    return RedirectToAction("Login", "Account");
                }
                foreach (var Error in result.Errors)
                    ModelState.AddModelError("", Error.Description);
            }
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
