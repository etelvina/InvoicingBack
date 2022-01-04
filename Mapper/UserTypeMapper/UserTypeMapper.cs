using AutoMapper;
using Data;
using Entity;

namespace Mapper.UserTypeMapper
{
    public class UserTypeMapper : Profile
    {
        public UserTypeMapper()
        {
            CreateMap<UserType, UserTypeDTO>().ReverseMap();
        }
    }
}
