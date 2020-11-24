using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DatabaseService.Interface;

namespace CleanArchitecture.Infrastructure.Services
{
    public class CheckDbService : ICheckDbService
    {
        private readonly ITechnicalTestDbContext _context;

        public CheckDbService(ITechnicalTestDbContext context)
        {
            _context = context;
        }


        public async Task<bool> CheckProductIdAsync(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products.AnyAsync(x => x.ProductId == productId, cancellationToken);
        }

        public async Task<bool> CheckCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Categories.AnyAsync(x => x.CategoryId == categoryId, cancellationToken);
        }
    }
}