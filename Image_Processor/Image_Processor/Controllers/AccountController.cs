using Image_Processor.Data.Services.Account;
using Image_Processor.Models;
using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Image_Processor.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(IAccountService _account, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._account = _account;
        }
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Authentication");
        }
        public async Task<IActionResult> logout()
        {
            _account.SignOutAsync();
            return RedirectToAction("Authentication");
        }
        public IActionResult Authentication(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
                ViewBag.returnUrl = returnUrl;
            return View();
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Authentication", new { returnUrl = returnUrl });
            return PartialView(new LoginViewModel() { returnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = (Microsoft.AspNetCore.Identity.SignInResult)_account.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false).Result.Object;
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(loginViewModel.returnUrl))
                        return Redirect(loginViewModel.returnUrl);
                    return RedirectToAction("gallery", "Home");
                }
                else
                    ModelState.AddModelError(string.Empty, "Invalid Attempt!.");
            }
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
                var result = (IdentityResult)_account.CreateAsync(signUpViewModel).Result.Object;
                if (result.Succeeded)
                {
                    await _account.SignInAsync(signUpViewModel, isPersistent: false);
                    return RedirectToAction("gallery", "Home");
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
