using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CleanArchitecture.Infrastructure.Services;
using Common.Tests.TestBase;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TechnicalTest.DatabaseService.Context;
using TechnicalTest.DatabaseService.Interface;

namespace Services
{
    public class ProductServiceTests : TestBase
    {
        private Mock<ITechnicalTestDbContext> _context;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<ITechnicalTestDbContext>();
        }


        [Test]
        public async Task GetProductByIdAsync_WhenSucceded_ReturnGetProductByIdQueryLookupModel()
        {
            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var service = new ProductService(context);

            var result = await service.GetProductByIdAsync(1, CancellationToken.None);

            Assert.That(result.Name.Equals("Product1"));
        }

        [Test]
        public async Task GetProductByIdAsync_WhenFailed_ReturnNull()
        {
            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var service = new ProductService(context);

            var result = await service.GetProductByIdAsync(10, CancellationToken.None);

            Assert.That(result == null);
        }


        [Test]
        public async Task GetAllProductsByCategoryIdAsync_WhenCalled_ReturnGetProductListByCategoryIdReturnModel()
        {
            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var service = new ProductService(context);

            var result = await service.GetAllProductsByCategoryIdAsync(1, CancellationToken.None);

            Assert.That(result.Products.Count.Equals(2));
        }
    }
}