using System.Threading.Tasks;
using CleanArchitecture.Application.Product.Queries.GetProductBytId;
using CleanArchitecture.Application.Product.Queries.GetProductList;
using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProduct/{productId}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery {ProductId = productId}));
        }

        [HttpGet("GetProductsByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryIdAsync(int categoryId)
        {
            return Ok(await _mediator.Send(new GetProductListByCategoryIdQuery {SelectedCategoryId = categoryId}));
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetProductListQuery()));
        }
    }
}