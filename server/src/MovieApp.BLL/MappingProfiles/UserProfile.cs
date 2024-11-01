using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieApp.BLL.Models.Dto.UserDto;
using MovieApp.DAL.Context.Models;

namespace MovieApp.BLL.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegisterDto, AppUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}