using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Image_Processor.Data.DBContext
{
    public class ImageProcessingDbContext: IdentityDbContext<ApplicationUser>
    {
        public ImageProcessingDbContext(DbContextOptions<ImageProcessingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
