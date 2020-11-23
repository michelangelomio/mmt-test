using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DatabaseService.Context;
using TechnicalTest.DatabaseService.Entities;

namespace Common.Tests.TestBase
{
    public abstract class TestBase
    {
        protected IContainer Registrations()
        {
            var builder = new ContainerBuilder();

            builder.Register(context =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();
                    var optionsBuilder = new DbContextOptionsBuilder<TechnicalTestDbContext>();
                    optionsBuilder.UseSqlite(connection);
                    return optionsBuilder.Options;
                })
                .As<DbContextOptions<TechnicalTestDbContext>>()
                .SingleInstance();

            var container = builder.Build();
            return container;
        }

        protected async Task SeedMockDataAsync(TechnicalTestDbContext context)
        {
            context.Database.EnsureCreated();

           await context.Categories.AddRangeAsync(
                new Categories
                {
                    CategoryId = 1, Name = "Category1", Deleted = false

                },
                new Categories
                {
                    CategoryId = 2, Name = "Category2", Deleted = false
                }
            );

           await context.Products.AddRangeAsync(
               new Products
               {
                   ProductId = 1,
                   Name = "Product1",
                   CategoryId = 1
               },
               new Products
               {
                   ProductId = 2,
                   Name = "Product2",
                   CategoryId = 2
               },
               new Products
               {
                   ProductId = 3,
                   Name = "Product3",
                   CategoryId = 1
               }
           );

            context.SaveChanges();
        }
    }
}