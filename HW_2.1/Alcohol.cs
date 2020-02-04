using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    public class Alcohol
    {
        string Find(ref List<Type> l) => l.Find(x => x.Id == TypeId).Name;
        string Find(ref List<Brand> l) => l.Find(x => x.Id == BrandId).Name;
        public int Id { get; set; }
        public int Volume { get; set; }
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public int Strength { get; set; }
        public Alcohol(int id, int tid, int bid, int s, int v = 0) {Id = id; Volume = v; TypeId = tid; BrandId = bid; Strength = s; }

        public void Print()
        {
            Console.WriteLine($"Тип: { Find(ref Globals.types) }, Бренд: {Find(ref Globals.brands)}, Объем: {Volume} порции. Крепость: {Strength}");
        }
    }
}
