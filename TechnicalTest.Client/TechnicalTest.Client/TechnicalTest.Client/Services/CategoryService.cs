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
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CategoryModel> GetCategoryById(int categoryId, CancellationToken cancellationToken)
        {
            var url = EndPointUrlConstants.GetCategoryById + categoryId;
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<CategoryModel>(content);

            return tasks;
        }

        public async Task<CategoryListModel> GetCategories(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(EndPointUrlConstants.GetCategories, cancellationToken);

            if (!response.IsSuccessStatusCode) throw new Exception("Cannot retrieve data");

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoryListModel>(content);
        }
    }
}