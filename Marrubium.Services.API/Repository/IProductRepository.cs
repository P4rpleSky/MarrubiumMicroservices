

using Marrubium.Services.ProductAPI.HttpModels;

namespace Marrubium.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<ProductCreateUpdateDto> CreateUpdateProductAsync(ProductCreateUpdateDto productDto);
        Task<bool> DeleteProductByIdAsync(int productId);
    }
}
