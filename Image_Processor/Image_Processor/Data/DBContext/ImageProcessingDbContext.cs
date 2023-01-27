using Image_Processor.Models.Entity_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Image_Processor.Data.DBContext
{
    public class ImageProcessingDbContext : IdentityDbContext<ApplicationUser>
    {
        public ImageProcessingDbContext(DbContextOptions<ImageProcessingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Categories>().HasIndex(c => c.CategoryName).IsUnique();
            builder.Entity<Templates>().HasIndex(c => c.TemplateName).IsUnique();
            builder.Entity<Templates>().HasOne(a => a.Category).WithMany(b => b.Templates).HasForeignKey(f => f.CategoryID).HasPrincipalKey(p => p.CategoryID);
            builder.Entity<Files>().HasOne(a => a.Template).WithMany(b => b.Files).HasForeignKey(f => f.TemplateID).HasPrincipalKey(p => p.TemplateID);
        }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Templates> Templates { get; set; }
        public virtual DbSet<Files> Files { get; set; }
    }
}

