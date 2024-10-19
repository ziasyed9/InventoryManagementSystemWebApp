using InventoryManagementWebApp.Models;
using InventoryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagementWebApp.Pages
{
    public class InventoryModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        public InventoryModel()
        {
            _inventoryService = new InventoryService();
        }

        public List<InventoryItem> InventoryItems { get; set; }

        public void OnGet()
        {
            InventoryItems = _inventoryService.GetAllItems();
        }

        public IActionResult OnPostAddItem(InventoryItem item)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.AddItem(item);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateItem(InventoryItem item)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.UpdateItem(item);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteItem(int id)
        {
            _inventoryService.DeleteItem(id);
            return RedirectToPage();
        }
    }
}
