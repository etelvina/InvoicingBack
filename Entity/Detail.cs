using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Detail
    {
        public Detail()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public decimal Importe { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Vat { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
