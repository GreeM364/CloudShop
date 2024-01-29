using Newtonsoft.Json;
using CloudShop.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClientFactory.CreateClient("ProductAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/product");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            return View(productList);
        }
    }
}