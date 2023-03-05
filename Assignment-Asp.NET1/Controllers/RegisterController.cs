using Assignment_Asp.NET1.Models.Forms;
using Assignment_Asp.NET1.Models.Identity;
using Assignment_Asp.NET1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Asp.NET1.Controllers
{
   
    public class RegisterController : Controller
    {

        private readonly AuthService _auth;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(AuthService auth, UserManager<AppUser> userManager)
        {
            _auth = auth;
            _userManager = userManager;
        }

        public IActionResult Index( string ReturnUrl = null!)
        {
            var form = new RegisterForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
         
        }


        [HttpPost]
        public async Task<IActionResult> Index(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == form.Email)) //Borde göra en Service för att kunna använda på fler ställen (kollar om fler med samma namn finns)
                {
                    ModelState.AddModelError(string.Empty, "A user with the same email already exists.");
                    return View(form);
                }

                if (await _auth.RegisterAsync(form))
                    return LocalRedirect(form.ReturnUrl!);
                else
                    return View(form);
            }
            return View(form);
        }
    }
}
