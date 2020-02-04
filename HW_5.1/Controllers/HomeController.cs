using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _5._0_ViewModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _5._0_ViewModel.Controllers
{
    public class HomeController : Controller
    {
        AlcoMusicContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AlcoMusicContext context)
        {
            _logger = logger;
            db = context;
            if(db.Musics.Count() == 0)
            {
                Music Skillet = new Music { Name = "Rise", Executor = "Skillet", Genre = "Rock", Lenght = 100 };
                Music TDG = new Music { Name = " Never too late", Executor = "TDG", Genre = "Rock", Lenght = 200 };
                Music Powerwolf = new Music { Name = "Omen'n'Attack", Executor = "Powerwolf", Genre = "Rock", Lenght = 150 };

                Alcohol alc1 = new Alcohol { Brand = "Jack Daniel's", Music = Skillet, Type = "Виски", Strength = 40, Volume = 8, CreationDate = DateTime.Now };
                Alcohol alc2 = new Alcohol { Brand = "Триозерье", Music = TDG, Type = "Водка", Strength = 40, Volume = 4, CreationDate = DateTime.Now };
                Alcohol alc3 = new Alcohol { Brand = "VishkiCool", Music = TDG, Type = "Виски", Strength = 40, Volume = 8, CreationDate = DateTime.Now };
                Alcohol alc4 = new Alcohol { Brand = "Fire", Music = Powerwolf, Type = "Коньяк", Strength = 37, Volume = 7, CreationDate = DateTime.Now };
                Alcohol alc5 = new Alcohol { Brand = "Aqua", Music = Skillet, Type = "Текила", Strength = 40, Volume = 2, CreationDate = DateTime.Now };
                Alcohol alc6 = new Alcohol { Brand = "Kentuky Jack", Music = Skillet, Type = "Виски", Strength = 40, Volume = 8, CreationDate = DateTime.Now };

                db.Musics.AddRange(Skillet, TDG, Powerwolf);
                db.Alcohols.AddRange(alc1, alc2, alc3, alc4, alc5, alc6);
                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(int? music, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int PageSize = 3;
            IQueryable<Alcohol> alcs = db.Alcohols.Include(x => x.Music);

            if (music != null && music != 0)
            {
                alcs = alcs.Where(a => a.MusicId == music);
            }
            if (!string.IsNullOrEmpty(name))
            {
                alcs = alcs.Where(a => a.Brand.Contains(name) || a.Type.Contains(name));
            }
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    alcs = alcs.OrderByDescending(a => a.Brand);
                    break;
                case SortState.StrenghtAsc:
                    alcs = alcs.OrderBy(a => a.Strength);
                    break;
                case SortState.StrenghtDesc:
                    alcs = alcs.OrderByDescending(s => s.Strength);
                    break;
                case SortState.MusicAsc:
                    alcs = alcs.OrderBy(a => a.Music.Executor);
                    break;
                case SortState.MusicDesc:
                    alcs = alcs.OrderByDescending(a => a.Music.Executor);
                    break;
                default:
                    alcs = alcs.OrderBy(a => a.Brand);
                    break;
            }

            var count = await alcs.CountAsync();
            var items = await alcs.Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();
           
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, PageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Musics.ToList(), music, name),
                Alcohols = items
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            
            SelectList list = new SelectList(db.Musics.ToList(), "Id", "Executor");
            ViewBag.MusicId = list;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Alcohol alc)
        {
            if(db.Alcohols.Contains(alc))
            {
                return BadRequest();
            }
            alc.CreationDate = DateTime.Now;
            db.Alcohols.Add(alc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
