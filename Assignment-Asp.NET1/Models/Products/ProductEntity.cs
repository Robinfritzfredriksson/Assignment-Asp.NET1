using System.ComponentModel.DataAnnotations;

namespace Assignment_Asp.NET1.Models.Products
{
    public class ProductEntity
    {
        [Key]
        public string SKU { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; } 
    }
}
