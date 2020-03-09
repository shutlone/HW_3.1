using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HW_6._3
{
    class AlcoholContext : DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Alco_types> Alco_Types { get; set; }
        public AlcoholContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Database=CarStoreNew63_3;Username=postgres;Password=89376650756;");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=alcoholdb;Trusted_Connection=True;");
        }
    }
}
