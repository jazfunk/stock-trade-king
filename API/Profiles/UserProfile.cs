using AutoMapper;
using Core.Entities;
using API.Models;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Source -> Target
            CreateMap<User, UserReadModel>();
            CreateMap<UserCreateModel, User>();
            CreateMap<UserUpdateModel, User>();
            CreateMap<User, UserUpdateModel>();
        }
    }
}
