using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuperController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public SuperController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/Supervisors
    [HttpGet("supervisee")]
    public async Task<ActionResult<List<Super>>> Get()
    {
      return await _dbContext.Supers.ToListAsync();
    }

    // GET api/supervisors/5
    [HttpGet("supervisee/{id}")]
    public async Task<ActionResult<Super>> Get(int id)
    {
      return await _dbContext.Supers.FindAsync(id);
    }

    // POST api/supervisors
    [HttpPost]
    public async Task Post(Super model)
    {
      await _dbContext.AddAsync(model);
      
      await _dbContext.SaveChangesAsync();
    }

    // PUT api/supervisors/5
    [HttpPut("editTask/{id}")]
    public async Task<ActionResult> Put_edit_tasks(int id, Super model)
    {
      var exists = await _dbContext.Supers.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.Supers.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/supervisors/5
    [HttpDelete("remove/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
      var entity = await _dbContext.Supers.FindAsync(id);

      _dbContext.Supers.Remove(entity);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}
