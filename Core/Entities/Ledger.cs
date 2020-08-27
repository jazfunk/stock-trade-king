using System.ComponentModel.DataAnnotations;
using System;

namespace Core.Entities
{
    public class Ledger
    {
        [Key]
        public virtual int Id { get; }

        [Required]
        public virtual int HoldingId { get; set; }

        public virtual string LedgerType { get; set; }

        public virtual DateTime LedgerDate { get; set; }

        [Required]
        public virtual float LedgerPrice { get; set; }
        
        [Required]
        public virtual int LedgerQty { get; set; }

        public virtual DateTime CreatedAt { get; }
    }
}
