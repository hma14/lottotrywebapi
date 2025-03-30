namespace Lottotry.WebApi
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Module = Autofac.Module;
    using Autofac.Core;

    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
         

            using var scope = host.Services.CreateScope();

            //Read configuration from appSettings
            var services = scope.ServiceProvider;
            var hostEnvironment = services.GetService<IWebHostEnvironment>();
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true)
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            try
            {
                Log.Information("Starting application");
                await host.RunAsync();
            }
            catch (Exception e)
            {
                Log.Error(e, "The application failed to start correctly");
                throw;
            }
            finally
            {
                Log.Information("Shutting down application");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
#if false
                    webBuilder.UseStartup(typeof(Startup).GetTypeInfo().Assembly.FullName)
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseKestrel();
#else
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
#endif                
                }).ConfigureContainer<ContainerBuilder>(containerBuilder =>
                {
                    // Register your custom services here
                    // e.g., containerBuilder.RegisterType<MyService>().As<IMyService>();

                    // Ensure ASP.NET Core services are available to Autofac
                    containerBuilder.RegisterModule(new AutofacModule());
                });

        public class AutofacModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                // Add custom registrations here if needed

#if false  // below are examples

                // Register a simple service with scoped lifetime (default for ASP.NET Core)
                builder.RegisterType<MyService>()
                       .As<IMyService>()
                       .InstancePerLifetimeScope(); // Scoped to the HTTP request in ASP.NET Core

                // Register a service with a parameter (e.g., connection string)
                builder.RegisterType<SqlRepository>()
                       .As<IRepository>()
                       .WithParameter("connectionString", "Server=myServer;Database=myDB;Trusted_Connection=True;")
                       .InstancePerLifetimeScope();

                // Register a singleton instance
                builder.RegisterType<SomeSingleton>()
                       .As<ISomeSingleton>()
                       .SingleInstance(); // Only one instance ever created

                // Register an existing instance
                var specificInstance = new MyService();
                builder.RegisterInstance(specificInstance)
                       .As<IMyService>(); // Always resolves to this specific instance

                // Register a factory or delegate
                builder.Register(ctx =>
                {
                    var env = ctx.Resolve<IHostEnvironment>();
                    return new EnvironmentService(env.EnvironmentName);
                })
                .As<IEnvironmentService>()
                .InstancePerLifetimeScope();

                // Register all implementations of an interface in an assembly
                builder.RegisterAssemblyTypes(typeof(AutofacModule).Assembly)
                       .Where(t => t.Name.EndsWith("Repository"))
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();

                // Register a generic type
                builder.RegisterGeneric(typeof(GenericRepository<>))
                       .As(typeof(IGenericRepository<>))
                       .InstancePerLifetimeScope();

#endif
            }
        }
    }
}