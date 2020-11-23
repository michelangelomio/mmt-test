using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DatabaseService.Entities;

namespace TechnicalTest.DatabaseService.Interface
{
    public interface ITechnicalTestDbContext
    {
        DbSet<Categories> Categories { get; set; }
        DbSet<Products> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}