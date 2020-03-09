using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HW_6._4_v2.Models
{
    public class AlcoholContext : DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Alco_type> Alco_types { get; set; }

        public AlcoholContext(DbContextOptions<AlcoholContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //=> optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=CarStoreNew63;Username=postgres;Password=89376650756;");
            => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=alcostoredb;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
