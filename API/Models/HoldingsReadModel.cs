using System;

namespace API.Models
{
    public class HoldingsReadModel
    {
        public int Id { get; }
        public int UserId { get; set; }
        public string StockSymbol { get; set; }
        public string CompanyName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float PurchasePrice { get; set; }
        public int PurchaseQty { get; set; }
        public float LatestPrice { get; set; }
        public float Week52High { get; set; }
        public float Week52Low { get; set; }
        public float YtdChange { get; set; }
        public DateTime CreatedAt { get; }
    }
}
