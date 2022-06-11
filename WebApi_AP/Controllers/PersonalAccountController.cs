using Microsoft.AspNetCore.Mvc;
using WebApi_AP.Data;

namespace WebApi_AP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalAccountController : ControllerBase
    {
        private readonly PersonalAccDbContext _db;
        public PersonalAccountController(PersonalAccDbContext db)
        {
            _db = db;
        }
        //create
        [HttpPost("Create")]
        public async Task<ActionResult<List<PersonalAccount>>> CreatePA(PersonalAccount obj)
        {
            await _db.PersonalAccounts.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok(await _db.PersonalAccounts.ToListAsync());
        }
        //read
        [HttpGet("Read")]
        public async Task<ActionResult<List<PersonalAccount>>> ReadPA()
        {
            return Ok(await _db.PersonalAccounts.ToListAsync());
        }
        //update
        [HttpGet("Update/{id}")]
        public async Task<ActionResult<PersonalAccount>> UpdatePA(int id)
        {
            var obj = await _db.PersonalAccounts.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Account not found");
            }
            return Ok(obj);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<PersonalAccount>> UpdatePA(PersonalAccount obj)
        {
            _db.PersonalAccounts.Update(obj);
            await _db.SaveChangesAsync();
            return Ok(obj);
        }
        //delete
        [HttpGet("GetDelete/{id}")]
        public async Task<ActionResult<PersonalAccount>> DeletePAGet(int id)
        {
            var obj = await _db.PersonalAccounts.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Account not found");
            }
            return Ok(obj);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<PersonalAccount>> DeletePA(int id)
        {
            var obj = await _db.PersonalAccounts.FindAsync(id);
            if (obj == null)
            {
                return BadRequest("Account not found");
            }
            _db.PersonalAccounts.Remove(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("Quantity/{id}")]
        public async Task<ActionResult<int>> QuantiyuPAGrVM(int id)
        {
            var quantity = _db.OneGroups.Where(x => x.IdGroup == id);
            var index = await quantity.CountAsync();
            return Ok(index);
        }
    }
}
