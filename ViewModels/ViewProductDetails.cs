namespace InventoryStock.ViewModels
{
    public class ViewProductDetails
    {
        // DB Data
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public string Category { get; set; }

        // Analytics (Calculated Logic)
        public decimal TotalValue => Price * StockCount;

        public string StockHealth => StockCount switch
        {
            0 => "Out of Stock",
            < 10 => "Critical - Restock Needed",
            < 20 => "Low Stock",
            _ => "Healthy"
        };

        public string HealthColor => StockCount < 10 ? "text-danger" : "text-success";
    }


}

