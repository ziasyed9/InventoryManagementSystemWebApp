namespace InventoryManagementWebApp.Models
{
    public class InventoryItem
{
    public int Id { get; set; } // Ensure there's an Id property
    public string Name { get; set; } = string.Empty; // Make sure to initialize properties to avoid null reference
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

}
