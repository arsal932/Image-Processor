using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity;

namespace Image_Processor.Data.Repositories.Account
{
    interface IAccountRepository
    {
        Task<ApplicationUser> GetUserByIDAsync(string id);
        void SignOutAsync();
        Task<SignInResult> PasswordSignInAsync(string Email, string Password, bool RemeberMe, bool lockoutOnFailure);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        string GeneratePasswordHash(ApplicationUser user, string password);
        Task<IdentityResult> ValidatePassword(ApplicationUser user, string pass);
        void UpdateRecordAsync(ApplicationUser user);
        Task SignInAsync(ApplicationUser user, bool isPersistent);
        Task<string> GetUserRole(ApplicationUser user);
        Task<string> GetRole(string roleID);
        Task AddToRoleAsync(ApplicationUser user, string Role);
        ApplicationUser GetUserByID(string id);
        Task<ApplicationUser> GetUserAsync(string Email);
        ApplicationUser GetUser(string Email);
        void AddRole(IdentityRole role);
        Task<bool> isRoleAssigned(string id);
        bool isRoleExists(IdentityRole role);
        void DeleteUser(string id);
        void SaveChangesAsync();
        void SaveChanges();
        void DeleteAssignedRole(string id);
        Task<bool> isExists(string ID);
        bool isUserExists(string email);
    }
}
