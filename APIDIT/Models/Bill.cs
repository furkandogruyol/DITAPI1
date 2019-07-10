using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class Bill
    {
        public Bill()
        {
            ShoppingCartNavigation = new HashSet<ShoppingCart>();
        }

        public int BillId { get; set; }
        public DateTime BillDate { get; set; }
        public int UserId { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime BillValidityTime { get; set; }
        public string BillPayment { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
        public User User { get; set; }
        public ICollection<ShoppingCart> ShoppingCartNavigation { get; set; }
    }
}
