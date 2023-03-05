using Assignment_Asp.NET1.Models.Identity;
using Assignment_Asp.NET1.Models.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Asp.NET1.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }


        public DbSet<ProductEntity> Products { get; set; }

    }
}
