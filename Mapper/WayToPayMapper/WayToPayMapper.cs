using AutoMapper;
using Data;
using Entity;

namespace Mapper.WayToPayMapper
{
    public class WayToPayMapper : Profile
    {
        public WayToPayMapper()
        {
            CreateMap<WayToPay, WayToPayDTO>().ReverseMap();
        }
    }
}
