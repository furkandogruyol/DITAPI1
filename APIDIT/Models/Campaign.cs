using System;
using System.Collections.Generic;

namespace APIDIT.Models
{
    public partial class Campaign
    {
        public int CampaignId { get; set; }
        public long ProductId { get; set; }
        public string CampaignType { get; set; }
        public string CampaignDetail { get; set; }
        public DateTime ValidationTime { get; set; }

        public Product Product { get; set; }
    }
}
