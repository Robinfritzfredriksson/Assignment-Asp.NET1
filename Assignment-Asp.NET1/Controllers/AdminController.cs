using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Asp.NET1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
