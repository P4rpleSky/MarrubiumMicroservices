var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { Controller = "Home", Action = "Main"});

app.MapControllerRoute(
    name: "products_catalog",
    pattern: "catalog/{id?}",
    defaults: new { controller = "Catalog", action = "Main" });

app.Run();
