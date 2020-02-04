using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    class StorageManager : Manager
    {
        public override void Add()
        {
            Program.Print("Введите id");
            int id = Program.Read();
            if(Globals.storage.FindIndex(x => x.Id == id) != -1)
            {
                Program.Print("Такой id уже есть");
                return;
            }
            Program.Print("Введите объем напитка:");
            int v = Program.Read();
            Program.Print("Введите id типа напитка:");
            int tp = Program.Read();
            if (Globals.types.FindIndex(x => x.Id == tp) == -1)
            {
                Program.Print("Напитка такого типа нет в базе");
                return;
            }
            Program.Print("Введите id бренда");
            int br = Program.Read();
            if (Globals.brands.FindIndex(x => x.Id == br) == -1)
            {
                Program.Print("Такого бренда нет в базе");
                return;
            }
            Program.Print("Введите крепость:");
            int st = Program.Read();
            if(st > 90)
            {
                Program.Print("Неккоректная крепость");
                return;
            }
            Globals.storage.Add(new Alcohol(id, tp, br, st, v));
            Program.Print("Напиток успешно добавлен!");
        }

        public override void Remove()
        {
            Program.Print("Введите id");
            int id = Program.Read();
            if (Globals.storage.FindIndex(x => x.Id == id) != -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            Globals.storage.Remove(Globals.storage.Find(x => x.Id == id));
            Program.Print("Напиток успешно удален");
        }

        public override void GetAll()
        {
            foreach(Alcohol al in Globals.storage)
            {
                al.Print();
            }
        }

        public override void Change()
        {
            Program.Print("Введите id напитка литраж которого хотите изменить");
            int id = Program.Read();
            if (Globals.storage.FindIndex(x => x.Id == id) == -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            Program.Print("Введите величину изменения(с минусом для уменьшения)");
            int ch;
            try
            {
                ch = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Program.Print("Некорректный ввод");
                return;
            }
            if(ch < 0 && Math.Abs(ch) > Globals.storage.Find(x => x.Id == id).Volume)
            {
                Program.Print("Указанный объем больше чем есть в наличии, обнуление текущего объема");
                Globals.storage.Find(x => x.Id == id).Volume = 0;
                return;
            }
            Globals.storage.Find(x => x.Id == id).Volume -= ch;
        }

        public override void Change(int i, int ch)
        {
            
            int v = Globals.storage.Find(x => x.Id == i).Volume;
            if(v == 0)
            {
                Program.Print("Кончился, извиняй");
                return;
            }
            if(v < ch)
            {
                Program.Print($"Вот {v}, все что есть, больше нет(");
                Globals.storage.Find(x => x.Id == i).Volume = 0;
                return;
            }
            Program.Print("Все для тебя!");

            Globals.storage.Find(x => x.Id == i).Volume -= ch;
            return;
        }

        public override void GetById()
        {
            Program.Print("Введите id");
            int id = Program.Read();
            if (Globals.storage.FindIndex(x => x.Id == id) == -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            Globals.storage.Find(x => x.Id == id).Print();
        }
        public override int Find(int type, int brand)
        {
            foreach(Alcohol al in Globals.storage)
            {
                if(al.BrandId == brand && al.TypeId == type)
                {
                    return al.Id;
                }
            }
            return -1;
        }
        public StorageManager() { }
    }
}
