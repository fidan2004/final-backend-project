using Microsoft.EntityFrameworkCore;
using Ecommerce_Website.Models;

namespace Ecommerce_Website.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<HomeFirstSlider> Sliders { get; set; }
        public DbSet<Product> HomeProducts { get; set; }
        public DbSet<Category> HomeCategories { get; set; }
        public DbSet<HomeShipping> Shippings { get; set; }
      
        public DbSet<Contact> Contacts { get; set; }
        
        public DbSet<HomeSecondSlider> BanerSliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Banner> Baners { get; set; }
        public DbSet<HomeDescription> HomeDescriptions { get; set; }
        public DbSet<ProductColor> Colors { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<FooterLink> QuickLinks { get; set; }
        public DbSet<SayingClients> SayingClients { get; set; }
        public DbSet<HeaderInfo> HeaderInfos { get; set; }
        public DbSet<HomePhone> HeaderPhones { get; set; }
        public DbSet<ProductStylePage> ProductStylePages { get; set; }
    }

 }

