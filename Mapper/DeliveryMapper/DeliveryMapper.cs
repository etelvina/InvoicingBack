using AutoMapper;
using Data;
using Entity;

namespace Mapper.DeliveryMapper
{
    public class DeliveryMapper : Profile
    {
        public DeliveryMapper()
        {
            CreateMap<Delivery, DeliveryDTO>().ReverseMap();
        }
    }
}
