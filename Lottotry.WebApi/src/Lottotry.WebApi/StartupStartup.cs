namespace Lottotry.WebApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Lottotry.WebApi.Extensions.Services;
    using Lottotry.WebApi.Extensions.Application;
    using Serilog;

    public class StartupStartup
    {
        public IConfiguration _config { get; }
        public IWebHostEnvironment _env { get; }

        public StartupStartup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _config = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();

            // TODO update CORS for your env
            services.AddCorsService("Lottotry.WebApiCorsPolicy");
            services.AddInfrastructure(_config, _env);
            
            services.AddApiVersioningExtension();
            services.AddWebApiServices();
            services.AddHealthChecks();

            // Dynamic Services
            services.AddSwaggerExtension(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            // For elevated security, it is recommended to remove this middleware and set your server to only listen on https.
            // A slightly less secure option would be to redirect http to 400, 505, etc.
            app.UseHttpsRedirection();

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
