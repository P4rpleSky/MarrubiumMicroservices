using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Marrubium.Services.ProductAPI.HttpModels
{
    public class ProductCreateUpdateDto
    {
        public int ProductId { get; set; } 
        
        public string Name { get; set; } = null!;
        
        public int Price { get; set; } 
        
        public List<string> ProductTypes { get; set; } = new();
        
        public List<string> Functions { get; set; } = new();
        
        public List<string> SkinTypes { get; set; } = new();
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
    }
}
