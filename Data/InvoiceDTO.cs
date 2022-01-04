using System;

namespace Data
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int IdDelivery { get; set; }
        public int IdDetail { get; set; }
        public int IdState { get; set; }
        public int IdStateInvoice { get; set; }
        public int IdUser { get; set; }
        public int IdWayToPay { get; set; }
        public DateTime DateTime { get; set; }
    }
}
