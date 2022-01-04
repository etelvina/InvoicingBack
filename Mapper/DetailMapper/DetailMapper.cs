using AutoMapper;
using Data;
using Entity;

namespace Mapper.DetailMapper
{
    public class DetailMapper : Profile
    {
        public DetailMapper()
        {
            CreateMap<Detail, DetailDTO>().ReverseMap();
        }
    }
}
