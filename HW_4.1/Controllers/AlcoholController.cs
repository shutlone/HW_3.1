using _4._0_GetPost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4._0_GetPost.Controllers
{
    public class AlcoholController : Controller
    {
        EssenceContext db;
        public AlcoholController(EssenceContext context)
        {
            db = context;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Alcohol alc)
        {
            if (db.Alcohols.Contains(alc))
                return BadRequest();

            db.Alcohols.Add(alc);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Index(string key)
        {
            var alcs = from a in db.Alcohols select a;
            if (!string.IsNullOrEmpty(key))
                alcs = alcs.Where(f => f.Brand.Contains(key) || f.Type.Contains(key));
            return View(alcs);
        }
        
        public IActionResult Properties(int? id)
        {
            if (id == null || db.Alcohols.Find(id) == null) return NotFound();
            ViewBag.alc = db.Alcohols.Find(id);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || db.Alcohols.Find(id) == null) return NotFound();
            return View(db.Alcohols.Find(id));
        }

        [HttpPost]
        public ActionResult Edit (Alcohol alc)
        {
            db.Entry(alc).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || db.Alcohols.Find(id) == null)
                return NotFound();

            return View(db.Alcohols.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            if (db.Alcohols.Find(id) == null)
                return NotFound();

            db.Alcohols.Remove(db.Alcohols.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
