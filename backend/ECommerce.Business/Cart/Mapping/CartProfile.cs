using AutoMapper;
using ECommerce.Business.Cart.Commands.Add;
using ECommerce.Business.Cart.Commands.Update;
using ECommerce.Business.Cart.Dtos;
using ECommerce.Entities.Orders;

namespace ECommerce.Business.Cart.Mapping
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            // Command -> DTO
            CreateMap<AddToCartCommand, CartCreateDto>();
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<UpdateCartCommand, CartUpdateDto>();

            CreateMap<UpdateCartCommand, Entities.Orders.Cart>();

            // DTO -> Entity
            CreateMap<CartCreateDto, Entities.Orders.Cart>();
            CreateMap<CartUpdateDto, Entities.Orders.Cart>();

            // Entity -> Response
            CreateMap<Entities.Orders.Cart, CartResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.Price));
        }
    }
}