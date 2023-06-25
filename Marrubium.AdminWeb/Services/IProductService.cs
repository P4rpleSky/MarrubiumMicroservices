using Marrubium.Services.ProductAPI.HttpModels;

namespace Marrubium.AdminWeb.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductCreateUpdateDto> CreateProductAsync(ProductCreateUpdateDto productDto);
        Task<ProductCreateUpdateDto> UpdateProductAsync(ProductCreateUpdateDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
