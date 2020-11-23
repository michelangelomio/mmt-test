using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Category.Queries.GetCategory;
using CleanArchitecture.Application.Category.Queries.GetCategoryList;

namespace CleanArchitecture.Application.Common.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryLookupModel> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken);
        Task<GetCategoryListReturnModel> GetAllCategoriesAsync(CancellationToken cancellationToken);
    }
}