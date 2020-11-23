using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Application.Product.Queries.GetProductBytId;
using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;
using Common.Tests.TestBase;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TechnicalTest.DatabaseService.Context;

namespace Handler.Tests
{
    public class ProductHandlerTests : TestBase
    {
        private Mock<IProductService> _productServiceMock;

        [SetUp]
        public void Setup()
        {
            _productServiceMock = new Mock<IProductService>();
        }

        #region Query tests

        [Test]
        public async Task GetProductByIdQueryHandler_WhenCalled_ReturnGetCategoryByIdLookupModel()
        {
            var returnModel = new GetProductByIdQueryLookupModel
            {
                ProductId = 1,
                Name = "Product1"
            };

            _productServiceMock
                .Setup(x => x.GetProductByIdAsync(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(returnModel);

            var query = new GetProductByIdQuery {ProductId = 1};

            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var handler = new GetProductByIdQueryHandler(_productServiceMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual("Product1", result.Name);
        }


        [Test]
        public async Task GetProductListByCategoryIdQueryHandler_WhenCalled_ReturnGetCategoryByIdLookupModel()
        {
            var returnModel = new GetProductListByCategoryIdReturnModel
            {
                Products = new List<GetProductListByCategoryIdQueryLookupModel>
                {
                    new GetProductListByCategoryIdQueryLookupModel
                    {
                        ProductId = 1,
                        Name = "Product1"
                    },
                    new GetProductListByCategoryIdQueryLookupModel
                    {
                        ProductId = 2,
                        Name = "Product2"
                    }
                }
            };

            _productServiceMock
                .Setup(x => x.GetAllProductsByCategoryIdAsync(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(returnModel);

            var query = new GetProductListByCategoryIdQuery();

            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var handler = new GetProductListByCategoryIdQueryHandler(_productServiceMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(2, result.Products.Count);
            Assert.AreEqual("Product1", result.Products[0].Name);
            Assert.AreEqual("Product2", result.Products[1].Name);
        }

        #endregion
    }
}