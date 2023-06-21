using AutoMapper;
using Marrubium.Services.ProductAPI.DbContexts;
using Marrubium.Services.ProductAPI.Models;
using Marrubium.Services.ProductAPI.Models.Dto;
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

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0) 
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                throw new ArgumentException("Cannot delete user: invalid input ID!");
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                throw new ArgumentException("Cannot get user by id: invalid input ID!");
            }
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productList = await _db.Products.OrderBy(x => x.ProductId).ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
