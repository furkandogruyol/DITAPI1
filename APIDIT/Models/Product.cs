using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class Product
    {
        public Product()
        {
            Campaign = new HashSet<Campaign>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long ProductBarcode { get; set; }
        public int ProductCount { get; set; }
        public double ProductWeight { get; set; }

        public ICollection<Campaign> Campaign { get; set; }
    }
}
