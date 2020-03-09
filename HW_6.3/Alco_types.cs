using System;
using System.Collections.Generic;
using System.Text;

namespace HW_6._3
{
    public class Alco_types
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public List<Alcohol> Alcohols { get; set; }
        public Alco_types()
        {
            Alcohols = new List<Alcohol>();
        }
    }
}
