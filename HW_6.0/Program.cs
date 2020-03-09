using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HW_6._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                Alco_type easy = new Alco_type { Type = "Easy" };
                Alco_type hard = new Alco_type { Type = "Hard" };

                Alcohol alcohol1 = new Alcohol { Name = "White Horse", Alco_type = hard, Volume = 0.7, Strength = 40 };
                Alcohol alcohol2 = new Alcohol { Name = "Tuborg", Alco_type = easy, Volume = 0.5, Strength = 5 };
                Alcohol alcohol3 = new Alcohol { Name = "Heineken", Alco_type = easy, Volume = 0.5, Strength = 4 };
                Alcohol alcohol4 = new Alcohol { Name = "Talka", Alco_type = hard, Volume = 0.7, Strength = 40 };
                Alcohol alcohol5 = new Alcohol { Name = "Jagermeister", Alco_type = hard, Volume = 0.5, Strength = 35 };

                // добавляем их в бд
                db.Types.AddRange(easy, hard);

                db.Alcohols.AddRange(alcohol1, alcohol2, alcohol3, alcohol4, alcohol5);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var stagings = db.Alcohols.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Alcohol u in stagings)
                {
                    Console.WriteLine($"{u.Id}){u.Name} - {u.Alco_type.Type} |||||| Price - {u.Volume} |||||| Quantity free place - {u.Strength}");
                }
            }
            Console.Read();
        }
    }
}
