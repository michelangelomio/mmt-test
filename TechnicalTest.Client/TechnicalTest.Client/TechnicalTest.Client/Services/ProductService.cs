using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TechnicalTest.Client.Common;
using TechnicalTest.Client.Interface;
using TechnicalTest.Client.Model;

namespace TechnicalTest.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductModel> GetProductById(int productId, CancellationToken cancellationToken)
        {
            var url = EndPointUrlConstants.GetProductById + productId;
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<ProductModel>(content);

            return tasks;
        }

        public async Task<ProductListModel> GetProductsByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var url = EndPointUrlConstants.GetProductByCategoryId + categoryId;
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<ProductListModel>(content);

            return tasks;
        }

        public async Task<ProductListModel> GetProducts(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(EndPointUrlConstants.GetProducts, cancellationToken);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductListModel>(content);
        }
    }
}