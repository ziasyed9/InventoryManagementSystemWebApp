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

        public InventoryModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            InventoryItems = new List<InventoryItem>();
        }

        public List<InventoryItem> InventoryItems { get; set; }
        public int? EditItemId { get; set; }  // Track the item being edited

        public void OnGet()
        {
            InventoryItems = _inventoryService.GetAllItems();
        }

        public IActionResult OnPost(int? EditItemId)
        {
            InventoryItems = _inventoryService.GetAllItems();
            this.EditItemId = EditItemId;  // Set the item to be edited based on the button clicked
            return Page();
        }

        public IActionResult OnPostAddItem(InventoryItem item)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.AddItem(item);
                return RedirectToPage();
            }
            return Page();
        }

        public IActionResult OnPostUpdateItem(InventoryItem item)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.UpdateItem(item);
                return RedirectToPage();
            }
            return Page();
        }

        public IActionResult OnPostDeleteItem(int id)
        {
            _inventoryService.DeleteItem(id);
            return RedirectToPage();
        }
    }
}
