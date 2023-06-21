using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Marrubium.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public List<string> ProductTypes { get; set; } = null!;

        public List<string> Functions { get; set; } = null!;

        public List<string> SkinTypes { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = string.Empty;
    }
}
