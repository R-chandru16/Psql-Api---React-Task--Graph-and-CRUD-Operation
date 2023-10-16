using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForSmallProject.Models
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions options) : base(options)
        {
            //ctor
        }
        public DbSet<User> users { get; set; }
        public DbSet<Admin> admins { get; set; }
       
    }
}
