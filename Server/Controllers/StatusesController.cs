using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private DataContext db;

        public StatusesController(DataContext context)
        {
            db = context;
            if (!db.Statuses.Any())
            {
                db.Statuses.Add(new Status { Name = "OK" });
                db.Statuses.Add(new Status{ Name = "Ne ok" });
                db.SaveChanges();
            }
        }
        // GET: api/<PlacesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> Get()
        {
            return await db.Statuses.ToListAsync();
        }

        // GET api/<PlacesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            Status status = await db.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            if (status == null)
                return NotFound();
            return new ObjectResult(status);
        }

        // POST api/<PlacesController>
        [HttpPost]
        public async Task<ActionResult<Status>> Post(Status status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            db.Statuses.Add(status);
            await db.SaveChangesAsync();
            return Ok(status);
        }

        // PUT api/<PlacesController>/5
        [HttpPut]
        public async Task<ActionResult<Status>> Put(Status status)
        {
            if (status == null)
            {
                return BadRequest();
            }
            if (!db.Statuses.Any(x => x.Id == status.Id))
            {
                return NotFound();
            }

            db.Statuses.Update(status);
            await db.SaveChangesAsync();
            return Ok(status);
        }

        // DELETE api/<PlacesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> Delete(int id)
        {
            Status status = db.Statuses.FirstOrDefault(x => x.Id == id);
            if (status == null)
            {
                return NotFound();
            }
            db.Statuses.Remove(status);
            await db.SaveChangesAsync();
            return Ok(status);
        }
    }
}
