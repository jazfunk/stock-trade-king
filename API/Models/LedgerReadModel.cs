using System;


namespace API.Models
{
    public class LedgerReadModel
    {
        public int Id { get; }
        public int HoldingId { get; set; }
        public string LedgerType { get; set; }
        public DateTime LedgerDate { get; set; }
        public float LedgerPrice { get; set; }
        public int LedgerQty { get; set; }
        public DateTime CreatedAt { get; }
    }
}
