using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Category.Queries.GetCategoryById;
using CleanArchitecture.Application.Category.Queries.GetCategoryList;

namespace CleanArchitecture.Application.Common.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<GetCategoryByIdLookupModel> GetCategoryByIdAsync(int categoryId, CancellationToken cancellationToken);
        Task<GetCategoryListReturnModel> GetAllCategoriesAsync(CancellationToken cancellationToken);
    }
}