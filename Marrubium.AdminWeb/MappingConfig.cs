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
            
            config.CreateMap<ProductCreateUpdateDto, ProductResponse>().ReverseMap();
            
            config.CreateMap<ProductCreateUpdateDto, CreateUpdateProductRequest>().ReverseMap();

            config.CreateMap<ProductCreateUpdateViewModel, ProductCreateUpdateDto>()
                .ForMember(dest => dest.ProductTypes,
                    opt => 
                        opt.MapFrom(src => src.ProductTypes
                            .Split(
                                new[] { ", ", "," },
                                StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.ToLower()).ToList()))
                .ForMember(dest => dest.Functions,
                    opt => 
                        opt.MapFrom(src => src.Functions
                            .Split(
                                new[] { ", ", "," },
                                StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.ToLower()).ToList()))
                .ForMember(dest => dest.SkinTypes,
                    opt => 
                        opt.MapFrom(src => src.SkinTypes
                            .Split(
                                new[] { ", ", "," },
                                StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.ToLower()).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.ProductTypes,
                    opt => 
                        opt.MapFrom(src => 
                                string.Join(", ", src.ProductTypes).ToLower()))
                .ForMember(dest => dest.Functions,
                    opt => 
                        opt.MapFrom(src => 
                                string.Join(", ", src.Functions).ToLower()))
                .ForMember(dest => dest.SkinTypes,
                    opt => 
                        opt.MapFrom(src => 
                            string.Join(", ", src.SkinTypes).ToLower()));
            
            config.CreateMap<ProductCreateUpdateViewModel, ProductDto>()
                .ForMember(dest => dest.ProductTypes,
                    opt => 
                        opt.MapFrom(src => src.ProductTypes
                            .Split(
                                new[] { ", ", "," },
                                StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.ToLower()).ToList()))
                .ForMember(dest => dest.Functions,
                    opt => 
                        opt.MapFrom(src => src.Functions
                            .Split(
                                new[] { ", ", "," },
                                StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.ToLower()).ToList()))
                .ForMember(dest => dest.SkinTypes,
                    opt => 
                        opt.MapFrom(src => src.SkinTypes
                            .Split(
                                new[] { ", ", "," },
                                StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.ToLower()).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.ProductTypes,
                    opt => 
                        opt.MapFrom(src => 
                            string.Join(", ", src.ProductTypes).ToLower()))
                .ForMember(dest => dest.Functions,
                    opt => 
                        opt.MapFrom(src => 
                            string.Join(", ", src.Functions).ToLower()))
                .ForMember(dest => dest.SkinTypes,
                    opt => 
                        opt.MapFrom(src => 
                            string.Join(", ", src.SkinTypes).ToLower()));

            config.CreateMap<ProductDto, ProductCreateUpdateDto>().ReverseMap();
        });
            
        return mappingConfig;
    }
}