using InventoryManagementWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementWebApp.Services
{
    // This service manages the inventory of items
    public class InventoryService
    {
        // A private list to hold inventory items
        private List<InventoryItem> _inventory = new List<InventoryItem>();

        // Method to return all items in the inventory
        public List<InventoryItem> GetAllItems() => _inventory;

        // Method to add a new item to the inventory
        public void AddItem(InventoryItem item)
        {
            // Assign an Id based on whether the list already has items
            item.Id = _inventory.Count > 0 ? _inventory.Max(i => i.Id) + 1 : 1;
            
            // Add the new item to the inventory list
            _inventory.Add(item);
        }

        // Method to update an existing item's details
        public void UpdateItem(InventoryItem updatedItem)
        {
            // Find the item in the inventory by its Id
            var item = _inventory.FirstOrDefault(i => i.Id == updatedItem.Id);
            
            // If the item is found, update its properties
            if (item != null)
            {
                item.Name = updatedItem.Name;
                item.Quantity = updatedItem.Quantity;
                item.Price = updatedItem.Price;
            }
        }

        // Method to remove an item from the inventory by its Id
        public void DeleteItem(int id)
        {
            // Find the item in the inventory by its Id
            var item = _inventory.FirstOrDefault(i => i.Id == id);
            
            // If found, remove the item
            if (item != null)
            {
                _inventory.Remove(item);
            }
        }

        // Method to retrieve an item from the inventory by its Id
        public InventoryItem? GetItemById(int id) => _inventory.FirstOrDefault(i => i.Id == id);
    }
}
