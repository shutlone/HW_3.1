using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    public class BrandManager : Manager
    {
        public override void Add()
        {
            Program.Print("Введите наименование бренда:");
            string s = Console.ReadLine();
            Program.Print("Введите id бренда");
            int id = Program.Read();
            if(Globals.brands.FindIndex(x => x.Id == id) != -1)
            {
                Program.Print("Бренд с таким id уже есть");
                return;
            }
            Globals.brands.Add(new Brand(s,id));
            Program.Print("Бренд успешно добавлен!");
        }

        public override void Remove()
        {
            Program.Print("Введите id");
            int id = Program.Read();
            if (Globals.brands.FindIndex(x => x.Id == id) != -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            foreach (Alcohol al in Globals.storage)
            {
                if (al.TypeId == id)
                    Globals.storage.Remove(al);
            }
            Globals.brands.Remove(Globals.brands.Find(x => x.Id == id));
            Program.Print("Бренд успешно удален");
        }

        public override void GetAll()
        {
            foreach (Brand br in Globals.brands)
            {
                Program.Print(br.Id.ToString() + " " + br.Name);
            }
        }

        public override void GetById()
        {
            Program.Print("Введите id");
            int id = Program.Read();
            if (Globals.brands.FindIndex(x => x.Id == id) == -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            Program.Print(Globals.brands.Find(x => x.Id == id).Name);
        }

        public override string GetById(int id)
        {
            return Globals.brands.Find(x => x.Id == id).Name;
        }

        public override void Change()
        {
            Program.Print("Введите id бренда который желаетет изменить");
            int id = Program.Read();
            if (Globals.brands.FindIndex(x => x.Id == id) == -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            Program.Print("Введите новое название бренда");
            string s = Console.ReadLine();
            Globals.brands.Find((x => x.Id == id)).Name = s;
            Program.Print("Бренд изменен");
        }
        public BrandManager() { }
    }
}
