﻿using System.Threading.Tasks;
using CleanArchitecture.Application.Category.Queries.GetCategoryById;
using CleanArchitecture.Application.Category.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController  : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int categoryId)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdQuery { CategoryId = categoryId }));
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return Ok(await _mediator.Send(new GetCategoryListQuery()));
        }
    }
}