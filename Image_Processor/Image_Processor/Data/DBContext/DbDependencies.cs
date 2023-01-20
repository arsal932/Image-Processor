using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Image_Processor.Data.DBContext
{
    public static class DbDependencies
    {
        public static void getDbDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ImageProcessingDbContext>(item => item.UseSqlServer(configuration.GetConnectionString(nameof(ImageProcessingDbContext))));
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options => {
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 3;
                }
                ).AddEntityFrameworkStores<ImageProcessingDbContext>();
        }
    }
}
