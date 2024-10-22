namespace InventoryManagementWebApp.Models
{
    // Class representing an item in the inventory
    public class InventoryItem
    {
        // Property to store a unique identifier for each inventory item
        public int Id { get; set; } // Ensure there's an Id property
        
        // Property to store the name of the inventory item
        // Initialized to an empty string to avoid null references
        public string Name { get; set; } = string.Empty; 
        
        // Property to store the quantity of the item in stock
        public int Quantity { get; set; }
        
        // Property to store the price of the item
        public decimal Price { get; set; }
    }
}
