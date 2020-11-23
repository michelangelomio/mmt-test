using System.Threading.Tasks;
using CleanArchitecture.Application.Product.Queries.GetProductBytId;
using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ProductsController : MediatorController
    {
        [HttpGet("GetFeaturedProduct/{productId}")]
        public async Task<IActionResult> GetFeaturedProductByIdAsync(int productId)
        {
            var result = await Mediator.Send(new GetProductByIdQuery {ProductId = productId});

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpGet("GetAllFeaturedProducts/{categoryId}")]
        public async Task<IActionResult> GetAllFeaturedProductsByCategoryIdAsync(int categoryId)
        {
            return Ok(await Mediator.Send(new GetProductListByCategoryIdQuery {SelectedCategoryId = categoryId}));
        }
    }
}