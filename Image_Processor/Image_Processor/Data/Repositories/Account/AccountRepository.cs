using Image_Processor.Data.DBContext;
using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Image_Processor.Data.Repositories.Account
{
    public class AccountRepository: IAccountRepository
    {
        private readonly ImageProcessingDbContext ImageProcessingDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountRepository(ImageProcessingDbContext ImageProcessingDbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.ImageProcessingDbContext = ImageProcessingDbContext;
        }
        public async Task<ApplicationUser> GetUserByIDAsync(string id)
        {
            return
                await (ImageProcessingDbContext.Users.Where(c => c.Id == id).FirstOrDefaultAsync());
        }
        public async void Register(ApplicationUser applicationUser)
        {

        }
        
        public async void SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }        
        public async Task<SignInResult> PasswordSignInAsync(string Email, string Password, bool RemeberMe, bool lockoutOnFailure)
        {          
            return await signInManager.PasswordSignInAsync(Email, Password, RemeberMe, lockoutOnFailure);
        }
        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }
        public async Task<IdentityResult> UpdateAsync(ApplicationUser user)
        {
            return await userManager.UpdateAsync(user);
        }
        public string GeneratePasswordHash(ApplicationUser user, string password)
        {
            return userManager.PasswordHasher.HashPassword(user, password);
        }
        public async Task<IdentityResult> ValidatePassword(ApplicationUser user, string pass)
        {
            var passwordValidator = new PasswordValidator<ApplicationUser>();
            return await passwordValidator.ValidateAsync(userManager, user, pass);
        }
        public void UpdateRecordAsync(ApplicationUser user)
        {
            ImageProcessingDbContext.Users.Update(user);
        }
        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            await signInManager.SignInAsync(user, isPersistent: isPersistent);
        }
        public async Task<string> GetUserRole(ApplicationUser user)
        {
            var userRole = await ImageProcessingDbContext.UserRoles.Where(c => c.UserId == user.Id).FirstOrDefaultAsync();
            if (userRole != null)
                return userRole.RoleId;
            return "";
        }
        public async Task<string> GetRole(string roleID)
        {
            var role = await ImageProcessingDbContext.Roles.Where(c => c.Id == roleID).FirstOrDefaultAsync();
            if (role != null)
                return role.Name.ToLower();
            return "";
        }
        public async Task AddToRoleAsync(ApplicationUser user, string Role)
        {
            await userManager.AddToRoleAsync(user, Role);
        }
        public ApplicationUser GetUserByID(string id)
        {
            return
                (ImageProcessingDbContext.Users.Where(c => c.Id == id).FirstOrDefault());
        }
        public async Task<ApplicationUser> GetUserAsync(string Email)
        {
            return
                await (ImageProcessingDbContext.Users.Where(c => c.Email.Trim().ToLower().Equals(Email.Trim().ToLower())).FirstOrDefaultAsync());
        }
        public ApplicationUser GetUser(string Email)
        {
            return
                (ImageProcessingDbContext.Users.Where(c => c.Email.Trim().ToLower().Equals(Email.Trim().ToLower())).FirstOrDefault());
        }
        public void AddRole(IdentityRole role)
        {
            ImageProcessingDbContext.Roles.Add(role);
        }
        public async Task<bool> isRoleAssigned(string id)
        {
            return await ImageProcessingDbContext.UserRoles.AnyAsync(c => c.UserId == id);
        }
        public bool isRoleExists(IdentityRole role)
        {
            return ImageProcessingDbContext.Roles.Any(c => c.Name.Trim().ToLower().Equals(role.Name.Trim().ToLower()));
        }
        public void DeleteUser(string id)
        {
            ImageProcessingDbContext.Users.Remove(GetUserByID(id));
        }
        public async void SaveChangesAsync()
        {
            await ImageProcessingDbContext.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            ImageProcessingDbContext.SaveChanges();
        }
        public void DeleteAssignedRole(string id)
        {
            ImageProcessingDbContext
                .UserRoles.RemoveRange(ImageProcessingDbContext.UserRoles.Where(c => c.UserId == id).ToList());
        }
        public async Task<bool> isExists(string ID)
        {
            return await ImageProcessingDbContext.Users.AnyAsync(c => c.Id == ID);
        }
        public bool isUserExists(string email)
        {
            return ImageProcessingDbContext.Users.Any(c => c.NormalizedEmail.Trim().ToLower().Equals(email.Trim().ToLower()));
        }
    }
}
