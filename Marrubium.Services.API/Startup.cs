using Marrubium.Services.ProductAPI.DbContexts;
using Marrubium.Services.ProductAPI.GrpcService;
using Marrubium.Services.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Marrubium.Services.ProductAPI;

public class Startup
{
    /*public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        var mapper = MappingConfig.RegisterMaps().CreateMapper();
        services.AddSingleton(mapper);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Marrubium.Services.ProductAPI",
                Version = "v1"
            });
        });
        services.AddGrpc();
    }

    public void Configure(IApplicationBuilder app, IWebHostBuilder env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<ProductApiGrpcService>();
            endpoints.MapControllers();
        });
    }*/
}