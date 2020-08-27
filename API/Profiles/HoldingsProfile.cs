using AutoMapper;
using Core.Entities;
using API.Models;

namespace API.Profiles
{
    public class HoldingsProfile : Profile
    {
        public HoldingsProfile()
        {
            // Source -> Target
            CreateMap<Holdings, HoldingsReadModel>();
            CreateMap<HoldingsCreateModel, Holdings>();
            CreateMap<HoldingsUpdateModel, Holdings>();
            CreateMap<Holdings, HoldingsUpdateModel>();
        }
    }
}
