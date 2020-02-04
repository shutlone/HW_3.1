using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._0_ViewModel.Models
{
    public class Alcohol
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Strength { get; set; }
        public int Volume { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan LifeTime { get { return DateTime.Now - CreationDate; } }
        public int MusicId { get; set; }
        public Music Music { get; set; }
    }
}
