using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _repo;
        public int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index(string? category, int productPage = 1)
        {
            return View(
                new ProductsListViewModel
                {
                    Products = _repo.Products
                                .Where(p => category == null || p.Category == category)
                                .OrderBy(p => p.ProductId)
                                .Skip((productPage - 1) * PageSize)
                                .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = productPage,
                        ItemsPerpage = PageSize,
                        //filter category null or not null
                        TotalItems = category == null
                         ? _repo.Products.Count()
                         : _repo.Products.Where(e => e.Category == category).Count()
                    },
                    CurrentCategory = category
                });              
        }
    }
}
