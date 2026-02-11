using InventoryStock.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryStock.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService) { _productService = productService; }

        // In mvc if we don't mention any Http methods it defaults to Get method
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult Details(int id) 
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var viewmodel = _productService.GetProductDetails(id);

            if (viewmodel == null) return NotFound();
            stopwatch.Stop();
            TempData["LastFetchTime"] = stopwatch.ElapsedMilliseconds;

            return View(viewmodel);
        }

    }
}
