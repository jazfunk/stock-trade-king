using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class LedgerUpdateModel
    {
        [Required]
        public virtual int HoldingId { get; set; }

        public virtual string LedgerType { get; set; }

        public virtual DateTime LedgerDate { get; set; }

        [Required]
        public virtual float LedgerPrice { get; set; }

        [Required]
        public virtual int LedgerQty { get; set; }
    }
}
