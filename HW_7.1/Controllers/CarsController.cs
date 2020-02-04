using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Web_7.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        CarsContext db;
        public CarsController(CarsContext context)
        {
            db = context;
            if (!db.Cars.Any())
            {
                db.Cars.Add( new Car { Name = "Kia Rio Eco",     Power = 100});
                db.Cars.Add( new Car { Name = "Kia Rio Sport",   Power = 190});
                db.Cars.Add( new Car { Name = "Hyundai Kona Electric Comfort",Power = 100});
                db.Cars.Add( new Car { Name = "Hyundai Kona Electric Style",  Power = 150});
                db.Cars.Add( new Car { Name = "Nissan Leaf E-Plus",           Power = 160});
                db.Cars.Add( new Car { Name = "Bright Crystal",               Power = 90});
                db.Cars.Add( new Car { Name = "Kia Soul EV",                  Power = 90});
                db.Cars.Add( new Car { Name = "Volkswagen e-Up",              Power = 62});
                db.Cars.Add( new Car { Name = "Mazda MX-30",                  Power = 105});
                db.Cars.Add( new Car { Name = "Porsche Taycan Turbo",         Power = 460});
                db.Cars.Add( new Car { Name = "Porsche Taycan Turbo S",       Power = 560});
                db.Cars.Add( new Car { Name = "Tesla Model S",                Power = 450});
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await db.Cars.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            Car car = await db.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
                return NotFound();
            return new ObjectResult(car);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            // если есть лшибки - возвращаем ошибку 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // если ошибок нет, сохраняем в базу данных
            db.Cars.Add(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Car>> Put(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!db.Cars.Any(x => x.Id == car.Id))
            {
                return NotFound();
            }

            db.Update(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            Car car = db.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            db.Cars.Remove(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }
    }
}
