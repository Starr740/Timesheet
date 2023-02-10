using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SupervisorController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public SupervisorController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/Supervisors
    [HttpGet]
    public async Task<ActionResult<List<Supervisor_Table>>> Get()
    {
      return await _dbContext.Supervisors.ToListAsync();
    }

    // GET api/supervisors/5
    [HttpGet("task/{id}")]
    public async Task<ActionResult<Supervisor_Table>> Get(int id)
    {
      return await _dbContext.Supervisors.FindAsync(id);
    }

    // POST api/supervisors
    [HttpPost]
    public async Task Post(Supervisor_Table model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/supervisors/5
    [HttpPut("editTask/{id}")]
    public async Task<ActionResult> Put_edit_tasks(int id, Supervisor_Table model)
    {
      var exists = await _dbContext.Supervisors.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.Supervisors.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/supervisors/5
    [HttpDelete("remove/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var entity = await _dbContext.Supervisors.FindAsync(id);

      _dbContext.Supervisors.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}
