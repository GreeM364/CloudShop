using CloudShop.ProductAPI.Data;
using CloudShop.ProductAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CloudShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _productContext;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ProductContext productContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productContext = productContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productContext.Products.Find(p => true).ToListAsync();
        }

    }
}

