namespace Ecommerce_Website.Models
{
    public class SayingClients:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
        public string Client { get; set; }
    }
}
