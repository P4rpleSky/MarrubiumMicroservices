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
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        [NotMapped]
        public List<string> ProductTypes
        {
            get => this.InternalProductTypes.Split(',').ToList();
            set => this.InternalProductTypes = string.Join(",", value);
        }

        [Required]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalProductTypes { get; set; }

        [NotMapped]
        public List<string> Functions
        {
            get => this.InternalFunctions.Split(',').ToList();
            set => this.InternalFunctions = string.Join(",", value);
        }

        [Required]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalFunctions { get; set; }

        [NotMapped]
        public List<string> SkinTypes
        {
            get => this.InternalSkinTypes.Split(',').ToList();
            set => this.InternalSkinTypes = string.Join(",", value);
        }

        [Required]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalSkinTypes { get; set; }


        [Required]
        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
