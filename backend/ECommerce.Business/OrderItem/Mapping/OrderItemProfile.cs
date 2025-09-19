using AutoMapper;
using ECommerce.Business.OrderItem.Dtos;
using ECommerce.Entities.Orders;

namespace ECommerce.Business.OrderItem.Mapping
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<Entities.Orders.OrderItem, OrderItemResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Quantity * src.UnitPrice));

            CreateMap<OrderItemCreateDto, Entities.Orders.OrderItem>();
        }
    }
}