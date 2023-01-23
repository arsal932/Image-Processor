using Image_Processor.Models;
using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity;

namespace Image_Processor.Data.Services
{
    public interface IAccountService
    {
        Task<Response> GetUserByIDAsync(string id);
        void SignOutAsync();
        Task<Response> PasswordSignInAsync(string Email, string Password, bool RemeberMe, bool lockoutOnFailure);
        Task<Response> CreateAsync(SignUpViewModel signUpViewModel);
        Task<Response> UpdateAsync(ApplicationUser user);
        Response GeneratePasswordHash(ApplicationUser user, string password);
        Task<Response> ValidatePassword(ApplicationUser user, string pass);
        void UpdateRecordAsync(ApplicationUser user);
        Task SignInAsync(SignUpViewModel signUpViewModel, bool isPersistent);
        Task<Response> GetUserRole(ApplicationUser user);
        Task<Response> GetRole(string roleID);
        Task AddToRoleAsync(ApplicationUser user, string Role);
        Response GetUserByID(string id);
        Task<Response> GetUserAsync(string Email);
        Response GetUser(string Email);
        void AddRole(IdentityRole role);
        Task<Response> isRoleAssigned(string id);
        Response isRoleExists(IdentityRole role);
        void DeleteUser(string id);
        void SaveChangesAsync();
        void SaveChanges();
        void DeleteAssignedRole(string id);
        Task<Response> isExists(string ID);
        Response isUserExists(string email);
    }
}
