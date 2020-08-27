using System.ComponentModel.DataAnnotations;
using System;

namespace Core.Entities
{
    public class Holdings
    {
        [Key]
        public virtual int Id { get; }
        
        [Required]
        public virtual int UserId { get; set; }
        
        [Required]
        public virtual string StockSymbol { get; set; }

        [Required]
        public virtual string CompanyName { get; set; }

        [Required]
        public virtual DateTime PurchaseDate { get; set; }

        [Required]
        public virtual float PurchasePrice { get; set; }

        [Required]
        public virtual int PurchaseQty { get; set; }

        public virtual float LatestPrice { get; set; }

        public virtual float Week52High { get; set; }

        public virtual float Week52Low { get; set; }

        public virtual float YtdChange { get; set; }

        public virtual DateTime CreatedAt { get; }
    }
}
