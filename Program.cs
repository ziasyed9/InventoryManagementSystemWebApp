using Microsoft.AspNetCore.Builder;  // Import necessary namespace to build the ASP.NET Core application
using Microsoft.Extensions.DependencyInjection;  // Import for dependency injection functionality
using InventoryManagementWebApp.Services;  // Import custom service for managing inventory items

// Create a WebApplicationBuilder to set up the application configuration, services, etc.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Services are classes that are injected into other classes (like InventoryService)
builder.Services.AddRazorPages();  // Adds Razor Pages service to the application (for handling UI and routes)
builder.Services.AddSingleton<InventoryService>(); // Registers InventoryService as a singleton, meaning only one instance of this service is created for the app lifecycle

// Set the URLs the app should listen on
builder.WebHost.UseUrls("http://localhost:5208", "https://localhost:7291");

// Build the app after the configuration and services are set up
var app = builder.Build();

// Configure the HTTP request pipeline. This handles how requests are processed by the app

// If the app is not running in development mode, configure custom error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");  // Use a custom error page for unhandled exceptions in non-development environments
    app.UseHsts();  // Use HTTP Strict Transport Security for additional security by enforcing HTTPS
}

// Middleware to redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Middleware to serve static files (like CSS, JavaScript, images, etc.)
app.UseStaticFiles();

// Middleware to enable routing, which determines how HTTP requests map to code in the app
app.UseRouting();

// Middleware to check authorization; it doesn’t do anything by itself here, but it could be used if authorization is set up
app.UseAuthorization();

// Maps Razor Pages endpoints so the app can respond to requests at the appropriate URLs
app.MapRazorPages();

// Runs the application, listening for incoming HTTP requests on the specified URLs
app.Run();
