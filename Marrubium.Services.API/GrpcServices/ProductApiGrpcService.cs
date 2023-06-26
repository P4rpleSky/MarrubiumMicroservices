using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Marrubium.Services.ProductAPI.Grpc;
using Marrubium.Services.ProductAPI.HttpModels;
using Marrubium.Services.ProductAPI.Repository;

namespace Marrubium.Services.ProductAPI.GrpcServices;

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
        try
        {
            var products = await _productRepository.GetProductsAsync();
            return new ProductsListResponse
            {
                Products = { products.Select(x => _mapper.Map<ProductResponse>(x)) }
            };
        }
        catch (Exception exception)
        {
            throw new RpcException(new Status(StatusCode.Internal, "gRPC-API-exception"),
                new Metadata
                {
                    new Metadata.Entry("api-exception", exception.Message)
                });
        }
    }

    public override async Task<ProductResponse> GetProductById(GetProductRequest request, ServerCallContext context)
    {
        try
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            return _mapper.Map<ProductResponse>(product);
        }
        catch (Exception exception)
        {
            throw new RpcException(new Status(StatusCode.Internal, "gRPC-API-exception"),
                new Metadata
                {
                    new Metadata.Entry("api-exception", exception.Message)
                });
        }
    }

    public override async Task<ProductResponse> CreateUpdateProduct(CreateUpdateProductRequest request, ServerCallContext context)
    {
        try
        {
            var product = _mapper.Map<ProductCreateUpdateDto>(request);
            var result = await _productRepository.CreateUpdateProductAsync(product);
            return _mapper.Map<ProductResponse>(result);
        }
        catch (Exception exception)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "gRPC-API-exception"),
                new Metadata
                {
                    new Metadata.Entry("api-exception", exception.Message)
                });
        }
    }

    public override async Task<DeleteProductResponse> DeleteProductById(DeleteProductRequest request, ServerCallContext context)
    {
        try
        {
            var isSuccess = await _productRepository.DeleteProductByIdAsync(request.Id);
            return new DeleteProductResponse { IsSuccess = isSuccess };
        }
        catch (Exception exception)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "gRPC-API-exception"),
                new Metadata
                {
                    new Metadata.Entry("api-exception", exception.Message)
                });
        }
    }
}