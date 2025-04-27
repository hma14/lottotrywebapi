namespace Lottotry.WebApi.Extensions.Services
{
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Services;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

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
            services.AddScoped<IEmailService, EmailService>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TestDb"));




            // Auth -- Do Not Delete
        }
    }
}
