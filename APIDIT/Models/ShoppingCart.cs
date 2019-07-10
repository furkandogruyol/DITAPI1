using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            Bill = new HashSet<Bill>();
        }

        public int ShoppingCartId { get; set; }
        public int BillId { get; set; }
        public string ShoppingHistory { get; set; }

        public Bill BillNavigation { get; set; }
        public ICollection<Bill> Bill { get; set; }
    }
}
