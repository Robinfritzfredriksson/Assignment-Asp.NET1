using Assignment_Asp.NET1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Asp.NET1.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        
        public async Task<IActionResult> Index()
        {
            var userAccount = await _userService.GetUserAccountAsync(User.Identity!.Name!);
            return View(userAccount);
        }
    }
}
