using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Marrubium.Services.ProductAPI.Grpc;
using Marrubium.Services.ProductAPI.HttpModels;

namespace Marrubium.AdminWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductApiGrpc.ProductApiGrpcClient _productClient;
        private readonly IMapper _mapper;

        public ProductService(ProductApiGrpc.ProductApiGrpcClient productClient, IMapper mapper)
        {
            _productClient = productClient;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var response = await _productClient.GetAllProductsAsync(new Empty());
            return _mapper.Map<List<ProductDto>>(response.Products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var response = await _productClient.GetProductByIdAsync(new GetProductRequest { Id = id });
            return _mapper.Map<ProductDto>(response);
        }

        public async Task<ProductCreateUpdateDto> CreateProductAsync(ProductCreateUpdateDto productDto)
        {
            var productRequest = _mapper.Map<CreateUpdateProductRequest>(productDto);
            var response = await _productClient.CreateUpdateProductAsync(productRequest);
            return _mapper.Map<ProductCreateUpdateDto>(response);
        }

        public async Task<ProductCreateUpdateDto> UpdateProductAsync(ProductCreateUpdateDto productDto)
        {
            var productRequest = _mapper.Map<CreateUpdateProductRequest>(productDto);
            var response = await _productClient.CreateUpdateProductAsync(productRequest);
            return _mapper.Map<ProductCreateUpdateDto>(response);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _productClient.DeleteProductByIdAsync(new DeleteProductRequest { Id = id});
            return response.IsSuccess;
        }
    }
}
