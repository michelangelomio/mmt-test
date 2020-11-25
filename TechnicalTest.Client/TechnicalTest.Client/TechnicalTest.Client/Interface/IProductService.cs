using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Client.Model;

namespace TechnicalTest.Client.Interface
{
    public interface IProductService
    {
        Task<ProductModel> GetProductById(int productId, CancellationToken cancellationToken);
        Task<ProductListModel> GetProductsByCategoryId(int categoryId, CancellationToken cancellationToken);
        Task<ProductListModel> GetProducts(CancellationToken cancellationToken);
    }
}