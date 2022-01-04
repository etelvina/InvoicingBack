using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public int IdDelivery { get; set; }
        public int IdDetail { get; set; }
        public int IdState { get; set; }
        public int IdStateInvoice { get; set; }
        public int IdUser { get; set; }
        public int IdWayToPay { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Delivery IdDeliveryNavigation { get; set; }
        public virtual Detail IdDetailNavigation { get; set; }
        public virtual StateInvoice IdStateInvoiceNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual WayToPay IdWayToPayNavigation { get; set; }
    }
}
