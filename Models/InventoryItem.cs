namespace InventoryManagementWebApp.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }

        public required string Name { get; set; } // Marked as required

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
