using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuperviseeController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public SuperviseeController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/Supervisors
    [HttpGet("supervisee")]
    public async Task<ActionResult<List<Supervisee>>> Get()
    {
      return await _dbContext.Supervisees.ToListAsync();
    }

    // GET api/supervisors/5
    [HttpGet("supervisee/{id}")]
    public async Task<ActionResult<Supervisee>> Get(int id)
    {
      return await _dbContext.Supervisees.FindAsync(id);
    }

    // POST api/supervisors
    [HttpPost]
    public async Task Post(Supervisee model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/supervisors/5
    [HttpPut("editTask/{id}")]
    public async Task<ActionResult> Put_edit_tasks(int id, Supervisee model)
    {
      var exists = await _dbContext.Supervisees.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.Supervisees.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/supervisors/5
    [HttpDelete("remove/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var entity = await _dbContext.Supervisees.FindAsync(id);

      _dbContext.Supervisees.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}
