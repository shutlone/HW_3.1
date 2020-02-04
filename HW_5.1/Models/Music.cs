using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._0_ViewModel.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Executor { get; set; }
        public string Genre { get; set; }
        public int Lenght { get; set; }
        public List<Alcohol> Alcohols { get; set; }
        public Music()
        {
            Alcohols = new List<Alcohol>();
        }

    }
}
