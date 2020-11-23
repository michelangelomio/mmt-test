using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using MediatR;

namespace CleanArchitecture.Application.Category.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryLookupModel>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryQueryHandler(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetCategoryLookupModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetCategoryByIdAsync(request.CategoryId, cancellationToken);
        }
    }
}