using AutoMapper;
using Data;
using Entity;

namespace Mapper.InvoiceMapper
{
    public class InvoiceMapper : Profile
    {
        public InvoiceMapper()
        {
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
        }
    }
}