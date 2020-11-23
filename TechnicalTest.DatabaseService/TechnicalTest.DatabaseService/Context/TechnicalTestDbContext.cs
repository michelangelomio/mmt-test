using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DatabaseService.Entities;
using TechnicalTest.DatabaseService.Interface;

namespace TechnicalTest.DatabaseService.Context
{
    public class TechnicalTestDbContext : DbContext, ITechnicalTestDbContext
    {
        public TechnicalTestDbContext(
            DbContextOptions<TechnicalTestDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("Repository");
            base.OnModelCreating(modelBuilder);
        }
    }
}