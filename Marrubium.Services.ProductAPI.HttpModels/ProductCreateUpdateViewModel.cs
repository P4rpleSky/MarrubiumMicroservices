using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marrubium.Services.ProductAPI.HttpModels;

public class ProductCreateUpdateViewModel
{
    [Required] 
    public int ProductId { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
        
    [Required]
    [Range(50, 200000)]
    public int Price { get; set; }

    [Required]
    [MaxLength(100)]
    public string ProductTypes { get; set; } = null!;
        
    [Required]
    [MaxLength(100)]
    public string Functions { get; set; } = null!;
        
    [Required]
    [MaxLength(100)]
    public string SkinTypes { get; set; } = null!;
        
    [Required]
    [Url]
    public string ImageUrl { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
}