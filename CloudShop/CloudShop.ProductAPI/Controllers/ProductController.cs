using CloudShop.ProductAPI.Data;
using CloudShop.ProductAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudShop.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        { 
            return ProductContext.Products;
        }

    }
}

