using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.DatabaseService.Context;
using TechnicalTest.DatabaseService.Interface;

namespace CleanArchitecture.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TechnicalTestDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TechnicalTestConnectionString")));
            services.AddScoped<ITechnicalTestDbContext>(provider => provider.GetService<TechnicalTestDbContext>());

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}