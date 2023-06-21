using AutoMapper;
using Marrubium.Services.ProductAPI.Grpc;
using Marrubium.Services.ProductAPI.HttpModels;
using Marrubium.Services.ProductAPI.Models;
using Newtonsoft.Json;

namespace Marrubium.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>()
                    .ForMember(
                        dest => dest.ProductTypes,
                        opt => 
                            opt.MapFrom(src => JsonConvert.SerializeObject(src.ProductTypes))
                    )
                    .ForMember(
                        dest => dest.Functions,
                        opt => 
                            opt.MapFrom(src => JsonConvert.SerializeObject(src.Functions))
                    )
                    .ForMember(
                        dest => dest.SkinTypes,
                        opt => 
                            opt.MapFrom(src => JsonConvert.SerializeObject(src.SkinTypes))
                    );
                
                config.CreateMap<Product, ProductDto>()
                    .ForMember(
                        dest => dest.ProductTypes,
                        opt => 
                            opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.ProductTypes))
                    )
                    .ForMember(
                        dest => dest.Functions,
                        opt => 
                            opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.Functions))
                    )
                    .ForMember(
                        dest => dest.SkinTypes,
                        opt => 
                            opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.SkinTypes))
                    );
                
                config.CreateMap<ProductDto, ProductCreateUpdateDto>().ReverseMap();
                
                config.CreateMap<ProductDto, ProductResponse>()
                    .ForMember(
                        dest => dest.ProductTypes,
                        opt => 
                            opt.MapFrom(src => src.ProductTypes)
                    )
                    .ForMember(
                        dest => dest.Functions,
                        opt => 
                            opt.MapFrom(src => src.Functions)
                    )
                    .ForMember(
                        dest => dest.SkinTypes,
                        opt => 
                            opt.MapFrom(src => src.SkinTypes)
                    )
                    .ReverseMap();
            });
            
            return mappingConfig;
        }
    }
}
