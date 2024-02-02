using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagement.UI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://localhost:7058/api/Product";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStreamAsync();
                var products = await JsonSerializer.DeserializeAsync<List<ProductViewModel>>(contentStream);

                return View(products);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {
            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://localhost:7058/api/Product";

            var json = JsonSerializer.Serialize(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiUrl, data);

            if (response.IsSuccessStatusCode)
            {
                return View(product);
            }
            return View();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var apiUrl = $"https://localhost:7058/api/Product/{id}";
            var response = await client.DeleteAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return View();
            }

            
            return View();
        }
    }
}
