using FlexBazaar.Catalog.Services.CategoryServices;
using FlexBazaar.Catalog.Services.ProductDetailServices;
using FlexBazaar.Catalog.Services.ProductImageServices;
using FlexBazaar.Catalog.Services.ProductServices;
using FlexBazaar.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( opt =>
    {
        opt.Authority = builder.Configuration["IdentityServerUrl"];
        // olu�turulan tokenlerle hangi sayfalara eri�ilece�ini belirler
        opt.Audience = "ResourceCatalog";
        // http kullanmak i�in. fakat canl�ya alaca��n zaman yorum sat�r�na al. 
         opt.RequireHttpsMetadata = false;
    });

// Scoped ilgili method �a��r�ld���nda bir nesne �rne�ini olu�turacak
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
