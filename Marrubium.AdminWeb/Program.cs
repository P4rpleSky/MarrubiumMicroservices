using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Marrubium.AdminWeb;
using Marrubium.AdminWeb.Services;
using Marrubium.Services.ProductAPI.Grpc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddGrpcClient<ProductApiGrpc.ProductApiGrpcClient>(o =>
{
    o.Address = new Uri(builder.Configuration["ServiceUrls:ProductAPI"] ?? "");
});

/*using var channel = GrpcChannel.ForAddress(builder.Configuration["ServiceUrls:ProductAPI"]?? "");
var grpcClient = new ProductApiGrpc.ProductApiGrpcClient(channel);
builder.Services.AddSingleton(grpcClient);*/

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=ProductListIndex}");

app.Run();