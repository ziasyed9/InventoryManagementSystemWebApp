using InventoryManagementWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementWebApp.Services
{
    public class InventoryService
    {
        private List<InventoryItem> _inventory = new List<InventoryItem>();

        public List<InventoryItem> GetAllItems() => _inventory;

        public void AddItem(InventoryItem item)
        {
            item.Id = _inventory.Count > 0 ? _inventory.Max(i => i.Id) + 1 : 1;
            _inventory.Add(item);
        }

        public void UpdateItem(InventoryItem updatedItem)
        {
            var item = _inventory.FirstOrDefault(i => i.Id == updatedItem.Id);
            if (item != null)
            {
                item.Name = updatedItem.Name;
                item.Quantity = updatedItem.Quantity;
                item.Price = updatedItem.Price;
            }
        }

        public void DeleteItem(int id)
        {
            var item = _inventory.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _inventory.Remove(item);
            }
        }

        public InventoryItem GetItemById(int id) => _inventory.FirstOrDefault(i => i.Id == id);
    }
}
