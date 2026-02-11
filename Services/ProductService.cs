using InventoryStock.Data;
using InventoryStock.Models;
using InventoryStock.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System.Security.AccessControl;

namespace InventoryStock.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public ProductService(ApplicationDbContext context, IMemoryCache memoryCache) 
        { 
            _context = context;
            _memoryCache = memoryCache;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            //return _context.Products.ToList();
            return _context.Products?.ToList() ?? new List<Product>();
        }


        public ViewProductDetails GetProductDetails(int id)
        {
            var cacheKey = $"Product details {id}";

            if (!_memoryCache.TryGetValue(cacheKey, out ViewProductDetails cachedData)) 
            {
                Thread.Sleep(3000);

                var p = _context.Products.Find(id);
                if (p == null) return null;

                cachedData = new ViewProductDetails
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category,
                    Price = p.Price,
                    StockCount = p.StockCount
                };

                var cachedOption = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                _memoryCache.Set(cacheKey, cachedData, cachedOption);
            }
            return cachedData;
        }

        //public ViewProductDetails GetProductDetails(int id)
        //{
        //    // 1. SIMULATE SLOW DATABASE (2 seconds delay)
        //    // This is where you will feel the pain before we add caching!
        //    Thread.Sleep(2000);

        //    // 2. Fetch from DB
        //    var p = _context.Products.Find(id);
        //    if (p == null) return null;

        //    // 3. Map to ViewModel
        //    return new ViewProductDetails
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //        Category = p.Category,
        //        Price = p.Price,
        //        StockCount = p.StockCount
        //    };
        //}
    }
}
