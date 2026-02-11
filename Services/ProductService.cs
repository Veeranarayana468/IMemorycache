using InventoryStock.Data;
using InventoryStock.Models;
using InventoryStock.ViewModels;
using System.Security.AccessControl;

namespace InventoryStock.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        

        public ProductService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            //return _context.Products.ToList();
            return _context.Products?.ToList() ?? new List<Product>();
        }




        public ViewProductDetails GetProductDetails(int id)
        {
            // 1. SIMULATE SLOW DATABASE (2 seconds delay)
            // This is where you will feel the pain before we add caching!
            Thread.Sleep(2000);

            // 2. Fetch from DB
            var p = _context.Products.Find(id);
            if (p == null) return null;

            // 3. Map to ViewModel
            return new ViewProductDetails
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price,
                StockCount = p.StockCount
            };
        }
    }
}
