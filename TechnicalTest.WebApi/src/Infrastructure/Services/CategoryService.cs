using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Category.Queries.GetCategory;
using CleanArchitecture.Application.Category.Queries.GetCategoryList;
using CleanArchitecture.Application.Common.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DatabaseService.Interface;

namespace CleanArchitecture.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ITechnicalTestDbContext _context;

        public CategoryService(
            ITechnicalTestDbContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryLookupModel> GetCategoryByIdAsync(int categoryId,
            CancellationToken cancellationToken)
        {
            var category = await _context
                .Categories
                .FirstOrDefaultAsync(x => x.CategoryId == categoryId && x.Deleted == false, cancellationToken);

            return new GetCategoryLookupModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public async Task<GetCategoryListReturnModel> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            var categories = await _context
                .Categories
                .Where(x => x.Deleted == false)
                .Select(x => new GetCategoryListLookupModel
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name
                })
                .ToListAsync(cancellationToken);

            return new GetCategoryListReturnModel
            {
                Categories = categories
            };
        }
    }
}