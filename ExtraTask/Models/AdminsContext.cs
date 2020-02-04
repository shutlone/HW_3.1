using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExtraTask.Models
{
    public class AdminsContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public AdminsContext(DbContextOptions<AdminsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
