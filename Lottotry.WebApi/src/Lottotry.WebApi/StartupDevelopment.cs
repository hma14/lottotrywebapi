namespace Lottotry.WebApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Lottotry.WebApi.Seeders.DummyData;
    using Lottotry.WebApi.Databases;
    using Lottotry.WebApi.Extensions.Services;
    using Lottotry.WebApi.Extensions.Application;
    using Serilog;
    using Microsoft.AspNetCore.DataProtection;
    using System.IO;
    using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
    using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

    public class StartupDevelopment
    {
        public IConfiguration _config { get; }
        public IWebHostEnvironment _env { get; }

        public StartupDevelopment(IConfiguration configuration, IWebHostEnvironment env)
        {
            _config = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsService("Lottotry.WebApiCorsPolicy");
            services.AddInfrastructure(_config, _env);
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddApiVersioningExtension();
            services.AddWebApiServices();
            services.AddHealthChecks();

            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"D:\lottotry_new\temp-keys\"))
                .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                });

            //services.AddDataProtection().DisableAutomaticKeyGeneration();

            // Dynamic Services
            services.AddSwaggerExtension(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            // Entity Context - Do Not Delete

            using (var context = app.ApplicationServices.GetService<LottotryDbContext>())
            {
                context.Database.EnsureCreated();

                // LottotryDbContext Seeders

                    BC49Seeder.SeedSampleBC49Data(app.ApplicationServices.GetService<LottotryDbContext>());
                    Lotto649Seeder.SeedSampleLotto649Data(app.ApplicationServices.GetService<LottotryDbContext>());                    
                    LottoMaxSeeder.SeedSampleLottoMaxData(app.ApplicationServices.GetService<LottotryDbContext>());
            }


            app.UseCors("Lottotry.WebApiCorsPolicy");

            app.UseSerilogRequestLogging();
            app.UseRouting();

            app.UseErrorHandlingMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/api/health");
                endpoints.MapControllers();
            });

            // Dynamic App
            app.UseSwaggerExtension(_config);
        }
    }
}