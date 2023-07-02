using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marrubium.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required] 
        public string Name { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [Column(TypeName = "jsonb")]
        public string ProductTypes{ get; set; } = null!;

        [Required]
        [Column(TypeName = "jsonb")]
        public string Functions { get; set; } = null!;
        
        [Required]
        [Column(TypeName = "jsonb")]
        public string SkinTypes { get; set; } = null!;
        
        [Required]
        public string ImageUrl { get; set; } = null!;

        public string? Description { get; set; }
    }
}
