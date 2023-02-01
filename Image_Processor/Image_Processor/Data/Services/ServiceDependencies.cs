using Image_Processor.Data.Services.Account;
using Image_Processor.Data.Services.Categories;
using Image_Processor.Data.Services.Files;
using Image_Processor.Data.Services.Templates;
using Image_Processor.Models;

namespace Image_Processor.Data.Services
{
    public static class ServiceDependencies
    {
        public static void getServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();            
            services.AddScoped<IService<Models.CategoryViewModel, int, Response>, CategoryService>();
            services.AddScoped<IService<Models.Entity_Models.Files, int, Response>, FileService>();
            services.AddScoped<IService<Models.TemplateViewModel, int, Response>, TemplateService>();
        }
    }
}
