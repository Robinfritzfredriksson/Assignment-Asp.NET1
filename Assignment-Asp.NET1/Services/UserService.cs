using Assignment_Asp.NET1.Contexts;
using Assignment_Asp.NET1.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Asp.NET1.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityContext _context;

        public UserService(UserManager<AppUser> userManager, IdentityContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<UserAccount> GetUserAccountAsync(string email)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (identityUser != null)
            {
                return new UserAccount 
                { 
                    Id = identityUser.Id,
                    FirstName = identityUser.FirstName,
                    LastName = identityUser.LastName,
                    Email = identityUser.Email!,
                    StreetName= identityUser.StreetName,
                    PostalCode= identityUser.PostalCode,
                    City = identityUser.City,
                    PhoneNumber= identityUser.PhoneNumber
                };
            }

            return null!;
        }


    }
}
