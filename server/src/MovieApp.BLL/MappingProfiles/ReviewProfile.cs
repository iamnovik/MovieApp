using AutoMapper;
using MovieApp.BLL.Models.Dto.ReviewDto;
using MovieApp.DAL.Context.Models;

namespace MovieApp.BLL.MappingProfiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewAddDto, Review>();
        CreateMap<ReviewUpdateDto, Review>();
        CreateMap<Review, ReviewReadDto>();
    }   
}