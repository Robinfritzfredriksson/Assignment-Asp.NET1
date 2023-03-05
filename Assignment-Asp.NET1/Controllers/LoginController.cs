﻿using Assignment_Asp.NET1.Models.Forms;
using Assignment_Asp.NET1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Asp.NET1.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _auth;



        public LoginController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new LoginForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }



        [HttpPost]
        public async Task<IActionResult> Index(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.LoginAsync(form))
                    return LocalRedirect(form.ReturnUrl!);
            }

            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View(form);
        }
    }

}
