using System;

namespace API.Models
{
    public class IexPortfolioReadModel
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual string StockSymbol { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual double PurchasePrice { get; set; }

        
        // Add these fields to table

        public virtual int ShareQty { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual double LatestPrice { get; set; }

        public virtual double Week52High { get; set; }

        public virtual double Week52Low { get; set; }

        public virtual double YtdChange { get; set; }

    }
}
