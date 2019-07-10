using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDIT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
         ApiFunct apiFunct = new ApiFunct();
        // GET: api/Campaign
        [HttpGet("[action]")]
        public IEnumerable<Campaign> GetCampaign()
        {
            return apiFunct.GetCampaign();
        }
        
        [HttpPost("[action]")]
        public void PostCampaign(Campaign campaign)
        {
            apiFunct.CreateCampaign(campaign);

        }
        [HttpDelete("[action]/{id}")]
        public void DeleteCampaign(int id)
        {
            apiFunct.DeleteCampaign(id);
        }
        [HttpPut("[action]/{id}")]
        public void UpdateCampaign(int id,[FromBody]Campaign campaign)
        {
            apiFunct.UpdateCampaign(id,campaign);
        }
        

    }
}
