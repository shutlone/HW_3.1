using _5._0_ViewModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._0_ViewModel
{
    public class AlcoMusicContext : DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Music> Musics { get; set; }
        public AlcoMusicContext(DbContextOptions<AlcoMusicContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
