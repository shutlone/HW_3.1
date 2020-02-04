using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    class Program
    {
        static string[] one = new string[] { "напиток на склад", "бренд", "тип напитка" };
        static string[] two = new string[] { "напитке", "бренде", "типе напитка" };
        static string[] three = new string[] { "объем напитка в наличии", "существующий бренд", "существующий тип" };
        static string[] four = new string[] { "напитки", "бренды", "типы напитков" };
        static string[] five = new string[] { "напиток со склада", "бренд", "тип напитка" };
        static void ChooseManagerMethod(string s, int i)
        {
            Print($"Выберете действие:\n1 - добавить новый {one[i]}\n2 - получить информацию о {two[i]} по id\n3 - изменить {three[i]}\n4 - вывести все {four[i]}\n5 - удалить {five[i]} по id");
            int a = Read();
            switch (a)
            {
                case 1:
                    Globals.managers[s].Add();
                    break;
                case 2:
                    Globals.managers[s].GetById();
                    break;
                case 3:
                    Globals.managers[s].Change();
                    break;
                case 4:
                    Globals.managers[s].GetAll();
                    break;
                case 5:
                    Globals.managers[s].Remove();
                    break;
            }
        }
        public static void Print(string v)
        {
            Console.WriteLine();
            Console.WriteLine(v);
        }

        public static int Read()
        {
            int a = -1;
            while(true)
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a < 0) throw new Exception();
                    break;
                }
                catch
                {
                    return -1;
                }
            }
            
            return a;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int _in;
                while (true)
                {
                    Print("Введите:\n1 - для работы с менеджерами\n2 - купить напиток\n0 - для выхода ");

                    _in = Read();

                    switch (_in)
                    {
                        case 1:
                            Print("Выберете менеджера:\n1 - менеджер склада\n2 - менеджер брендов\n3 - менеджер типов");
                            int a = Read();
                            switch (a)
                            {
                                case 1:
                                    ChooseManagerMethod("storage", 0);
                                    break;
                                case 2:
                                    ChooseManagerMethod("brand", 1);
                                    break;
                                case 3:
                                    ChooseManagerMethod("type", 2);
                                    break;
                            }
                            break;
                        case 2:
                            Print("Приветсвуем! Сегодня у нас в наличии:");
                            Globals.managers["type"].GetAll();
                            Print("Чего вам налить?");
                            int s = Read();
                            Globals.managers["brand"].GetAll();
                            Print("От какого бренда?");
                            int s2 = Read();
                            Globals.managers["cassir"].Buy(s, s2);
                            break;
                        case 0:
                            return;
                        default:
                            Print("Некорректный ввод");
                            break;
                    }
                }
            }
        }
    }
}