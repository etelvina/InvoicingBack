using AutoMapper;
using Data;
using Entity;

namespace Mapper.ProductMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
