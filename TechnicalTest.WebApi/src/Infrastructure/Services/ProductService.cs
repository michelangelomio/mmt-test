using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Application.Product.Queries.GetFeaturedProductByProductId;
using CleanArchitecture.Application.Product.Queries.GetProductListByCategoryId;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DatabaseService.Interface;

namespace CleanArchitecture.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ITechnicalTestDbContext _context;

        public ProductService(
            ITechnicalTestDbContext context)
        {
            _context = context;
        }

        public async Task<GetFeaturedProductByProductIdQueryLookupModel> GetFeaturedProductByProductIdAsync(int productId, CancellationToken cancellationToken)
        {
            var featuredProduct = await _context
                .Products
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.FeaturedProduct, cancellationToken);

            if (featuredProduct != null)
            {
                return new GetFeaturedProductByProductIdQueryLookupModel
                {
                    ProductId = featuredProduct.ProductId,
                    Description = featuredProduct.Description,
                    Name = featuredProduct.Name,
                    Price = featuredProduct.Price,
                    Sku = featuredProduct.Sku,
                    CategoryId = featuredProduct.CategoryId
                };
            }

            return null;
        }

        public async Task<GetProductListByCategoryIdReturnModel> GetAllFeaturedProductsByCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            var featuredProducts = await _context
                .Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId && x.FeaturedProduct)
                .Select(x => new GetProductListByCategoryIdQueryLookupModel
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Sku = x.Sku,
                    CategoryName = x.Category.Name
                })
                .ToListAsync(cancellationToken);

            return new GetProductListByCategoryIdReturnModel
            {
                FeaturedProducts = featuredProducts
            };
        }
    }
}