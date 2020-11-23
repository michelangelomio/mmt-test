using System.Threading.Tasks;
using CleanArchitecture.Application.Category.Queries.GetCategoryById;
using CleanArchitecture.Application.Category.Queries.GetCategoryList;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoriesController : MediatorController
    {
        [HttpGet("GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery {CategoryId = categoryId}));
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await Mediator.Send(new GetCategoryListQuery()));
        }
    }
}