using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HW_6
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Alco_type> Types { get; set; }
        public DbSet<Alcohol> Alcohols { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=alcohols;Trusted_Connection=True;");
        }
    }
}
