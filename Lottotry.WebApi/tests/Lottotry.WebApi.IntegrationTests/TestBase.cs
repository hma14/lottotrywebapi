namespace Lottotry.WebApi.IntegrationTests
{
    using FluentAssertions;
    using Lottotry.WebApi.Domain.Users.Features;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.SqlServer;

    using static TestFixture;
    using Lottotry.WebApi.Databases;
    using Microsoft.EntityFrameworkCore;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }

    public class TestingServiceScope
    {
        private readonly IServiceScope _scope;
        public LottotryDbContext DbContext { get; }

        public TestingServiceScope()
        {
            var services = new ServiceCollection();

            // Add an in-memory database for testing
            services.AddDbContext<LottotryDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            // Add MediatR or other services if used in your project
            services.AddMediatR(typeof(UpdateUser.Command).Assembly);

            var provider = services.BuildServiceProvider();
            _scope = provider.CreateScope();
            DbContext = _scope.ServiceProvider.GetRequiredService<LottotryDbContext>();
        }

        public async Task InsertAsync<T>(T entity) where T : class
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task InsertAsync<T>(T entity1, T entity2) where T : class
        {
            DbContext.Set<T>().Add(entity1);
            DbContext.Set<T>().Add(entity2);
            await DbContext.SaveChangesAsync();
        }

        public async Task<T> ExecuteDbContextAsync<T>(Func<LottotryDbContext, Task<T>> operation)
        {
            return await operation(DbContext);
        }

        //public async Task<T> SendAsync<T>(T command) where T : IRequest
        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var mediator = _scope.ServiceProvider.GetRequiredService<IMediator>();
            return await mediator.Send(request);
        }
    }

}