using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}", new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page",
    "Page{productPage:int}", new { Controller = "Home", action = "Index", productpage = 1 });

app.MapControllerRoute("category",
    "{category}", new { Controller = "Home", action = "Index", productpage = 1 });

app.MapControllerRoute("pagination",
    "Products/Page{productPage}", new {Controller = "Home", action ="Index", productpage = 1 });
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
