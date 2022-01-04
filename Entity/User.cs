using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public int IdState { get; set; }
        public int IdUserType { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual UserType IdUserTypeNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
