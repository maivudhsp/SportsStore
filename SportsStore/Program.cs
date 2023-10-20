using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//add RazorPage - 20/10
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}", new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page",
    "Page{productPage:int}", new { Controller = "Home", action = "Index", productpage = 1 });

app.MapControllerRoute("category",
    "{category}", new { Controller = "Home", action = "Index", productpage = 1 });

app.MapControllerRoute("pagination",
    "Products/Page{productPage}", new {Controller = "Home", action ="Index", productpage = 1 });

app.MapDefaultControllerRoute();
//Use RazorPage
app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();
