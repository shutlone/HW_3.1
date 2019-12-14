using System;

namespace HW_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите x: ");

            int x = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Cos(x) + Math.Sin(x));

            Console.WriteLine((double)1 / Math.Pow(x + 5, 1) + (double)2 / Math.Pow(x + 5, 2) + (double)3 / Math.Pow(x + 5, 3));

            Console.WriteLine(Math.Sin(Math.Pow(x, 2)) + Math.Cos(Math.Pow(x, 2)));

            Console.WriteLine(Math.Pow(2, x) * Math.Pow(3, x) * Math.Pow(4, 1 / (x + 2)));

            Console.WriteLine(Math.Pow(Math.Sin(x), Math.Cos(x)));

        }
    }
}
