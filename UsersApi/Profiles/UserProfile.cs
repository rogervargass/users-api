using AutoMapper;
using UsersApi.Data.DTOs;
using UsersApi.Models;

namespace UsersApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
