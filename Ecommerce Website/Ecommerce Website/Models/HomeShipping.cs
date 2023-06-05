using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Website.Models;

public class HomeShipping : BaseEntity<int>
{
    [Required]
    public string Label { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Image { get;set; }
    [NotMapped]
    public IFormFile Photo { get; set; }
}
