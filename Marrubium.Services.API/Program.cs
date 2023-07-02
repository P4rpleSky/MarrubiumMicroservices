using AutoMapper;
using Marrubium.Services.ProductAPI;
using Marrubium.Services.ProductAPI.DbContexts;
using Marrubium.Services.ProductAPI.GrpcServices;
using Marrubium.Services.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

/*
static IHostBuilder CreateHostBuilder(string[] args)
    => Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(this.Configuration.GetConnectionString("DefaultConnection")));
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.Servis
        })
        */

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddGrpc();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Marrubium.Services.ProductAPI",
        Version = "v1"
    });
});

const string apiPolicyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: apiPolicyName,
        policyBuilder =>
        {
            policyBuilder.WithOrigins(builder.Configuration["WebUrl"]).AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(apiPolicyName);

app.UseAuthorization();

app.MapGrpcService<ProductApiGrpcService>();

app.MapControllers();

app.Run();
