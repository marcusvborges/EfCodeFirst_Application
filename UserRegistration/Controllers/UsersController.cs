using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Data;
using UserRegistration.Entities.Models;

namespace UserRegistration.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Users> dataset;

        public UsersController(ApplicationContext context)
        {
            _context = context;
            dataset = _context.Set<Users>();
        }

        [HttpGet]
        public List<Users> GetUsers()
        {
           
            return dataset.ToList();
           
        }

        [HttpPost]
        public async Task<Users> CreateUsers([Bind("Id,Name,Email,DateBirth")] Users users)
        {
                 
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return users;
          
        }

        [HttpPut("{id}")]
        public async Task<Users> EditUsers(Users users) 
        {
            var result = dataset.SingleOrDefault(p => p.Id == users.Id);

            _context.Entry(result).CurrentValues.SetValues(users);
            await _context.SaveChangesAsync();
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var result = dataset.SingleOrDefault(p => p.Id == id);

            dataset.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
