using AutoMapper;
using Data;
using Entity;

namespace Mapper.StateMapper
{
    public class StateMapper : Profile
    {
        public StateMapper()
        {
            CreateMap<State, StateDTO>().ReverseMap();
        }
    }
}