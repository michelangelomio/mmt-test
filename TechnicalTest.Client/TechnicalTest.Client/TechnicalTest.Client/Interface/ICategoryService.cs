using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Client.Model;

namespace TechnicalTest.Client.Interface
{
    public interface ICategoryService
    {
        Task<CategoryModel> GetCategoryById(int categoryId, CancellationToken cancellationToken);
        Task<CategoryListModel> GetCategories(CancellationToken cancellationToken);
    }
}