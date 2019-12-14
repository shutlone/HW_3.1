using System;

namespace HW_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Введите 1 число");
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите 2 число");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите операцию");
                string operation = Convert.ToString(Console.ReadLine());

                switch (operation)
                {
                    case "*":
                        Console.WriteLine("Результат операции: " + (a * b));
                        break;
                    case "/":
                        if (b == 0)
                        {
                            Console.WriteLine("Ошибка, на ноль делить нельзя");
                            break;
                        }
                        Console.WriteLine("Результат операции: " + (a / b));
                        break;
                    case "+":
                        Console.WriteLine("Результат операции: " + (a / b));
                        break;
                    case "-":
                        Console.WriteLine("Результат операции: " + (a - b));
                        break;
                    default:
                        Console.WriteLine("Введите операцию корректно");
                        break;
                }
                Console.WriteLine("Напишите exit чтобы выйти или любую клавишу чтобы начать заного");
                if (Console.ReadLine() == "exit")
                    break;

            }



        }
    }
}
