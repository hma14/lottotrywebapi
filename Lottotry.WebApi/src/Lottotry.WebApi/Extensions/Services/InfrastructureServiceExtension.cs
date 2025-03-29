namespace Lottotry.WebApi.Extensions.Services
{
    using Lottotry.WebApi.Databases;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            // DbContext -- Do Not Delete
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<LottotryDbContext>(options =>
                    options.UseInMemoryDatabase($"LottotryDb"));
            }
            else
            {
                services.AddDbContext<LottotryDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("LottotryDb"),
                        builder => builder.MigrationsAssembly(typeof(LottotryDbContext).Assembly.FullName)));
            }

            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TestDb"));


            // Auth -- Do Not Delete
        }
    }
}
