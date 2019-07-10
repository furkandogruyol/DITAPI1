using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDIT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIDIT.Models;
namespace APIDIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ApiFunct apiFunct = new ApiFunct();

        [HttpPost("[action]")]
        public void PostProduct(Product product)
        {
            apiFunct.CreateProduct(product);
        }
        [HttpGet("[action]")]
        public IEnumerable<Product> GetProducts()
        {
            return apiFunct.GetProducts();
        }
        [HttpDelete("[action]/{id}")]
        public void DeleteProducts(int id)
        {
            apiFunct.DeleteProduct(id);
        }
        [HttpPut("[action]/{id}")]
        public void UpdateProduct(int id,[FromBody]Product product)
        {
            apiFunct.UpdateProduct(id, product);
        }
        
    }
}