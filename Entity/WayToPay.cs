using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class WayToPay
    {
        public WayToPay()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
