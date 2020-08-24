using AutoMapper;
using Core.Entities;
using API.Models;

namespace API.Profiles
{
    public class UserPortfolioProfile : Profile
    {
        public UserPortfolioProfile()
        {
            // Source -> Target
            CreateMap<UserPortfolio, PortfolioReadModel>();
            CreateMap<PortfolioCreateModel, UserPortfolio>();
            CreateMap<PortfolioUpdateModel, UserPortfolio>();
            CreateMap<UserPortfolio, PortfolioUpdateModel>();
            CreateMap<UserPortfolio, IexPortfolioReadModel>();
        }
    }
}
