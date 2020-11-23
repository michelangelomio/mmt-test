using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Product.Queries.GetFeaturedProductByProductId;
using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;

namespace CleanArchitecture.Application.Common.Interfaces.Services
{
    public interface IProductService
    {
        Task<GetFeaturedProductByProductIdQueryLookupModel> GetFeaturedProductByProductIdAsync(int productId, CancellationToken cancellationToken);

        Task<GetProductListByCategoryIdReturnModel> GetAllFeaturedProductsByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}