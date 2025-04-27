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
    using System.Threading.Tasks;
    using Module = Autofac.Module;
    using Autofac.Core;
    using MediatR;
    using MediatR.Extensions.Autofac.DependencyInjection;
    using MediatR.Extensions.Autofac.DependencyInjection.Builder;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;


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
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
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
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        // Add JWT Authentication
                        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = context.Configuration["Jwt:Issuer"],
                                    ValidAudience = context.Configuration["Jwt:Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.Configuration["Jwt:Key"]))
                                };
                            });

                        services.AddAuthorization();

                        // Add controllers or other services as needed
                        services.AddControllers().AddNewtonsoftJson(options =>
                        {
                            options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                        });
                    })
                    .Configure(app =>
                    {
                        app.UseRouting();
                        app.UseAuthentication();
                        app.UseAuthorization();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                   // webBuilder.UseUrls("http://0.0.0.0:5006");

                    // uncomment below if using Docker container
                    //webBuilder.ConfigureKestrel(options =>
                    //{
                    //    options.ListenAnyIP(8080);
                    //});


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

#if true
                var configuration = MediatRConfigurationBuilder
                .Create(typeof(Program).Assembly) // Specify the assembly with your handlers
                .WithAllOpenGenericHandlerTypesRegistered() // Optional: Registers generic handlers
                .Build();

                builder.RegisterMediatR(configuration);
#else
                builder.RegisterType<Mediator>()
                       .As<IMediator>()
                       .InstancePerLifetimeScope(); // Scoped to the HTTP request in ASP.NET Core

                // Register ServiceFactory for MediatR to resolve handlers
                builder.Register(ctx => new ServiceFactory(t => ctx.Resolve(t)))
                       .As<ServiceFactory>();

                // Register all MediatR handlers in the assembly
                builder.RegisterAssemblyTypes(typeof(Program).Assembly) // Or typeof(Startup) if that's your intent
                       .Where(t => t.IsAssignableTo(typeof(IRequestHandler<,>)) ||
                                   t.IsAssignableTo(typeof(INotificationHandler<>)) ||
                                   t.IsAssignableTo(typeof(IPipelineBehavior<,>)))
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
#endif


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