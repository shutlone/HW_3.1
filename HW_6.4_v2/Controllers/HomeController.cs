using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HW_6._4_v2.Models;

namespace HW_6._4_v2.Controllers
{
    public class HomeController : Controller
    {
        AlcoholContext db;
        public HomeController(AlcoholContext context)
        {
            db = context;
            // добавляем начальные данные
            if (db.Alcohols.Count() == 0)
            {
                Alcohol alc1 = new Alcohol { Brand = "Jack Daniel's", Strength = 40, Volume = 8 };
                Alcohol alc2 = new Alcohol { Brand = "Триозерье", Strength = 40, Volume = 4 };
                Alcohol alc3 = new Alcohol { Brand = "VishkiCool", Strength = 40, Volume = 8 };
                Alcohol alc4 = new Alcohol { Brand = "Fire", Strength = 37, Volume = 7 };
                Alcohol alc5 = new Alcohol { Brand = "Aqua", Strength = 40, Volume = 2 };
                Alcohol alc6 = new Alcohol { Brand = "Kentuky Jack", Strength = 40, Volume = 8 };

                if (!context.Alcohols.Any())
                {
                    context.Alcohols.AddRange(alc1, alc2, alc3, alc4, alc5, alc6);
                    context.SaveChanges();
                }

                if (!context.Alco_types.Any())
                {
                    context.Alco_types.AddRange(
                        new Alco_type
                        {
                            Type = "Hard",
                            Price =  1000,
                        },
                        new Alco_type
                        {
                            Type = "Hard",
                            Price = 7000,
                        },
                        new Alco_type
                        {
                            Type = "Easy",
                            Price = 50,
                        },
                        new Alco_type
                        {
                            Type = "Hard",
                            Price = 800,
                        },
                        new Alco_type
                        {
                            Type = "Easy",
                            Price = 250,
                        }
                    );
                    context.SaveChanges();
                }
            }
        }

        //Eager loading позволяет загружать связанные данные с помощью метода Include()
        public IActionResult EagerLoadingIndex()
        {
            var alcohols = db.Alcohols.Include(x => x.Brand).ToList();
            return View(alcohols.ToList());
        }

        //Explicit loading предполагает явную загрузку данных с помощью метода Load
        public IActionResult ExplicitLoadingIndex()
        {
            db.Alcohols.Load();
            db.Alco_types.Load();
            return View(db.Alcohols.ToList());
        }

        //Lazy loading предполагает неявную автоматическую загрузку связанных данных
        public IActionResult LazyLoadingIndex()
        {
            //var cars = db.Cars.ToList();
            return View(db.Alcohols.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
