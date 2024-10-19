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

        public void OnGet()
        {
            InventoryItems = _inventoryService.GetAllItems();

            Console.WriteLine("Current Inventory Items:");
            foreach (var item in InventoryItems)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            }
        }


        public IActionResult OnPostAddItem(InventoryItem item)
        {
            Console.WriteLine("OnPostAddItem called"); // Add this line
            if (ModelState.IsValid)
            {
                Console.WriteLine($"Adding item: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
                _inventoryService.AddItem(item);
                return RedirectToPage(); // Redirect to refresh the page and show the updated inventory
            }

            // Log model state errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return Page(); // Return the page if there are validation errors
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
