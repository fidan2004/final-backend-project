
using Ecommerce_Website.Models;

namespace WebApplication1.ViewModels;

public class ShopVM
{
    public List<Product> Products { get; set; }
    public List<Category> Categories { get; set; }
    public List<ProductColor> Colors { get; set; }
    public Banner Banner { get; set; }
}
