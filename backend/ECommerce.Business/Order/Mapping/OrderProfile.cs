using AutoMapper;
using ECommerce.Business.Order.Commands.Add;
using ECommerce.Business.Order.Dtos;
using ECommerce.Business.OrderItem.Dtos;
using ECommerce.Entities.Orders;

namespace ECommerce.Business.Order.Mapping;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<AddOrderCommand, OrderCreateDto>();

        CreateMap<Entities.Orders.Order, OrderResponseDto>();
        CreateMap<Entities.Orders.OrderItem, OrderItemResponseDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        CreateMap<OrderCreateDto, Entities.Orders.Order>();
    }
}