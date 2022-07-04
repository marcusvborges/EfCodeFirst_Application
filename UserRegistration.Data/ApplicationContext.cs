using Microsoft.EntityFrameworkCore;
using System;
using UserRegistration.Entities.Models;

namespace UserRegistration.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Users> Users { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
      
    }
}

