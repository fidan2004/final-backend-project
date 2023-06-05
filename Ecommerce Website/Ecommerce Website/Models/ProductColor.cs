namespace Ecommerce_Website.Models
{
    public class ProductColor:BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; }
    }
}
