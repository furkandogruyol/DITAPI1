using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDIT.Models;

namespace APIDIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DITContext _context;
        ApiFunct apiFunct = new ApiFunct();
        public UsersController(DITContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet("[action]")]
        public IEnumerable<User> GetUser()
        {
            return apiFunct.GetUsers();
        }


        // GET: api/Users/5
        [HttpGet("[action]/{email}")]
        public User GetUserByEmail(string email)
        {
            return apiFunct.GetUsersByEmail(email);
        }

        // PUT: api/Users/5
        [HttpPut("[action]/{id}")]
        public void UpdateUser(int id, [FromBody] User user)
        {
             apiFunct.UpdateUser(id,user);
        }

        // POST: api/Users
        [HttpPost("[action]")]
        public void PostUser(User user)
        {
            apiFunct.CreateUser(user);    

        }

        [HttpDelete("[action]/{id}")]
        public void DeleteProducts(int id)
        {
            apiFunct.DeleteUser(id);
        }
        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
        
    }
}