

using Marrubium.Services.ProductAPI.HttpModels;

namespace Marrubium.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductsAsync(CancellationToken cancellationToken);
        Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken);
        Task<ProductCreateUpdateDto> CreateUpdateProductAsync(ProductCreateUpdateDto productDto, CancellationToken cancellationToken);
        Task<bool> DeleteProductByIdAsync(int productId, CancellationToken cancellationToken);
        Task<CategoryListsModel> GetAllCategoriesAsync(CancellationToken cancellationToken);
    }
}
