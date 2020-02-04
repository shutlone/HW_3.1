using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExtraTask.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string moderRoleName = "moder";
            string consultantRoleName = "consultant";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role moderRole = new Role { Id = 2, Name = moderRoleName };
            Role consultantRole = new Role { Id = 3, Name = consultantRoleName };
            Admin adminUser = new Admin { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, moderRole, consultantRole });
            modelBuilder.Entity<Admin>().HasData(new Admin[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
