using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private DataContext db;

        public DepartmentsController(DataContext context)
        {
            db = context;
            if (!db.Departments.Any())
            {
                db.Departments.Add(new Department { Name = "IT" });
                db.Departments.Add(new Department { Name = "HR" });
                db.SaveChanges();
            }
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> Get()
        {
            return await db.Departments.ToListAsync();
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            Department deparment = await db.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (deparment == null)
                return NotFound();
            return new ObjectResult(deparment);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<ActionResult<Department>> Post(Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            db.Departments.Add(department);
            await db.SaveChangesAsync();
            return Ok(department);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut]
        public async Task<ActionResult<Department>> Put(Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            if (!db.Departments.Any(x => x.Id == department.Id))
            {
                return NotFound();
            }

            db.Departments.Update(department);
            await db.SaveChangesAsync();
            return Ok(department);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> Delete(int id)
        {
            Department department = db.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            db.Departments.Remove(department);
            await db.SaveChangesAsync();
            return Ok(department);
        }
    }
}
