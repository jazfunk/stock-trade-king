using Core.Entities;
using FluentNHibernate.Mapping;

namespace Infrastructure.Mappings
{
    public class LedgerMap : ClassMap<Ledger>
    {
        public LedgerMap()
        {
            Id(x => x.Id).Column("id");
            Map(x => x.HoldingId).Column("holding_id");
            Map(x => x.LedgerType).Column("ledger_type");
            Map(x => x.LedgerDate).Column("ledger_date");
            Map(x => x.LedgerPrice).Column("ledger_price");
            Map(x => x.LedgerQty).Column("ledger_qty");
            Map(x => x.CreatedAt).Column("created_at");
            Table("ledger");
        }
    }
}
