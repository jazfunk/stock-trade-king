using AutoMapper;
using Core.Entities;
using API.Models;

namespace API.Profiles
{
    public class LedgerProfile : Profile
    {
        public LedgerProfile()
        {
            // Source -> Target
            CreateMap<Ledger, LedgerReadModel>();
            CreateMap<LedgerCreateModel, Ledger>();
            CreateMap<LedgerUpdateModel, Ledger>();
            CreateMap<Ledger, LedgerUpdateModel>();
        }
    }
}
