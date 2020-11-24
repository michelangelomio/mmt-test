using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Product.Queries.GetProductBytId;
using CleanArchitecture.Application.Product.Queries.GetProductList;
using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;

namespace CleanArchitecture.Application.Common.Interfaces.Services
{
    public interface IProductService
    {
        Task<GetProductByIdQueryLookupModel> GetProductByIdAsync(int productId, CancellationToken cancellationToken);

        Task<GetProductListByCategoryIdReturnModel> GetAllProductsByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);

        Task<GetProductListQueryReturnModel> GetAllProductsAsync(CancellationToken cancellationToken);
    }
}