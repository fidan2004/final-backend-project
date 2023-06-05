using Ecommerce_Website.Models;
using Ecommerce_Website.Models;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class ProductStyleVM
    {
        public List<ProductStylePage> productStylePages { get; set; }
        public ProductStylePage productStylePage { get; set; }
        public Product homeProduct { get; set; }
        public List<Product> homeProducts { get; set; }
        public List<HomeShipping> HomeShipping { get; set; }
        public SocialMedia SocialMedias { get; set; }
    }
}
