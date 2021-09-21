using AutoMapper;
using Core.Domain;
using TeamWebService.Models;

namespace TeamWebService.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewGameDTO, NewCreatedGameDto>();
            CreateMap<Game, UpdatedGameDTO>();
        }
    }
}