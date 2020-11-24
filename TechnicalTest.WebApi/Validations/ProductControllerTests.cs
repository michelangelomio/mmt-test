using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Product.Queries.GetProductBytId;
using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebApi.Controllers;

namespace Controllers
{
    public class ProductControllerTests
    {
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Test]
        public async Task GetProductByIdAsync_WhenCalled_ShouldReturnStatusCode200()
        {
            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetProductByIdQuery>(), CancellationToken.None))
                .ReturnsAsync(new GetProductByIdQueryLookupModel());

            var controller = new ProductsController(_mediatorMock.Object);

            var result = await controller.GetProductByIdAsync(1) as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task GetAllProductsByCategoryIdAsync_WhenCalled_ShouldReturnStatusCode200()
        {
            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetProductListByCategoryIdQuery>(), CancellationToken.None))
                .ReturnsAsync(new GetProductListByCategoryIdReturnModel { Products = new List<GetProductListByCategoryIdQueryLookupModel>()});

            var controller = new ProductsController(_mediatorMock.Object);

            var result = await controller.GetProductsByCategoryIdAsync(1) as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }
    }
}