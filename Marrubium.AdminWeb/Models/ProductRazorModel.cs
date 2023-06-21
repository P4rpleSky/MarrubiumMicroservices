namespace Marrubium.AdminWeb.Models;

public class ProductRazorModel
{
    public class OrderRazorModel
    {
        public ProductDto Product { get; set; } = new ProductDto();
        public SD.ViewType ViewType { get; set; }
    }
}