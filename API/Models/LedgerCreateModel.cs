using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class LedgerCreateModel
    {
        [Required]
        public int HoldingId { get; set; }

        public string LedgerType { get; set; }

        public DateTime LedgerDate { get; set; }

        [Required]
        public float LedgerPrice { get; set; }

        [Required]
        public int LedgerQty { get; set; }
    }
}
