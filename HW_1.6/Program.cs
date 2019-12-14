using System;

namespace HW_1._6
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите свой текст: ");
            string str = Console.ReadLine();

            Int32 count = 0;

            string last_letters = "";

            char[] divider = { ' ' };

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    count++;
                }

            }

            str = str.Replace(".", "").Replace(",", "").Replace("-", "").Replace("!", "").Replace("?", "").Replace(":", "").Replace(";", "").Replace("(", "").Replace(")", "").Replace("\"", "").Replace("  ", " ");

            string[] words = str.Split(divider);

            for (int i = 0; i < words.Length; i++)
            {
                last_letters += words[i][words[i].Length - 1];
            }

            Console.WriteLine("Количество слов: " + words.Length + ";");

            Console.WriteLine("Количество символов без пробелов: " + count + ";");

            Console.WriteLine("Соотношение количество символов без пробелов к количеству слов: " + (double)count / words.Length + ";");

            Console.WriteLine("Слово из последних символов слов: " + last_letters + ";");

        }
    }
}
