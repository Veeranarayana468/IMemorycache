namespace InventoryStock.Models
{
    public class Product
    {
        public int Id { get; set; } // EF Core knows this is the Primary Key
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public DateTime LastRestocked { get; set; } = DateTime.Now;
    }
}
