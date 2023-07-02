using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marrubium.Services.ProductAPI.HttpModels;

public class ProductCreateUpdateViewModel
{
    [Required] 
    public int ProductId { get; set; }
    
    [Required]
    public string Name { get; init; } = null!;
        
    [Required]
    [Range(50, 200000)]
    public int Price { get; init; }

    [Required]
    [MaxLength(100)]
    public string ProductTypes { get; init; } = null!;
        
    [Required]
    [MaxLength(100)]
    public string Functions { get; init; } = null!;
        
    [Required]
    [MaxLength(100)]
    public string SkinTypes { get; init; } = null!;
        
    [Required]
    [Url]
    public string ImageUrl { get; init; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; init; }
}