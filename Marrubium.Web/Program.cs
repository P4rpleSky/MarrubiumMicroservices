using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.V8;
using React.AspNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddReact();
builder.Services.AddJsEngineSwitcher(options => 
        options.DefaultEngineName = V8JsEngine.EngineName)
    .AddV8();

var app = builder.Build();

app.UseReact(config => { });

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { Controller = "Home", Action = "Main"});

app.MapControllerRoute(
    name: "products_catalog_route",
    pattern: "catalog/{id?}",
    defaults: new { controller = "Catalog", action = "Main" });

app.MapControllerRoute(
    name: "home_pages_route",
    pattern: "{action}",
    defaults: new { controller = "Home" });


app.Run();
