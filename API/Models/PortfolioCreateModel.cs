using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class PortfolioCreateModel
    {

        [Required]
        public virtual int UserId { get; set; }

        [Required]
        public virtual string StockSymbol { get; set; }

        [Required]
        public virtual DateTime PurchaseDate { get; set; }

        [Required]
        public virtual double PurchasePrice { get; set; }
    }
}
