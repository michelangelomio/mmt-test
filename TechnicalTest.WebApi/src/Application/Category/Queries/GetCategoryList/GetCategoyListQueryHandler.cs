using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using MediatR;

namespace CleanArchitecture.Application.Category.Queries.GetCategoryList
{
    public class GetCategoyListQueryHandler : IRequestHandler<GetCategoryListQuery, GetCategoryListReturnModel>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoyListQueryHandler(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetCategoryListReturnModel> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategoriesAsync(cancellationToken);
        }
    }
}