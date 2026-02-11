using InventoryStock.Models;
using InventoryStock.ViewModels;

namespace InventoryStock.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        ViewProductDetails GetProductDetails(int id);
    }
}
