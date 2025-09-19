using AutoMapper;
using ECommerce.Business.Products.Commands.Add;
using ECommerce.Business.Products.Commands.Update;
using ECommerce.Business.Products.Dtos;
using ECommerce.Entities.Catalog;

namespace ECommerce.Business.Products.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Product, ProductResponseDto>();

        }
    }
}