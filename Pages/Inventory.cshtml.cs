using InventoryManagementWebApp.Models;
using InventoryManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace InventoryManagementWebApp.Pages
{
    public class InventoryModel : PageModel
    {
        private readonly InventoryService _inventoryService;

        public InventoryModel(InventoryService inventoryService) // Inject the service
        {
            _inventoryService = inventoryService;
            InventoryItems = new List<InventoryItem>(); // Initialize to an empty list
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
