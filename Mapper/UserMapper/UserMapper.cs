using AutoMapper;
using Data;
using Entity;

namespace Mapper.UserMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
