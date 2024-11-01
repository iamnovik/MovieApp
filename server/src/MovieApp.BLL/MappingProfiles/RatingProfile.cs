using AutoMapper;
using MovieApp.BLL.Models.Dto.RatingDto;
using MovieApp.DAL.Context.Models;

namespace MovieApp.BLL.MappingProfiles;

public class RatingProfile : Profile
{
    public RatingProfile()
    {
        CreateMap<RatingAddDto, Rating>();
        CreateMap<RatingUpdateDto, Rating>();
        CreateMap<Rating, RatingReadDto>();
    }
}