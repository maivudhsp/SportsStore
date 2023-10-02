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
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
