using Assignment_Asp.NET1.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Asp.NET1.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index(string ReturnUrl = null! )
        {
            var form = new ContactForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }


        [HttpPost]
        public IActionResult Index(ContactForm form)
        {
            return View();
        }
    }
}
