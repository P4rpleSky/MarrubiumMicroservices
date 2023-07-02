using AutoMapper;
using Marrubium.Services.ProductAPI.DbContexts;
using Marrubium.Services.ProductAPI.HttpModels;
using Marrubium.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Marrubium.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductCreateUpdateDto> CreateUpdateProductAsync(ProductCreateUpdateDto productDto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(productDto);
            if (product.ProductId > 0) 
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync(cancellationToken);
            return _mapper.Map<Product, ProductCreateUpdateDto>(product);
        }

        public async Task<bool> DeleteProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId, cancellationToken: cancellationToken);
            if (product == null)
            {
                throw new ArgumentException("Cannot delete user: invalid input ID!");
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<CategoryListsModel> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            var products = await GetProductsAsync(cancellationToken);
            return new CategoryListsModel()
            {
                ProductTypes = products.SelectMany(x => x.ProductTypes.Select(y => y.ToLower())).Distinct().ToList(),
                Functions = products.SelectMany(x => x.Functions.Select(y => y.ToLower())).Distinct().ToList(),
                SkinTypes = products.SelectMany(x => x.SkinTypes.Select(y => y.ToLower())).Distinct().ToList(),
            };

        }

        public async Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId, cancellationToken: cancellationToken);
            if (product == null)
            {
                throw new ArgumentException("Cannot get user by id: invalid input ID!");
            }
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetProductsAsync(CancellationToken cancellationToken)
        {
            var productList = await _db.Products.OrderBy(x => x.ProductId).ToListAsync(cancellationToken: cancellationToken);
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
