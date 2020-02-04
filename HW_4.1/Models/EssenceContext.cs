using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _4._0_GetPost.Models
{
    public class EssenceContext : DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Music> Musics { get; set; }
        public EssenceContext(DbContextOptions<EssenceContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
