
using Assignment_Asp.NET1.Services;
using Assignment_Asp.NET1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Asp.NET1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollections = await _productService.GetAllAsync(),
                TopSelling = await _productService.GetAllAsync(),
            };

            return View(viewModel);
        }
    }
}
