using Microsoft.AspNetCore.Mvc;
using WebApi_AP.Data;

namespace WebApi_AP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonalAccDbContext _db;
        public PersonController(PersonalAccDbContext db)
        {
            _db = db;
        }
        //create
        [HttpPost("Create")]
        public async Task<ActionResult<List<Person>>> CreatePer(Person obj)
        {
            await _db.People.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok(await _db.People.ToListAsync());
        }
        //read
        [HttpGet("Read")]
        public async Task<ActionResult<List<Person>>> ReadPer()
        {
            return Ok(await _db.People.ToListAsync());
        }
        //edit
        [HttpGet("Update/{id}")]
        public async Task<ActionResult<Person>> UpdatePer(int id)
        {
            var obj = await _db.People.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Person not found");
            }
            return Ok(obj);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Person>> UpdatePer(Person obj)
        {
            _db.People.Update(obj);
            await _db.SaveChangesAsync();
            return Ok(obj);
        }
        //delete
        [HttpGet("GetDelete/{id}")]
        public async Task<ActionResult<Person>> DeletePerGet(int id)
        {
            var obj = await _db.People.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Person not found");
            }
            return Ok(obj);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Person>> DeletePer(int id)
        {
            var obj = await _db.People.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Person not found");
            }
            _db.People.Remove(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
