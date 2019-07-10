using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class Admin
    {
        public Guid AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
    }
}
