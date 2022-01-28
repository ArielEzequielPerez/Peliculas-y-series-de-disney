using AutoMapper;
using PeliculasSeries.Dto;

namespace PeliculasSeries.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserListDto>();
            

        }
    }
}
