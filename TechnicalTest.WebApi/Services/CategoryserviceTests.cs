using System.Threading;
using Common.Tests.TestBase;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Autofac;
using CleanArchitecture.Application.Category.Queries.GetCategoryById;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DatabaseService.Context;
using TechnicalTest.DatabaseService.Interface;

namespace Services
{
    public class CategoryserviceTests : TestBase
    {
        private Mock<ITechnicalTestDbContext> _context;


        [SetUp]
        public void Setup()
        {
            _context = new Mock<ITechnicalTestDbContext>();
        }

        [Test]
        public async Task GetCategoryByIdAsync_WhenCalled_ReturnGetCategoryByIdLookupModel()
        {
            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var service = new CategoryService(context);

            var result = await service.GetCategoryByIdAsync(1, CancellationToken.None);

            Assert.That(result.Name.Equals("Category1"));
        }


        [Test]
        public async Task GetAllCategoriesAsync_WhenCalled_ReturnGetCategoryListReturnModel()
        {
            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var service = new CategoryService(context);

            var result = await service.GetAllCategoriesAsync(CancellationToken.None);

            Assert.That(result.Categories.Count.Equals(2));
        }
    }
}