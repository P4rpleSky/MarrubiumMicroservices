using Marrubium.Services.ProductAPI.HttpModels;

namespace Marrubium.AdminWeb.Models;

public class ProductRazorModel
{
    public ProductCreateUpdateViewModel Product { get; set; } = new ProductCreateUpdateViewModel();
    public SD.ViewType ViewType { get; set; }
}