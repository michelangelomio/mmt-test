using System;
using System.Collections.Generic;
using System.Text;
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
    public class CheckDbServiceTests : TestBase
    {
        private Mock<ITechnicalTestDbContext> _context;


        [SetUp]
        public void Setup()
        {
            _context = new Mock<ITechnicalTestDbContext>();
        }

        [Test]
        public async Task CheckProductIdAsync_WhenCalled_ReturnBoolean()
        {
            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var service = new CheckDbService(context);

            var result = await service.CheckProductIdAsync(1, CancellationToken.None);

            Assert.That(result.Equals(true));
        }

        [Test]
        public async Task CheckCategoryIdAsync_WhenCalled_ReturnBoolean()
        {
            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var service = new CheckDbService(context);

            var result = await service.CheckCategoryIdAsync(1, CancellationToken.None);

            Assert.That(result.Equals(true));
        }
    }
}
