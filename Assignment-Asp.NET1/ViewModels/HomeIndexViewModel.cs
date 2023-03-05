using Assignment_Asp.NET1.Models.Products;

namespace Assignment_Asp.NET1.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<ProductEntity> BestCollections { get; set; } = new List<ProductEntity>();
        public List<ProductEntity> TopSelling { get; set; } = new List<ProductEntity>();
    }
}
