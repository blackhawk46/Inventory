using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private DataContext db;

        public PlacesController(DataContext context)
        {
            db = context;
            if (!db.Places.Any())
            {
                db.Places.Add(new Place { Name = "Podval" });
                db.Places.Add(new Place { Name = "101 kab" });
                db.SaveChanges();
            }
        }
        // GET: api/<PlacesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> Get()
        {
            return await db.Places.ToListAsync();
        }

        // GET api/<PlacesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> Get(int id)
        {
            Place place = await db.Places.FirstOrDefaultAsync(x => x.Id == id);
            if (place == null)
                return NotFound();
            return new ObjectResult(place);
        }

        // POST api/<PlacesController>
        [HttpPost]
        public async Task<ActionResult<Place>> Post(Place place)
        {
            if (place == null)
            {
                return BadRequest();
            }

            db.Places.Add(place);
            await db.SaveChangesAsync();
            return Ok(place);
        }

        // PUT api/<PlacesController>/5
        [HttpPut]
        public async Task<ActionResult<Place>> Put(Place place)
        {
            if (place == null)
            {
                return BadRequest();
            }
            if (!db.Places.Any(x => x.Id == place.Id))
            {
                return NotFound();
            }

            db.Places.Update(place);
            await db.SaveChangesAsync();
            return Ok(place);
        }

        // DELETE api/<PlacesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Place>> Delete(int id)
        {
            Place place = db.Places.FirstOrDefault(x => x.Id == id);
            if (place == null)
            {
                return NotFound();
            }
            db.Places.Remove(place);
            await db.SaveChangesAsync();
            return Ok(place);
        }
    }
}
