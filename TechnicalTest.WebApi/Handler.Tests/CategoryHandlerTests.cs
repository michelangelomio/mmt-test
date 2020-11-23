using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using CleanArchitecture.Application.Category.Queries.GetCategoryById;
using CleanArchitecture.Application.Category.Queries.GetCategoryList;
using CleanArchitecture.Application.Common.Interfaces.Services;
using Common.Tests.TestBase;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TechnicalTest.DatabaseService.Context;

namespace Handler.Tests
{
    public class CategoryHandlerTests : TestBase
    {
        private Mock<ICategoryService> _categoryServiceMock;

        [SetUp]
        public void Setup()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
        }

        #region Query tests

        [Test]
        public async Task GetCategoryByIdQueryHandler_WhenCalled_ReturnGetCategoryByIdLookupModel()
        {
            var returnModel = new GetCategoryByIdLookupModel
            {
                CategoryId = 1,
                Name = "Category1"
            };

            _categoryServiceMock
                .Setup(x => x.GetCategoryByIdAsync(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(returnModel);

            var query = new GetCategoryByIdQuery {CategoryId = 1};

            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var handler = new GetCategoryByIdQueryHandler(_categoryServiceMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual("Category1", result.Name);
        }


        [Test]
        public async Task GetCategoyListQueryHandler_WhenCalled_ReturnGetCategoryByIdLookupModel()
        {
            var returnModel = new GetCategoryListReturnModel
            {
                Categories = new List<GetCategoryListLookupModel>
                {
                    new GetCategoryListLookupModel
                    {
                        CategoryId = 1,
                        Name = "Category1"
                    },
                    new GetCategoryListLookupModel
                    {
                        CategoryId = 2,
                        Name = "Category2"
                    }
                }
            };

            _categoryServiceMock
                .Setup(x => x.GetAllCategoriesAsync(CancellationToken.None))
                .ReturnsAsync(returnModel);

            var query = new GetCategoryListQuery();

            var container = Registrations();

            await using var scope = container.BeginLifetimeScope();

            var options = scope.Resolve<DbContextOptions<TechnicalTestDbContext>>();

            await using var context = new TechnicalTestDbContext(options);

            await SeedMockDataAsync(context);

            var handler = new GetCategoyListQueryHandler(_categoryServiceMock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(2, result.Categories.Count);
            Assert.AreEqual("Category1", result.Categories[0].Name);
            Assert.AreEqual("Category2", result.Categories[1].Name);
        }

        #endregion
    }
}