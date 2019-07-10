using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class User
    {
        public User()
        {
            Bill = new HashSet<Bill>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress { get; set; }

        public ICollection<Bill> Bill { get; set; }
    }
}
