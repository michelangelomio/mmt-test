using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Category.Queries.GetCategoryById;
using CleanArchitecture.Application.Category.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace Controllers
{
    public class CategoryControllerTests
    {
        private Mock<IMediator> _mediatorMock;


        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Test]
        public async Task GetCategoryByIdAsync_WhenCalled_ShouldReturnStatusCode200()
        {
            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetCategoryByIdQuery>(), CancellationToken.None))
                .ReturnsAsync(new GetCategoryByIdLookupModel {CategoryId = 1, Name = "Category1"});

            var controller = new CategoriesController(_mediatorMock.Object);

            var result = await controller.GetCategoryByIdAsync(1) as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetAllCategoriesAsync_WhenCalled_ShouldReturnStatusCode200()
        {
            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetCategoryListQuery>(), CancellationToken.None))
                .ReturnsAsync(new GetCategoryListReturnModel { Categories = new List<GetCategoryListLookupModel>()});

            var controller = new CategoriesController(_mediatorMock.Object);

            var result = await controller.GetCategoriesAsync() as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }
    }
}