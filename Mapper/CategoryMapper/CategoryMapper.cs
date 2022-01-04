using AutoMapper;
using Data;
using Entity;

namespace Mapper.CategoryMapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
