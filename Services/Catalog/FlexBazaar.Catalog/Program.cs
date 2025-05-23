using FlexBazaar.Catalog.Services.AboutServices;
using FlexBazaar.Catalog.Services.BrandServices;
using FlexBazaar.Catalog.Services.CategoryServices;
using FlexBazaar.Catalog.Services.ContactServices;
using FlexBazaar.Catalog.Services.FeatureServices;
using FlexBazaar.Catalog.Services.FeatureSliderServices;
using FlexBazaar.Catalog.Services.OfferDiscountServices;
using FlexBazaar.Catalog.Services.ProductDetailServices;
using FlexBazaar.Catalog.Services.ProductImageServices;
using FlexBazaar.Catalog.Services.ProductServices;
using FlexBazaar.Catalog.Services.SpecialOfferServices;
using FlexBazaar.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( opt =>
    {
        opt.Authority = builder.Configuration["IdentityServerUrl"];
        // oluşturulan tokenlerle hangi sayfalara erişileceğini belirler
        opt.Audience = "ResourceCatalog";
        // http kullanmak için. fakat canlıya alacağın zaman yorum satırına al. 
         opt.RequireHttpsMetadata = false;
    });

// Scoped ilgili method çağırıldığında bir nesne örneğini oluşturacak
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

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
