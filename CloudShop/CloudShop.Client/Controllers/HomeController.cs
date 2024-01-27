using CloudShop.Client.Data;
using Microsoft.AspNetCore.Mvc;

namespace CloudShop.Client.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        { }

        public IActionResult Index()
        {
            return View(ProductContext.Products);
        }
    }
}