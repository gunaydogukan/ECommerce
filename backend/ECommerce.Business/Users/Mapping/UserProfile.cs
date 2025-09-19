using AutoMapper;
using ECommerce.Business.Users.Commands.Register;
using ECommerce.Business.Users.Commands.Login;
using ECommerce.Business.Users.Commands.Update;
using ECommerce.Business.Users.Dtos;
using ECommerce.Entities.Identity;

namespace ECommerce.Business.Users.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Register
            CreateMap<RegisterUserCommand, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();

            // Login
            CreateMap<LoginUserCommand, UserLoginDto>();

            // Update
            CreateMap<UpdateUserCommand, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();

            // Response
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            CreateMap<UserRegisterDto, UserResponseDto>();

            CreateMap<RegisterUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}