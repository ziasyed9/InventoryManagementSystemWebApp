using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagementWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<InventoryService>(); // Registering the InventoryService
builder.WebHost.UseUrls("http://localhost:5208", "https://localhost:7291");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
