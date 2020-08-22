using Core.Entities;
using FluentNHibernate.Mapping;

namespace Infrastructure.Mappings
{
    public class UserPortfolioMap : ClassMap<UserPortfolio>
    {
        public UserPortfolioMap()
        {
            Id(x => x.Id).Column("id");
            Map(x => x.UserId).Column("user_id");
            Map(x => x.StockSymbol).Column("stock_symbol");
            Map(x => x.PurchaseDate).Column("purchase_date");
            Map(x => x.PurchasePrice).Column("purchase_price");
            Table("users_portfolio");
        }
    }
}
