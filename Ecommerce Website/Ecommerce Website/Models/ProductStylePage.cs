using Ecommerce_Website.Models;

namespace WebApplication1.Models
{
    public class ProductStylePage : BaseEntity<int>
    {
        public string ShippingText { get; set; }
        public string AboutreturnrequestText { get; set; }
        public string Guaranteetext { get; set; } 
        public string Description { get; set; } 
        public string ClientName { get; set; } 
        public string ClientComent { get; set; }
        public int CommentCount { get; set; } = 1;
        public string Image { get; set; } 
    }
}
