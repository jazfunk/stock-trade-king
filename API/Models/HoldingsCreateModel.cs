using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class HoldingsCreateModel
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        public string StockSymbol { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public float PurchasePrice { get; set; }

        [Required]
        public int PurchaseQty { get; set; }

        public float LatestPrice { get; set; }

        public float Week52High { get; set; }

        public float Week52Low { get; set; }

        public float YtdChange { get; set; }
    }
}
