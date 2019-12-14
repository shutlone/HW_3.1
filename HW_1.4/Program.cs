using System;

namespace HW_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;

            int[] arr = new int[size];

            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(1, 101);
            }

            Console.WriteLine("Как отсортировать массив : min , max?");

            string sort_way = Console.ReadLine();

            int temp;
            if (sort_way == "min")
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = size - 1; j > i; j--)
                    {
                        if (arr[j - 1] > arr[j])
                        {
                            temp = arr[j - 1];
                            arr[j - 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = size - 1; j > i; j--)
                    {
                        if (arr[j - 1] < arr[j])
                        {
                            temp = arr[j - 1];
                            arr[j - 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }

            for (int j = 0; j < size; j++)
            {
                Console.Write(arr[j] + " ");
            }
        }
    }
}
