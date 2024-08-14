using AutoMapper;
using eMarkt.Catalog.Dtos.CategoryDtos;
using eMarkt.Catalog.Dtos.ProductDetailDtos;
using eMarkt.Catalog.Dtos.ProductDtos;
using eMarkt.Catalog.Dtos.ProductImageDtos;
using eMarkt.Catalog.Entities;

namespace eMarkt.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {

        //constructor içinde mapleme yapılacak.
        //Entityler ile Dto'ları eşliyecek. 
        //new'lemeye gerek kalmayacak.
        public GeneralMapping() {

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

        }     
    }
}
