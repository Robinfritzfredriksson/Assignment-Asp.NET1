using Assignment_Asp.NET1.Contexts;
using Assignment_Asp.NET1.Models.Forms;
using Assignment_Asp.NET1.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Assignment_Asp.NET1.Services
{
    public class AuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityContext _context;

        public AuthService(UserManager<AppUser> userManager, IdentityContext context, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var userRole = "User";

            if (!await _roleManager.Roles.AnyAsync() || !await _userManager.Users.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("UserManager"));
                await _roleManager.CreateAsync(new IdentityRole("User"));

                userRole = "Admin";
            }

            var user = new AppUser
            {
                UserName = form.Email,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                FirstName = form.FirstName,
                LastName= form.LastName,
                StreetName= form.StreetName,
                PostalCode= form.PostalCode,
                City= form.City,
                Company= form.Company,
            };

           var result = await _userManager.CreateAsync(user, form.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userRole);
            }
            
            return result.Succeeded;
        }


        public async Task<bool> LoginAsync(LoginForm form, bool keepMeLoggedIn = false)
        {
            var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, keepMeLoggedIn, false);
            return result.Succeeded;

        }
    }
}
