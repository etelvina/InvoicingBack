using AutoMapper;
using Data;
using Entity;

namespace Mapper.StateInvoiceMapper
{
    public class StateInvoiceMapper : Profile
    {
        public StateInvoiceMapper()
        {
            CreateMap<StateInvoice, StateInvoiceDTO>().ReverseMap();
        }
    }
}
