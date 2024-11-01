using AutoMapper;
using MovieApp.BLL.Models.Dto.WatchList;
using MovieApp.DAL.Context.Models;

namespace MovieApp.BLL.MappingProfiles;

public class WatchListProfile : Profile
{
    public WatchListProfile()
    {
        CreateMap<WatchListAddDto, WatchList>();
        CreateMap<WatchList, WatchListReadDto>();
    }   
}