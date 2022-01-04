using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Product
    {
        public Product()
        {
            Details = new HashSet<Detail>();
        }

        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdState { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public int Stock { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
