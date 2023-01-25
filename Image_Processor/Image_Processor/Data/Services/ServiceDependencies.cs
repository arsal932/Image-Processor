using Image_Processor.Data.Services.Account;

namespace Image_Processor.Data.Services
{
    public static class ServiceDependencies
    {
        public static void getServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
