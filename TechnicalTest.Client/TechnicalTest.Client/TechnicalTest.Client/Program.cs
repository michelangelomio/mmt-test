using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Client.Interface;
using TechnicalTest.Client.Services;

namespace TechnicalTest.Client
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;
        private static ICategoryService _categoryService;
        private static IProductService _productService;

        private static async Task Main(string[] args)
        {
            RegisterService();

            _categoryService = _serviceProvider.GetService<ICategoryService>();
            _productService = _serviceProvider.GetService<IProductService>();

            Console.WriteLine("All Categories:" + Environment.NewLine);
            await GetCategories();

            Console.WriteLine("All Products:" + Environment.NewLine);
            await GetProducts();

            Console.WriteLine("Products belongs to each Category:" + Environment.NewLine);
            await GetProductsByCategories();

            DisposeService();
        }

        #region Config

        private static void RegisterService()
        {
            var services = new ServiceCollection().AddHttpClient();
            var builder = new ContainerBuilder();

            services.AddHttpClient<ICategoryService, CategoryService>();
            services.AddHttpClient<IProductService, ProductService>();

            builder.Populate(services);

            var appContainer = builder.Build();

            _serviceProvider = new AutofacServiceProvider(appContainer);
        }

        private static void DisposeService()
        {
            (_serviceProvider as IDisposable)?.Dispose();
        }

        #endregion

        #region Methods

        public static async Task GetCategories()
        {
            var categories = await _categoryService.GetCategories(CancellationToken.None);

            foreach (var category in categories.Categories)
                Console.WriteLine($"Category ID:{category.CategoryId} " + Environment.NewLine +
                                  $"Category Name:{category.Name} \n ");
        }

        public static async Task GetProducts()
        {
            var products = await _productService.GetProducts(CancellationToken.None);
            foreach (var product in products.Products)
                Console.WriteLine($"Product ID:{product.ProductId} " + Environment.NewLine +
                                  $"Product Name:{product.Name} " + Environment.NewLine +
                                  $"Product Description:{product.Description} " + Environment.NewLine +
                                  $"Product Price:{product.Price} " + Environment.NewLine +
                                  $"Product Sku:{product.Sku} " + Environment.NewLine +
                                  $"Category Name:{product.CategoryName} \n ");
        }

        public static async Task GetProductsByCategories()
        {
            var categories = await _categoryService.GetCategories(CancellationToken.None);

            foreach (var category in categories.Categories)
            {
                Console.WriteLine($"Category Name:{category.Name}");
                var prodctsByCategory =
                    await _productService.GetProductsByCategoryId(category.CategoryId, CancellationToken.None);

                foreach (var product in prodctsByCategory.Products)
                    Console.WriteLine($"Product Name:{product.Name} " + Environment.NewLine +
                                      $"Product Description:{product.Description} " + Environment.NewLine +
                                      $"Product Price:{product.Price} " + Environment.NewLine +
                                      $"Product Sku:{product.Sku} \n ");
            }
        }

        public static async Task CategoryByIdTask()
        {
            Console.WriteLine("Select category ");
            var selectedCategory = Console.Read();

            if (selectedCategory > 5)
            {
                Console.WriteLine("Sorry the Category ID you have selected doesn't exist");
            }
            else
            {
                var category = await _categoryService.GetCategoryById(selectedCategory, CancellationToken.None);
                Console.WriteLine($"Category ID:{category.CategoryId} " + $"Category Name:{category.Name} \n ");
            }
        }

        #endregion
    }
}