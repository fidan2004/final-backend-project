using Ecommerce_Website.Models;

namespace Ecommerce_Website.ViewModels
{
    public class HomeVM
    {
        public List<HomeFirstSlider> Sliders { get; set; }
        public List<HomeShipping> Shippings { get; set; }
        public List<Product>? HomeProducts  { get; set; }
        //public List<AdvertisingSlider> BanerSliders { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Banner>? Banner { get; set; }
        public List<SayingClients> SayingClients { get; set; }
        public HomeDescription HomeDescriptions { get; set; }
        public Blog Blog { get; set; }
    }
}
