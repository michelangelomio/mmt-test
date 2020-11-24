using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Application.Product.Queries.GetProductBytId;
using CleanArchitecture.Application.Product.Queries.GetProductList;
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

        public async Task<GetProductByIdQueryLookupModel> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId, cancellationToken);

            if (product != null)
            {
                return new GetProductByIdQueryLookupModel
                {
                    ProductId = product.ProductId,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    Sku = product.Sku,
                    CategoryId = product.CategoryId
                };
            }

            return null;
        }

        public async Task<GetProductListByCategoryIdReturnModel> GetAllProductsByCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            var products = await _context
                .Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new GetProductListByCategoryIdQueryLookupModel
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Sku = x.Sku,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                    Description = x.Description,
                })
                .ToListAsync(cancellationToken);

            return new GetProductListByCategoryIdReturnModel
            {
                Products = products
            };
        }

        public async Task<GetProductListQueryReturnModel> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var products = await _context
                .Products
                .Include(x => x.Category)
                .Select(x => new GetProductListQueryLookupModel
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Sku = x.Sku,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                    Description = x.Description,
                })
                .ToListAsync(cancellationToken);

            return new GetProductListQueryReturnModel
            {
                Products = products
            };
        }
    }
}