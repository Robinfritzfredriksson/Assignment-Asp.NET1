﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Asp.NET1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize (Roles = "Admin, Product Manager")]
        public IActionResult Product() 
        { 
            return View();
        }
    }
}
