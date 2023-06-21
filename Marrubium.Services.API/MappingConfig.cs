using AutoMapper;
using Marrubium.Services.ProductAPI.Models;
using Marrubium.Services.ProductAPI.Models.Dto;
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
                    /*.AfterMap((dto, product) =>
                    {
                        product.ProductTypes = JsonConvert.SerializeObject(dto.ProductTypes);
                        product.Functions = JsonConvert.SerializeObject(dto.Functions);
                        product.SkinTypes = JsonConvert.SerializeObject(dto.SkinTypes);
                    });*/
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
            });

            return mappingConfig;
        }
    }
}
