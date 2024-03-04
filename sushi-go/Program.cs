using sushi_go.Services;
using sushi_go.Services.Interfaces;
using Umbraco.Cms.Core.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder
        .SetIsOriginAllowed((host) => true)
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddTransient<IMenuService, MenuService>();
builder.Services.AddTransient<ISiteSettingsService, SiteSettingsService>();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseCors("AllowAnyOrigin");

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
