using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Ecommerce_Website.Models;

public class HomeFirstSlider:BaseEntity<int>
{
    public string Precent { get; set; } 
    public string Label { get; set; }
    public string Description { get; set; } 
    public string Image { get; set; }
}
