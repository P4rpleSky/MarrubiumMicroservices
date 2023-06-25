using AutoMapper;
using Marrubium.Services.ProductAPI.Grpc;
using Marrubium.Services.ProductAPI.HttpModels;

namespace Marrubium.AdminWeb;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, ProductResponse>().ReverseMap();
            config.CreateMap<ProductCreateUpdateDto, CreateUpdateProductRequest>().ReverseMap();
        });
            
        return mappingConfig;
    }
}