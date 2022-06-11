using Microsoft.AspNetCore.Mvc;
using WebApi_AP.Data;

namespace WebApi_AP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly PersonalAccDbContext _db;
        public GroupController(PersonalAccDbContext db)
        {
            _db = db;
        }
        //create
        [HttpPost("Create")]
        public async Task<ActionResult<List<OneGroup>>> CreateGr(OneGroup obj)
        {
            await _db.OneGroups.AddAsync(obj);
            await _db.SaveChangesAsync();
            var gr = from o in _db.OneGroups
                     join p in _db.People on o.IdPerson equals p.IdPerson
                     select new { o.IdGroup, p.IdPerson };
            return Ok(await gr.ToListAsync());
        }
        //read
        [HttpGet("Read")]
        public async Task<ActionResult<List<OneGroup>>> ReadGr()
        {
            var gr = from o in _db.OneGroups
                     join p in _db.People on o.IdPerson equals p.IdPerson
                     select new { o.IdGroup, p.IdPerson };
            return Ok(await gr.ToListAsync());
        }
        //edit
        [HttpGet("Update/{id}")]
        public async Task<ActionResult<OneGroup>> UpdateGr(int id)
        {
            var obj = await _db.OneGroups.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Person not found");
            }
            return Ok(obj);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<OneGroup>> UpdateGr(OneGroup obj)
        {
            _db.OneGroups.Update(obj);
            await _db.SaveChangesAsync();
            return Ok(obj);
        }
        //delete
        [HttpGet("GetDelete/{id}")]
        public async Task<ActionResult<OneGroup>> DeleteGrGet(int id)
        {
            var obj = await _db.OneGroups.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Person not found");
            }
            return Ok(obj);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<OneGroup>> DeletePer(int id)
        {
            await _db.Database.ExecuteSqlRawAsync("Delete OneGroup where ID_Group = {0}", id);
            return Ok();
        }
    }
}
