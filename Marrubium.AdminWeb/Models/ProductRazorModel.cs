using Marrubium.Services.ProductAPI.HttpModels;

namespace Marrubium.AdminWeb.Models;

public class ProductRazorModel
{
    public ProductDto Product { get; set; } = new ProductDto();
    public SD.ViewType ViewType { get; set; }
}