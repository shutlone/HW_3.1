using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_6._4_v2.Models
{
    public class Alcohol
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public Alco_type Alco_type { get; set; }
        public double Volume { get; set; }
        public int Strength { get; set; }
    }
}
