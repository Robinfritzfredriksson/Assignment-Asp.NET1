
using Assignment_Asp.NET1.Contexts;
using Assignment_Asp.NET1.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Asp.NET1.Services
{
    public class ProductService
    {
        private readonly IdentityContext _context;

        public ProductService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
