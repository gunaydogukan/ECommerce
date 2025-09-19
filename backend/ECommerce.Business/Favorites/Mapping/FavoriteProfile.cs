using AutoMapper;
using ECommerce.Business.Favorites.Commands.Add;
using ECommerce.Business.Favorites.Dtos;
using ECommerce.Entities.Favorites;

namespace ECommerce.Business.Favorites.Profiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<AddFavroiteCommand, FavoriteCreateDto>();
            CreateMap<FavoriteCreateDto, Favorite>();

            CreateMap<Favorite, FavroiteResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<FavoriteCreateDto, Favorite>();
        }
    }
}