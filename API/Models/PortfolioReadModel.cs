using System;

namespace API.Models
{
    public class PortfolioReadModel
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual string StockSymbol { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual double PurchasePrice { get; set; }
    }
}
