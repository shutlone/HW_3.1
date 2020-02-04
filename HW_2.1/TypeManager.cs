using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    public class TypeManager : Manager
    {
        public override void Add()
        {
            Program.Print("Введите название типа:");
            string s = Console.ReadLine();
            Program.Print("Введите id типпа");
            int id = Program.Read();
            if (Globals.types.FindIndex(x => x.Id == id) != -1)
            {
                Program.Print("Тип с таким id уже есть");
                return;
            }
            Globals.types.Add(new Brand(s, id));
            Program.Print("Тип успешно добавлен!");
        }

        public override void Remove()
        {
            Program.Print("Введите id");
            int id = Program.Read();
            if (Globals.types.FindIndex(x => x.Id == id) != -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            foreach(Alcohol al in Globals.storage)
            {
                if (al.TypeId == id)
                    Globals.storage.Remove(al);
            }
            Globals.types.Remove(Globals.types.Find(x => x.Id == id));
            Program.Print("Тип успешно удален");
            
        }

        public override void GetAll()
        {
            foreach (Type tp in Globals.types)
            {
                Program.Print(tp.Id.ToString() + " " + tp.Name);
            }
        }

        public override void GetById()
        {
            Program.Print("Введите id");
            int id = Program.Read();
            if (Globals.types.FindIndex(x => x.Id == id) == -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            Program.Print(Globals.types.Find(x => x.Id == id).Name);
        }
        public override string GetById(int id)
        {
            return Globals.types.Find(x => x.Id == id).Name;
        }
        public override void Change()
        {
            Program.Print("Введите id типа который желаетет изменить");
            int id = Program.Read();
            if (Globals.types.FindIndex(x => x.Id == id) == -1)
            {
                Program.Print("Такого id не существует");
                return;
            }
            Program.Print("Введите новое имя типа");
            string s = Console.ReadLine();
            Globals.types.Find((x => x.Id == id)).Name = s;
            Program.Print("Тип изменен");
        }
        public TypeManager() { }
    }
}
