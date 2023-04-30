using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Marrubium.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public List<string> ProductTypes { get; set; }

        public List<string> Functions { get; set; }

        public List<string> SkinTypes { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
