using Image_Processor.Data.DBContext;
using Image_Processor.Data.Repositories.Account;
using Image_Processor.Models;
using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity;

namespace Image_Processor.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountRepository _accountRepository;
        public AccountService(ImageProcessingDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _accountRepository = new AccountRepository(context, userManager, signInManager);
        }
        public void AddRole(IdentityRole role)
        {
            try
            {
                _accountRepository.AddRole(role);
            }
            catch { }
        }

        public async Task AddToRoleAsync(ApplicationUser user, string Role)
        {
            try
            {
                await _accountRepository.AddToRoleAsync(user, Role);
            }
            catch { }
        }

        public async Task<Response> CreateAsync(ApplicationUser user, string password)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.CreateAsync(user, password);
                response.Message = "User account created.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public void DeleteAssignedRole(string id)
        {
            try
            {
                _accountRepository.DeleteAssignedRole(id);
            }
            catch { }
        }

        public void DeleteUser(string id)
        {
            try
            {
                _accountRepository.DeleteUser(id);
            }
            catch { }
        }

        public Response GeneratePasswordHash(ApplicationUser user, string password)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = _accountRepository.GeneratePasswordHash(user, password);
                response.Message = "Password has generated.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public async Task<Response> GetRole(string roleID)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = _accountRepository.GetRole(roleID);
                response.Message = "Roles fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public Response GetUser(string Email)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = _accountRepository.GetUser(Email);
                response.Message = "User record fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public async Task<Response> GetUserAsync(string Email)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.GetUserAsync(Email);
                response.Message = "User record fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public Response GetUserByID(string id)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = _accountRepository.GetUserByID(id);
                response.Message = "User record fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public async Task<Response> GetUserByIDAsync(string id)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.GetUserByIDAsync(id);
                response.Message = "User record fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public async Task<Response> GetUserRole(ApplicationUser user)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.GetUserRole(user);
                response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public async Task<Response> isExists(string ID)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.isExists(ID);
                //response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public async Task<Response> isRoleAssigned(string id)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.isRoleAssigned(id);
                //response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public Response isRoleExists(IdentityRole role)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = _accountRepository.isRoleExists(role);
                //response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public Response isUserExists(string email)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = _accountRepository.isUserExists(email);
                //response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public async Task<Response> PasswordSignInAsync(string Email, string Password, bool RemeberMe, bool lockoutOnFailure)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.PasswordSignInAsync(Email, Password, RemeberMe, lockoutOnFailure);
                //response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public void SaveChanges()
        {
            try
            {
                _accountRepository.SaveChanges();
            }
            catch { }
        }

        public void SaveChangesAsync()
        {
            try
            {
                _accountRepository.SaveChangesAsync();
            }
            catch { }
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            try
            {
                await _accountRepository.SignInAsync(user, isPersistent);
            }
            catch { }
        }

        public void SignOutAsync()
        {
            try
            {
                _accountRepository.SignOutAsync();
            }
            catch { }
        }

        public async Task<Response> UpdateAsync(ApplicationUser user)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.UpdateAsync(user);
                //response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }

        public void UpdateRecordAsync(ApplicationUser user)
        {
            try
            {
                _accountRepository.UpdateRecordAsync(user);
            }
            catch { }
        }

        public async Task<Response> ValidatePassword(ApplicationUser user, string pass)
        {
            var response = new Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _accountRepository.ValidatePassword(user, pass);
                //response.Message = "User role fetched.";
                response.IsSuccess = true;
            }
            catch { response.Message = "Something went wrong."; }
            return response;
        }
    }
}
