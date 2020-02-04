using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    public class Cassir : Manager
    {
        public override void Buy(int s, int s1)
        {

            int id = Globals.managers["storage"].Find(s, s1);
            if(id == -1)
            {
                Program.Print("Извини, такого в налиии нет");
                return;
            }
            Program.Print("Сколько бокалов?");
            int ch = Program.Read();
            Globals.managers["storage"].Change(id, ch);
        }
        public Cassir() { }
    }
}
