using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class State
    {
        public State()
        {
            Invoices = new HashSet<Invoice>();
            Products = new HashSet<Product>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
