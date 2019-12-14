using System;

namespace HW_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите минимальный элемент");
            int min = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимальный элемент");
            int max = int.Parse(Console.ReadLine());

            int[] arr = new int[length];

            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.Next(min, max + 1);
                Console.Write(arr[i] + " ");
            }
        }
    }
}
