namespace Ecommerce_Website.Models
{
    public class Banner:BaseEntity<int>
    {   
        public string Label { get; set; } 
        public string Description { get; set; } 
        public string Image { get; set; } 
    }
}
