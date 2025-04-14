using AutoMapper;
using FlexBazaar.Catalog.Dtos.CategoryDtos;
using FlexBazaar.Catalog.Dtos.ProductDetailDtos;
using FlexBazaar.Catalog.Dtos.ProductDtos;
using FlexBazaar.Catalog.Dtos.ProductImageDtos;
using FlexBazaar.Catalog.Entities;

namespace FlexBazaar.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping() {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap(); 
            
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap(); 

            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();
        } 
    }
}
