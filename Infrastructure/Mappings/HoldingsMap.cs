using Core.Entities;
using FluentNHibernate.Mapping;

namespace Infrastructure.Mappings
{
    public class HoldingsMap : ClassMap<Holdings>
    {
        public HoldingsMap()
        {
            Id(x => x.Id).Column("id");
            Map(x => x.UserId).Column("user_id");
            Map(x => x.StockSymbol).Column("stock_symbol");
            Map(x => x.CompanyName).Column("company_name");
            Map(x => x.PurchaseDate).Column("purchase_date");
            Map(x => x.PurchasePrice).Column("purchase_price");
            Map(x => x.PurchaseQty).Column("purchase_qty");
            Map(x => x.LatestPrice).Column("latest_price");
            Map(x => x.Week52High).Column("week52_high");
            Map(x => x.Week52Low).Column("week52_low");
            Map(x => x.YtdChange).Column("ytd_change");
            Map(x => x.CreatedAt).Column("created_at");
            Table("holdings");
        }
    }
}
