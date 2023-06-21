using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Marrubium.Services.ProductAPI.Grpc;
using Marrubium.Services.ProductAPI.HttpModels;
using Marrubium.Services.ProductAPI.Repository;

namespace Marrubium.Services.ProductAPI.GrpcService;

public class ProductApiGrpcService : ProductApiGrpc.ProductApiGrpcBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductApiGrpcService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public override async Task<ProductsListResponse> GetAllProducts(Empty request, ServerCallContext context)
    {
        var products = await _productRepository.GetProductsAsync();
        return new ProductsListResponse
        {
            Products = { products.Select(x => _mapper.Map<ProductResponse>(x)) }
        };
        /*return new ProductsListResponse
        {
            Products = { products.Select(x => new ProductResponse
            {
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                ProductTypes = { x.ProductTypes },
                SkinTypes = { x.SkinTypes },
                Functions = { x.Functions }
            })}
        };*/
    }

    public override async Task<ProductResponse> GetProductById(GetProductRequest request, ServerCallContext context)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id);
        return _mapper.Map<ProductResponse>(product);
        /*return new ProductResponse
        {
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            ProductTypes = { product.ProductTypes },
            SkinTypes = { product.SkinTypes },
            Functions = { product.Functions }
        };*/
    }

    public override async Task<ProductResponse> CreateUpdateProduct(CreateUpdateProductRequest request, ServerCallContext context)
    {
        var product = new ProductCreateUpdateDto()
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Price = request.Price,
            ProductTypes = request.ProductTypes.ToList(),
            SkinTypes = request.SkinTypes.ToList(),
            Functions = request.Functions.ToList()
        };
        var result = await _productRepository.CreateUpdateProductAsync(product);
        return _mapper.Map<ProductResponse>(result);
        /*return new ProductResponse
        {
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            ProductTypes = { product.ProductTypes },
            SkinTypes = { product.SkinTypes },
            Functions = { product.Functions }
        };*/
    }

    public override async Task<DeleteProductResponse> DeleteProductById(DeleteProductRequest request, ServerCallContext context)
    {
        var isSuccess = await _productRepository.DeleteProductByIdAsync(request.Id);
        return new DeleteProductResponse { IsSuccess = isSuccess };
    }
}